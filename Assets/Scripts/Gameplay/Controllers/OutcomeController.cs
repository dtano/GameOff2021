using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OutcomeController : MonoBehaviour
{
    [SerializeField] AllCustomerStorage servedCustomers;
    [SerializeField] GameObject outcomeBannersParent;
    [SerializeField] TextMeshProUGUI numCustomerSurvivedText;
    
    private OutcomeBanner[] outcomeBanners;
    private int numCustomersSurvived;
    
    // Start is called before the first frame update
    void Start()
    {
        foreach(OutcomeBanner banner in outcomeBanners){
            banner.gameObject.SetActive(false);
        }
        ExecuteSurvivalChances();
    }

    private void OnValidate()
    {
        outcomeBanners = outcomeBannersParent.GetComponentsInChildren<OutcomeBanner>();
    }

    private void ExecuteSurvivalChances()
    {
        List<CustomerData> allServedCustomers = servedCustomers.AllServedCustomers;

        int bannerIndex = 0;
        foreach(CustomerData customer in allServedCustomers){
            OutcomeBanner vacantBanner = outcomeBanners[bannerIndex];
            bool customerSurvivalStatus = DidCustomerSurvive(customer);

            if(customerSurvivalStatus) numCustomersSurvived++;

            PopulateBanner(vacantBanner, customer, customerSurvivalStatus);

            bannerIndex++;
        }

        numCustomerSurvivedText.text = $"{numCustomersSurvived}/{bannerIndex}";
    }

    private void PopulateBanner(OutcomeBanner banner, CustomerData customer, bool customerSurvivalStatus)
    {
        banner.gameObject.SetActive(true);
        banner.SetBanner(customer, customerSurvivalStatus);
    }

    public bool DidCustomerSurvive(CustomerData customer)
    {
        return (Random.Range(0,90) < customer.SurvivalProbability);
    }

    public void Exit()
    {
        servedCustomers?.Clear();
        Application.Quit();
    }
}
