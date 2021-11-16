using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCustomerDataDisplay : MonoBehaviour
{
    [SerializeField] Customer _customer;
    [SerializeField] Trait traitObject;
    // Start is called before the first frame update
    void Awake()
    {
        _customer = GetComponent<Customer>();
        // Make a CustomerData object
        CustomerData data = new CustomerData("Billy Summers", 3,4,1,5);
        _customer.CustomerData = data;
    }
}
