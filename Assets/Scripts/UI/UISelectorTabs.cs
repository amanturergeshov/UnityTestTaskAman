using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class UISelectorTabs : MonoBehaviour
{
    public Button characterTab;
    public Button locationTab;
    public UISelectorPanel selectorPanel;

    private SelectionContainer<CharacterSelectable> characterContainer = new();
    private SelectionContainer<LocationSelectable> locationContainer = new();

    private List<CharacterSelectable> characterList;
    private List<LocationSelectable> locationList;

    private void Start()
    {
        characterTab.onClick.AddListener(ShowCharacters);
        locationTab.onClick.AddListener(ShowLocations);

        ShowCharacters(); // Load default view
    }

    private void ShowCharacters()
    {
        if (characterList == null)
        {
            var factory = new CharacterFactory();
            characterList = DataLoader<CharacterSelectable, CharacterDataAsset>
                .LoadAll("Characters", factory)
                .ToList();
        }

        selectorPanel.Initialize<CharacterSelectable, CharacterDataAsset>(characterList, characterContainer);
    }

    private void ShowLocations()
    {
        if (locationList == null)
        {
            var factory = new LocationFactory();
            locationList = DataLoader<LocationSelectable, LocationDataAsset>
                .LoadAll("Locations", factory)
                .ToList();
        }

        selectorPanel.Initialize<LocationSelectable, LocationDataAsset>(locationList, locationContainer);
    }
}
