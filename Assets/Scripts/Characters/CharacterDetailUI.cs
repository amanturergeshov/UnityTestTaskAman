using UnityEngine;
using UnityEngine.UI;

public class CharacterDetailsUI : MonoBehaviour, IDetailUI<CharacterSelectable>
{
    public Text nameText;
    public Text levelText;
    public Image avatarImage;
    public RawImage previewRender;
    private GameObject _previewInstance;

public void Display(CharacterSelectable data)
{
    nameText.text = data.DisplayName;
    levelText.text = $"Level: {data.Level}";
    avatarImage.sprite = data.Icon;

    if (_previewInstance != null)
        Destroy(_previewInstance);

    var prefab = data.CharacterPrefab;

    if (prefab != null)
    {
        _previewInstance = Instantiate(prefab);
        _previewInstance.layer = LayerMask.NameToLayer("Preview");

        foreach (Transform child in _previewInstance.transform)
            child.gameObject.layer = LayerMask.NameToLayer("Preview");
    }
}

}
