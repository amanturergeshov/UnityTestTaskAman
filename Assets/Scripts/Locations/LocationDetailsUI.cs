using UnityEngine;
using UnityEngine.UI;

public class LocationDetailsUI : MonoBehaviour, IDetailUI<LocationSelectable>
{
    public Text titleText;
    public Text descriptionText;
    public Image previewImage;

    public void Display(LocationSelectable data)
    {
        titleText.text = data.DisplayName;
        descriptionText.text = data.Description;
        previewImage.sprite = data.Icon;
    }
}
