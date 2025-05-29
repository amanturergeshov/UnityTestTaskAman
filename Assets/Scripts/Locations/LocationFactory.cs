public class LocationFactory : ISelectableFactory<LocationDataAsset, LocationSelectable>
{
    public LocationSelectable Create(LocationDataAsset asset) => new LocationSelectable(asset);
}