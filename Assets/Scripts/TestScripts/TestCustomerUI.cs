using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text;
using System;

public class TestCustomerUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI statDisplay;
    [SerializeField] TextMeshProUGUI nameDisplay;
    [SerializeField] TextMeshProUGUI probabilityDisplay;
    [SerializeField] Image customerImg;
    
    private Customer customer;
    private CustomerData custData;

    private StringBuilder sb;
    
    // Start is called before the first frame update
    void Start()
    {
        sb = new StringBuilder();
        customer = GetComponent<Customer>();

        custData = customer.CustomerData;

        nameDisplay.text = custData.Name;

        customerImg.sprite = custData.Sprite;

    }

    // Update is called once per frame
    void Update()
    {
        DisplayStats();

        DisplaySurvivalProbability();
    }

    private void DisplayStats()
    {
        statDisplay.text = "";
        sb.Clear();
        
        sb.Append($"Endurance - {custData.Endurance.ModifiedValue}\n");
        sb.Append($"Intelligence - {custData.Intelligence.ModifiedValue}\n");
        sb.Append($"Survivability - {custData.Survivability.ModifiedValue}\n");

        statDisplay.text = sb.ToString();
    }

    private void DisplaySurvivalProbability()
    {
        int prob = (int) Math.Ceiling(customer.CalculateSurvivalProbability());
        probabilityDisplay.text = $"{prob}%";
    }
}
