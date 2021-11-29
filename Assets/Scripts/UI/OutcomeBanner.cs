using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class OutcomeBanner : MonoBehaviour
{
    [SerializeField] Image customerSprite;
    [SerializeField] TextMeshProUGUI customerName;
    [SerializeField] TextMeshProUGUI survivalProbability;
    [SerializeField] Image hasSurvivedSprite; 
    
    public void SetBanner(CustomerData custData, bool hasSurvived)
    {
        customerSprite.sprite = custData.Sprite;
        customerName.text = custData.Name;
        survivalProbability.text = $"{custData.SurvivalProbability.ToString()}%";

        if(!hasSurvived){
            hasSurvivedSprite.enabled = false;
        }

    }
}
