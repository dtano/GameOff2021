using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutcomeController : MonoBehaviour
{
    [SerializeField] AllCustomerStorage servedCustomers;
    [SerializeField] GameObject outcomeBannersParent;
    
    private OutcomeBanner[] outcomeBanners;
    
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

            PopulateBanner(vacantBanner, customer, customerSurvivalStatus);

            // Debug.Log($"{customer.Name} - {customer.SurvivalProbability}");
            // if(customerSurvivalStatus){
            //     Debug.Log($"{customer.Name} survived!");
            // }else{
            //     Debug.Log($"{customer.Name} died!");
            // }
            bannerIndex++;
        }
    }

    private void PopulateBanner(OutcomeBanner banner, CustomerData customer, bool customerSurvivalStatus)
    {
        banner.gameObject.SetActive(true);
        banner.SetBanner(customer, customerSurvivalStatus);
    }

    public bool DidCustomerSurvive(CustomerData customer)
    {
        return (Random.Range(0,80) < customer.SurvivalProbability);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
