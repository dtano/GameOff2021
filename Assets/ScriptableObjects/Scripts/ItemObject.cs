using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "Item/New Item")]
public class ItemObject : ScriptableObject
{
    public string itemName;
    public Sprite sprite;
    [TextArea]
    public string description;

    public StatModifier enduranceModifier;
    public StatModifier intelligenceModifier;
    public StatModifier survivabilityModifier;

    [SerializeField] string id;
    public string ID { get { return id; } }
    [Range(1, 999)]
    public int MaximumStacks = 1;

    private void OnValidate()
    {
        string path = AssetDatabase.GetAssetPath(this);
        id = AssetDatabase.AssetPathToGUID(path);
    }

    public virtual ItemObject GetCopy()
    {
        return this;
    }


    // Might need a list of traits that it is affected by
    // public List<Trait> traitsAffectedBy;
}
