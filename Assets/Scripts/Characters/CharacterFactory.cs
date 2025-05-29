public class CharacterFactory : ISelectableFactory<CharacterDataAsset, CharacterSelectable>
{
    public CharacterSelectable Create(CharacterDataAsset asset) => new CharacterSelectable(asset);
}