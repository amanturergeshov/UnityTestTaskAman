using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISelectorPanel : MonoBehaviour
{
    public GameObject itemPrefab;
    public Transform contentParent;
    private GameObject _detailsInstance;
    public Transform detailArea;

    public void ClearUI()
    {
        foreach (Transform child in contentParent)
            Destroy(child.gameObject);

        if (_detailsInstance != null)
            Destroy(_detailsInstance);

        _detailsInstance = null;

    }

    public void Initialize<T, TAsset>(IEnumerable<T> items, SelectionContainer<T> container)
        where T : SelectableBase<TAsset>, ISelectableData
        where TAsset : ScriptableObject
    {
        // //DEBUG
        // Debug.Log($"[UISelectorPanel] Initialize called for {typeof(T).Name} at {Time.time} by {GetCallerName()}");
        ClearUI();
        foreach (var item in items)
        {
            var instance = Instantiate(itemPrefab, contentParent);
            var uiItem = instance.GetComponent<UISelectableItem>();
            uiItem.Initialize(item, data => container.Select((T)data));
        }


        container.ClearCallbacks();
        container.OnSelectionChanged += item =>DisplayDetails(item);

        LayoutRebuilder.ForceRebuildLayoutImmediate(contentParent.GetComponent<RectTransform>());
    }

    public void ReactivateLast<T, TAsset>(SelectionContainer<T> container)
        where T : SelectableBase<TAsset>, ISelectableData
        where TAsset : ScriptableObject
    {
        foreach (Transform child in contentParent)
            Destroy(child.gameObject);

        var current = container.Current;
        if (current != null)
        {
            _detailsInstance = Instantiate(current.GetDetailsPrefab(), transform);
            _detailsInstance.GetComponent<UISelectableDetails>().Display(current);
        }
    }

    private void DisplayDetails<T>(T item) where T : ISelectableData
    {
        if (_detailsInstance != null)
            Destroy(_detailsInstance);

        _detailsInstance = Instantiate(item.GetDetailsPrefab(), detailArea);

        var detailUI = _detailsInstance.GetComponent(typeof(IDetailUI<>).MakeGenericType(item.GetType()));
        if (detailUI != null)
        {
            var method = detailUI.GetType().GetMethod("Display");
            method?.Invoke(detailUI, new object[] { item });
        }
    }

    //DEBUG
    // private string GetCallerName()
    // {
    //     var stack = new System.Diagnostics.StackTrace();
    //     for (int i = 2; i < stack.FrameCount; i++)
    //     {
    //         var method = stack.GetFrame(i).GetMethod();
    //         if (method.DeclaringType != typeof(UISelectorPanel))
    //             return $"{method.DeclaringType.Name}.{method.Name}";
    //     }
    //     return "Unknown Caller";
    // }

}
