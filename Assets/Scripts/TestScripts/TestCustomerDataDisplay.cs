using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCustomerDataDisplay : MonoBehaviour
{
    [SerializeField] Customer _customer;
    [SerializeField] TraitObject traitObject;
    // Start is called before the first frame update
    void Start()
    {
        _customer = GetComponent<Customer>();
        // Make a CustomerData object
        CustomerData data = new CustomerData("Billy Summers", 3,4,1,5);
        //Trait trait = new Trait(traitObject);

        //data.AddTrait(trait);
        _customer.SetData(data);
    }
}
