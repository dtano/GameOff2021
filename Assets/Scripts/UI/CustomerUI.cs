using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text;
using System;

public class CustomerUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI nameDisplay;
    [SerializeField] TextMeshProUGUI probabilityDisplay;
    [SerializeField] StatsUI statsUI;
    [SerializeField] TraitUI traitUI;
    [SerializeField] TextMeshProUGUI customersServedCounter;
    [SerializeField] Image customerImg;
    
    [SerializeField] Animator animator;
    private Customer customer;
    //private CustomerData custData;

    private StringBuilder sb;
    private bool isActive = false;

    public bool IsActive => isActive;
    
    // Start is called before the first frame update
    void Start()
    {
        sb = new StringBuilder();
        customer = GetComponent<Customer>();

        ShowNumCustomersServed(0);

        HideUIElements();

    }

    // Update is called once per frame
    void Update()
    {
        if(isActive){
            DisplayCustomerDetails();
        }
    }


    private void DisplayCustomerDetails()
    {
        CustomerData custData = customer.CustomerData;

        nameDisplay.text = custData.Name;
        customerImg.sprite = custData.Sprite;
        
        statsUI.DisplayStats(custData);
        traitUI.DisplayTraits(custData.Traits);
        DisplaySurvivalProbability();
        
    }


    private void DisplaySurvivalProbability()
    {
        int prob = (int) Math.Ceiling(customer.CalculateSurvivalProbability());
        probabilityDisplay.text = $"{prob}%";
    }

    public void HideUIElements()
    {
        nameDisplay.gameObject.SetActive(false);
        probabilityDisplay.gameObject.SetActive(false);
        traitUI.Hide();
        statsUI.Hide();
        Deactivate();
    }


    public void ShowUIElements()
    {
        nameDisplay.gameObject.SetActive(true);
        probabilityDisplay.gameObject.SetActive(true);
        traitUI.Show();
        statsUI.gameObject.SetActive(true);
        Activate();
    }

    public void ShowNumCustomersServed(int amount)
    {
        customersServedCounter.text = $"{amount}/12";
    }

    public void MakeCustomerLeaveStore()
    {
        HideUIElements();
        
        // Hide all UI text here and set animation trigger to leave
        animator.SetTrigger("LeaveStore");
    }

    public void EnterNewCustomer()
    {
        customerImg.sprite = customer.CustomerData.Sprite;
        animator.SetTrigger("EnterStore");
    }

    public void Activate()
    {
        isActive = true;
    }

    public void Deactivate()
    {
        isActive = false;
    }

    
}
