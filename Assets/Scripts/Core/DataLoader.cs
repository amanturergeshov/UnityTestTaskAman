using System;
using System.Collections.Generic;
using UnityEngine;

public static class DataLoader<T, TAsset> where T : SelectableBase<TAsset> where TAsset : ScriptableObject
{
    public static IEnumerable<T> LoadAll(string resourcePath, ISelectableFactory<TAsset, T> factory)
    {
        var assets = Resources.LoadAll<TAsset>(resourcePath);
        foreach (var asset in assets)
        {
             yield return factory.Create(asset);
        }
    }
    
}
