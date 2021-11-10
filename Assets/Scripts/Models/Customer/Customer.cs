using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    // SHOULD HAVE:
    // - Name
    // - List of traits
    // - Stats
    // A customer will be randomly generated by another script, which means that the variables below may be added to another script called CustomerData
    
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] SurvivalKit _survivalKit;

    // Maybe CustomerData should be a mono
    [SerializeField] private CustomerData _data;
    private float _survivabilityScore; // Will be a percentage in game

    // Start is called before the first frame update
    void Start()
    {
        //spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _survivalKit = GetComponent<SurvivalKit>();
        _survivalKit?.SetAffectedCustData(_data);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SetData(CustomerData data)
    {
        _data = data;
        Debug.Log(_data);
    }

    public SurvivalKit GetSurvivalKit()
    {
        return _survivalKit;
    }

    public CustomerData GetCustomerData()
    {
        return _data;
    }


}
