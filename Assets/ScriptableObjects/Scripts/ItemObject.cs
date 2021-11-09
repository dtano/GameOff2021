using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item/New Item")]
public class ItemObject : ScriptableObject
{
    public string itemName;
    public Sprite sprite;
    [TextArea]
    public string description;

    public List<int> statsToAffect;
}
