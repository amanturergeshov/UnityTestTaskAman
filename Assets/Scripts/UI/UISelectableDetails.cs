using UnityEngine;
using UnityEngine.UI;

public class UISelectableDetails : MonoBehaviour
{
    public Text nameText;
    public Text extraInfoText;
    public Image iconImage;

    public void Display(ISelectableData data)
    {
        nameText.text = data.DisplayName;
        iconImage.sprite = data.Icon;

        // Расширенное описание, если доступно через каст
        if (data is CharacterSelectable character)
        {
            extraInfoText.text = $"Level: {character.Level}";
        }
        else if (data is LocationSelectable location)
        {
            extraInfoText.text = $"Description: {location.Description}";
        }
        else
        {
            extraInfoText.text = string.Empty;
        }
    }
}
