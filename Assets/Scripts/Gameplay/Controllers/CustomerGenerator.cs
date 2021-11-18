using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerGenerator : MonoBehaviour
{
    [SerializeField] List<CustomerInformation> potentialCustomers = new List<CustomerInformation>();
    private List<CustomerInformation> servedCustomers = new List<CustomerInformation>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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

    public CustomerData GenerateCustomerData()
    {
        // Pick a random customer from the potentialCustomers
        return new CustomerData("Gordon Ramsay", 5, 2, 3, 4);
    }
}
