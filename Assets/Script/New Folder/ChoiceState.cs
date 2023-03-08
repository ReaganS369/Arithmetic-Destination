using UnityEngine;

public enum ItemType
{
    Player,
    Trap,
    Destination,
    Wall
}

[CreateAssetMenu(menuName = "Item/ChoiceState")]
public class ChoiceState : ScriptableObject
{
    public ItemType itemType;
    public GameObject prefab;
}
