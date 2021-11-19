using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text;
using System;

public class CustomerUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI statDisplay;
    [SerializeField] TextMeshProUGUI nameDisplay;
    [SerializeField] TextMeshProUGUI probabilityDisplay;
    [SerializeField] Image customerImg;
    
    [SerializeField] Animator animator;
    private Customer customer;
    //private CustomerData custData;

    private StringBuilder sb;
    
    // Start is called before the first frame update
    void Start()
    {
        sb = new StringBuilder();
        customer = GetComponent<Customer>();

        nameDisplay.text = customer.CustomerData.Name;

        customerImg.sprite = customer.CustomerData.Sprite;

        //animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        DisplayCustomerDetails();
    }


    private void DisplayCustomerDetails()
    {
        CustomerData custData = customer.CustomerData;

        nameDisplay.text = custData.Name;
        customerImg.sprite = custData.Sprite;
        
        DisplayStats(custData);

        DisplaySurvivalProbability();
    }


    private void DisplayStats(CustomerData custData)
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

    private void HideUIElements()
    {
        statDisplay.gameObject.SetActive(false);
        nameDisplay.gameObject.SetActive(false);
        probabilityDisplay.gameObject.SetActive(false);
    }

    public void ShowUIElements()
    {
        statDisplay.gameObject.SetActive(true);
        nameDisplay.gameObject.SetActive(true);
        probabilityDisplay.gameObject.SetActive(true);
    }

    public void MakeCustomerLeaveStore()
    {
        HideUIElements();
        
        // Hide all UI text here and set animation trigger to leave
        animator.SetTrigger("LeaveStore");
    }

    public void EnterNewCustomer()
    {
        animator.SetTrigger("EnterStore");
    }

    
}
