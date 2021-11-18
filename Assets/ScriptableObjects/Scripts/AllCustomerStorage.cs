using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Holds customer data for a day/level so that we could display it in a day over screen
[CreateAssetMenu(menuName = "Customer/Customer Storage/New Customer Storage")]
public class AllCustomerStorage : ScriptableObject
{
    public List<CustomerData> allCustData = new List<CustomerData>();

    public void SimulateSurvivalOutcome()
    {
        // Go through all customer data and simulate what happens
    }

    public bool AddCustomerData(CustomerData customerData)
    {
        if(!allCustData.Contains(customerData)){
            allCustData.Add(customerData);
            return true;
        }

        return false;
    }

    public bool RemoveCustomerData(CustomerData customerData)
    {
        return allCustData.Remove(customerData);
    }

    public void Clear()
    {
        allCustData.Clear();
    }
}
