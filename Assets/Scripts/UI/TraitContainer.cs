using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TraitContainer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI traitName;
    [SerializeField] TextMeshProUGUI traitDetails; 

    private bool isOccupied = false;
    
    public void SetTraitDetails(Trait trait)
    {
        traitName.text = trait.Name;
        traitDetails.text = trait.Description;
        isOccupied = true;
    }

    public void Clear()
    {
        traitName.text = "";
        traitDetails.text = "";
        isOccupied = false;
    }

    public bool IsOccupied => isOccupied;
}
