using UnityEngine;

[CreateAssetMenu(menuName = "Game/CharacterData")]
public class CharacterDataAsset : ScriptableObject
{
    public string characterName;
    public int level;
    public Sprite avatar;
    public GameObject characterPrefab;
    public GameObject detailsPrefab;

}
