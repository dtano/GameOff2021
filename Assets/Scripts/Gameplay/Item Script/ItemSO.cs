using UnityEngine;
using UnityEditor;

[CreateAssetMenu]
public class ItemSO : ScriptableObject
{
    [SerializeField] string id;
    public string ID { get { return id; } }
    public string ItemSOName;
    public Sprite Icon;
    
    [Range(1, 999)]
    public int MaximumStacks = 1;

    // private void OnValidate()
    // {
    //     string path = AssetDatabase.GetAssetPath(this);
    //     id = AssetDatabase.AssetPathToGUID(path);
    // }

    public virtual ItemSO GetCopy()
    {
        return this;
    }

    public virtual void Destroy()
    {

    }
}
