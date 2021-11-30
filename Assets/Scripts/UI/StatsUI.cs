using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsUI : MonoBehaviour
{
    [SerializeField] StatBar enduranceBar;
    [SerializeField] StatBar intelligenceBar;
    [SerializeField] StatBar survivabilityBar;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    public void Hide()
    {
        enduranceBar.Hide();
        intelligenceBar.Hide();
        survivabilityBar.Hide();
        gameObject.SetActive(false);
    }

    public void DisplayStats(CustomerData custData)
    {
        enduranceBar.SetValue(custData.Endurance.ModifiedValue);
        intelligenceBar.SetValue(custData.Intelligence.ModifiedValue);
        survivabilityBar.SetValue(custData.Survivability.ModifiedValue);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
