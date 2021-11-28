using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

// Controls the main gameplay loop
public class GameController : MonoBehaviour
{
    [SerializeField] Customer customer;
    [SerializeField] SurvivalKit survivalKit;
    [SerializeField] CustomerUI customerUI;
    [SerializeField] ShopInventory shopInventory;
    // This is where you store the data of customers who have been served
    [SerializeField] AllCustomerStorage customerHistory;
    [SerializeField] private int totalCustomers;

    CustomerGenerator customerGenerator;
    UIController mainUIController;
    private int numCustomersServed = 0;
    private bool hasHandledSurvivalChances = false;

    
    
    // Start is called before the first frame update
    void Start()
    {
        customerHistory?.Clear();
        customerGenerator = GetComponent<CustomerGenerator>();
        mainUIController = GetComponent<UIController>();

        //PrepareForNewCustomer();
        mainUIController.HideUIElements();
    }

    public async void StartGame()
    {
        await CustomerArrival();
    }

    // Update is called once per frame
    void Update()
    {
        if(IsGameOver() && !hasHandledSurvivalChances)
        {
            EndSequence();
        }
    }

    // Means that its time to store the customer data in the storage and generate a new one
    public async void FinishServingCustomer()
    {
        if(!IsGameOver() && survivalKit.IsEligibleForCustomer()){
            await HandleCustomerLeaving();
            
            Debug.Log("Transition over");

            if(numCustomersServed < totalCustomers){
                // Generate new customer data
                await CustomerArrival();
            }
        }


    }

    public async Task CustomerArrival()
    {
        PrepareForNewCustomer();
        await CustomerEnterSequence();
        
        Debug.Log($"New customer has entered: {customer.CustomerData.Name}");
    }

    private async Task HandleCustomerLeaving()
    {
        survivalKit.Clear();
        // Store customer data in customer history
        customerHistory.AddCustomerData(customer.CustomerData);
        numCustomersServed++;

        mainUIController?.HideBackpackUI();
        customerUI?.MakeCustomerLeaveStore();
        //mainUIController?.ServeBag();
        
        // wait for transition 
        await CustomerTransition(2f);

    }

    private void PrepareForNewCustomer()
    {
        // Alternate
        // Instantiate CustomerData using preset CustomerInformation scriptable object
        CustomerData chosenCustomerData = customerGenerator.GenerateCustomerData();
        customer.CustomerData = chosenCustomerData;

        survivalKit.SetAffectedCustData(customer.CustomerData);

        // // Reset all items
        shopInventory.ResetItemEffects();
        //mainUIController?.GetNewBag();
        // customerUI?.EnterNewCustomer();
        // // Notify ui
        // await CustomerTransition(2f);

        // customerUI?.ShowUIElements();
    }

    private async Task CustomerEnterSequence()
    {
        customerUI?.EnterNewCustomer();
        // Notify ui
        await CustomerTransition(2f);

        customerUI?.ShowUIElements();
        mainUIController?.ShowBackpackUI();
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
        
        ExecuteSurvivalChances();

    }

    private void ExecuteSurvivalChances()
    {
        List<CustomerData> allServedCustomers = customerHistory.AllServedCustomers;

        foreach(CustomerData customer in allServedCustomers){
            Debug.Log($"{customer.Name} - {customer.SurvivalProbability}");
            if(Random.Range(0,80) < customer.SurvivalProbability){
                Debug.Log($"{customer.Name} survived!");
            }else{
                Debug.Log($"{customer.Name} died!");
            }
        }

        hasHandledSurvivalChances = true;
    }

    public bool IsGameOver()
    {
        return numCustomersServed == totalCustomers;
    }

    
}
