using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestArrayAndListPersistence : MonoBehaviour
{
    [SerializeField] List<Trait> traits;
    [SerializeField] Trait[] traitsArr;
    
    // Start is called before the first frame update
    void Start()
    {
        if(traits == null){
            traits = new List<Trait>();
        }    
    }
}
