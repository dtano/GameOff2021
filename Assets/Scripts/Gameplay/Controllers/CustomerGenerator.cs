using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerGenerator : MonoBehaviour
{

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
        return new CustomerData("Gordon Ramsay", 5, 2, 3, 4);
    }
}