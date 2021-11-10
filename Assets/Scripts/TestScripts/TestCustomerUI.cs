using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text;

public class TestCustomerUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI statDisplay;
    [SerializeField] TextMeshProUGUI nameDisplay;
    
    private Customer customer;
    private CustomerData custData;

    private StringBuilder sb;
    
    // Start is called before the first frame update
    void Start()
    {
        sb = new StringBuilder();
        customer = GetComponent<Customer>();

        custData = customer.GetCustomerData();

        nameDisplay.text = custData.Name;

        //DisplayStats();

    }

    // Update is called once per frame
    void Update()
    {
        // if(customer.WereStatsModified()){
        //     DisplayStats();
        //     customer.SetStatsModified(false);
        // }
        DisplayStats();
    }

    private void DisplayStats()
    {
        statDisplay.text = "";
        sb.Clear();
        
        sb.Append($"Endurance - {custData.Endurance.GetModifiedValue()}\n");
        sb.Append($"Intelligence - {custData.Intelligence.GetModifiedValue()}\n");
        sb.Append($"Survivability - {custData.Survivability.GetModifiedValue()}\n");

        statDisplay.text = sb.ToString();
    }
}
