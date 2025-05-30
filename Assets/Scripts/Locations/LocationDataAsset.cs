using UnityEngine;

[CreateAssetMenu(menuName = "Game/LocationData")]
public class LocationDataAsset : ScriptableObject
{
    public string locationName;
    public string description;
    public Sprite previewImage;
    public string sceneId;
    public GameObject detailsPrefab;
}
