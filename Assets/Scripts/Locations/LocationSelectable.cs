using UnityEngine;
using UnityEngine.SceneManagement;

public class LocationSelectable : SelectableBase<LocationDataAsset>
{
    public LocationSelectable(LocationDataAsset asset)
    {
        _dataAsset = asset;
    }

    public override string DisplayName => _dataAsset.locationName;
    public override Sprite Icon => _dataAsset.previewImage;
    public string Description => _dataAsset.description;

    public override void Load()
    {
        SceneManager.LoadScene(_dataAsset.sceneId);
    }
}
