using UnityEngine;

public abstract class SelectableBase<T> : ISelectableData where T : ScriptableObject
{
    protected T _dataAsset;

    public virtual string Id => _dataAsset.name;
    public abstract string DisplayName { get; }
    public abstract Sprite Icon { get; }

    public abstract void Load();
}
