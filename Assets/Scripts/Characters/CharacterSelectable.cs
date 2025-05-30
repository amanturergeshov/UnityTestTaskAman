using UnityEngine;

public class CharacterSelectable : SelectableBase<CharacterDataAsset>
{
    public CharacterSelectable(CharacterDataAsset asset)
    {
        _dataAsset = asset;
    }

    public override string DisplayName => _dataAsset.characterName;
    public override Sprite Icon => _dataAsset.avatar;
    public int Level => _dataAsset.level;
    public GameObject CharacterPrefab => _dataAsset.characterPrefab;


    public override void Load()
    {
        // GameObject.Instantiate(_dataAsset.characterPrefab);
        Debug.Log(DisplayName);
    }
    public override GameObject GetDetailsPrefab()
    {
        return _dataAsset.detailsPrefab;
    }
}
