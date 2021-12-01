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

    [SerializeField] private Sprite successSprite;
    [SerializeField] private Sprite failureSprite;

    void Awake()
    {
        //successSprite = Resources.Load("Sprites/Tick") as Sprite;
    }


    
    public void SetBanner(CustomerData custData, bool hasSurvived)
    {
        customerSprite.sprite = custData.Sprite;
        customerName.text = custData.Name;
        survivalProbability.text = $"{custData.SurvivalProbability.ToString()}%";

        if(!hasSurvived){
            //hasSurvivedSprite.enabled = false;
            hasSurvivedSprite.sprite = failureSprite;
            hasSurvivedSprite.color = Color.red;
        }else{
            hasSurvivedSprite.sprite = successSprite;
            hasSurvivedSprite.color = Color.white;
        }

    }
}
