public interface ISelectableFactory<TAsset, T>
{
    T Create(TAsset asset);
}