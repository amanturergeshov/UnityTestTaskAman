using UnityEngine;
using UnityEngine.UI;
using System;

public class UISelectableItem : MonoBehaviour
{
    public Text nameText;
    public Image iconImage;
    public Button button;

    private ISelectableData _data;
    private Action<ISelectableData> _onClick;

    public void Initialize(ISelectableData data, Action<ISelectableData> onClick)
    {
        _data = data;
        _onClick = onClick;
        nameText.text = _data.DisplayName;
        iconImage.sprite = _data.Icon;
        button.onClick.AddListener(() => _onClick?.Invoke(_data));
    }
}
