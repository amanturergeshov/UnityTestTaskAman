using System.Collections.Generic;
using UnityEngine;

public class UISelectorPanel : MonoBehaviour
{
    public GameObject itemPrefab;
    public Transform contentParent;
    public GameObject detailsPrefab;
    private GameObject _detailsInstance;

    public void Initialize<T, TAsset>(IEnumerable<T> items, SelectionContainer<T> container)
        where T : SelectableBase<TAsset>, ISelectableData
        where TAsset : ScriptableObject
    {
        foreach (var item in items)
        {
            var instance = Instantiate(itemPrefab, contentParent);
            var uiItem = instance.GetComponent<UISelectableItem>();
            uiItem.Initialize(item, data => container.Select((T)data));
        }

        container.OnSelectionChanged += item =>
        {
            if (_detailsInstance != null)
                Destroy(_detailsInstance);

            _detailsInstance = Instantiate(detailsPrefab, transform);
            _detailsInstance.GetComponent<UISelectableDetails>().Display(item);
        };
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
            _detailsInstance = Instantiate(detailsPrefab, transform);
            _detailsInstance.GetComponent<UISelectableDetails>().Display(current);
        }
    }
}
