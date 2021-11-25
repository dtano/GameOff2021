using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerGenerator : MonoBehaviour
{
    [SerializeField] List<CustomerInformation> potentialCustomers = new List<CustomerInformation>();
    [SerializeField] private List<Trait> possibleTraits = new List<Trait>();
    private List<CustomerInformation> servedCustomers = new List<CustomerInformation>();

    private const int MAX_BASE_STAT_VALUE = 8;
    private const int MIN_BASE_STAT_VALUE = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public CustomerData GenerateCustomerData()
    {
        CustomerInformation chosenCustomerInformation = ChooseRandomCustomer();
        AssignCustomerStats(ref chosenCustomerInformation);
        AssignTraitsToCustomer(chosenCustomerInformation);

        return new CustomerData(chosenCustomerInformation);
    }

    public CustomerInformation ChooseRandomCustomer()
    {
        int randomIndex = Random.Range(0, potentialCustomers.Count);

        CustomerInformation chosenCustomer = potentialCustomers[randomIndex];
        if(potentialCustomers.Remove(chosenCustomer)){
            servedCustomers.Add(chosenCustomer);
        }

        return chosenCustomer;
    }

    private void AssignCustomerStats(ref CustomerInformation customerInformation)
    {
        // Pick a random number between 2 and 8
        AssignRandomValueToStat(customerInformation.Endurance);
        AssignRandomValueToStat(customerInformation.Survivability);
        AssignRandomValueToStat(customerInformation.Intelligence);

    }

    private void AssignTraitsToCustomer(CustomerInformation chosenCustomer)
    {
        // at the moment just add the only trait to the customer immediately
        //chosenCustomer.AddTrait(possibleTraits[0]);
    }

    private void AssignRandomValueToStat(Stat stat)
    {
        int randomStatValue = Random.Range(MIN_BASE_STAT_VALUE, MAX_BASE_STAT_VALUE);
        stat.BaseValue = randomStatValue;
    }
}
