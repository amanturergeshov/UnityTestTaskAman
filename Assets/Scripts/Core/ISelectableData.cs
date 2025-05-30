using UnityEngine;

public interface ISelectableData
{
    string Id { get; }
    string DisplayName { get; }
    Sprite Icon { get; }
    void Load();
    GameObject GetDetailsPrefab();
}
