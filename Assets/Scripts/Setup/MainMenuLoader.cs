using UnityEngine;

public class MainMenuLoader : MonoBehaviour
{
    public UISelectorPanel selectorPanel;

    void Start()
    {
        var factory = new CharacterFactory();
        var characters = DataLoader<CharacterSelectable, CharacterDataAsset>.LoadAll("Characters", factory);
        var container = new SelectionContainer<CharacterSelectable>();

        selectorPanel.Initialize<CharacterSelectable, CharacterDataAsset>(characters, container);
    }
}