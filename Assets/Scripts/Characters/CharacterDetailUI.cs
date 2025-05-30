using UnityEngine;
using UnityEngine.UI;

public class CharacterDetailsUI : MonoBehaviour, IDetailUI<CharacterSelectable>
{
    public Text nameText;
    public Text levelText;
    public Image avatarImage;
public void Display(CharacterSelectable data)
    {
        nameText.text = data.DisplayName;
        levelText.text = $"Level: {data.Level}";
        avatarImage.sprite = data.Icon;
    }

}
