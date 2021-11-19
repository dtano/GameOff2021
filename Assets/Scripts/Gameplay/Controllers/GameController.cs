using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

// Controls the main gameplay loop
public class GameController : MonoBehaviour
{
    [SerializeField] Customer customer;
    [SerializeField] SurvivalKit survivalKit;
    // This is where you store the data of customers who have been served
    [SerializeField] AllCustomerStorage customerHistory;
    [SerializeField] private int totalCustomers;

    CustomerGenerator customerGenerator;
    private int numCustomersServed = 0;

    
    
    // Start is called before the first frame update
    void Awake()
    {
        customerHistory?.Clear();
        customerGenerator = GetComponent<CustomerGenerator>();

        PrepareForNewCustomer();
    }

    // Update is called once per frame
    void Update()
    {
        if(numCustomersServed == totalCustomers)
        {
            EndSequence();
        }
    }

    // Means that its time to store the customer data in the storage and generate a new one
    public async void FinishServingCustomer()
    {
        if(survivalKit.IsEligibleForCustomer()){
            // Store customer data in customer history
            customerHistory.AddCustomerData(customer.CustomerData);
            numCustomersServed++;

            // wait for transition 
            await CustomerTransition(2f);

            Debug.Log("Transition over");

            // Generate new customer data
            PrepareForNewCustomer();

            await CustomerTransition(2f);

            Debug.Log($"New customer has entered: {customer.CustomerData.Name}");
        }


    }

    private void PrepareForNewCustomer()
    {
        // Generate new customer data
        // CustomerData newCustomerData = customerGenerator.GenerateCustomerData();
        // customer.CustomerData = newCustomerData;

        // Alternate
        // Instantiate CustomerData using preset CustomerInformation scriptable object
        CustomerData chosenCustomerData = new CustomerData(customerGenerator.ChooseRandomCustomer());
        customer.CustomerData = chosenCustomerData;

        survivalKit.Clear();
        survivalKit.SetAffectedCustData(customer.CustomerData);

        // Reset all items
        // shopInventory.ResetItemEffects();
    }

    
    private async Task CustomerTransition(float duration)
    {
        var end = Time.time + duration;

        while(Time.time < end){
            await Task.Yield();
        }
    }

    public void EndSequence()
    {
        Debug.Log("All customers served, time to end the game");
    }

    
}
