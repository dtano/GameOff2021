using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutcomeUI : MonoBehaviour
{
    private OutcomeBanner[] outcomeBanners;
    
    // Start is called before the first frame update
    void Awake()
    {
        outcomeBanners = GetComponentsInChildren<OutcomeBanner>();
    }

    private void OnValidate()
    {
        outcomeBanners = GetComponentsInChildren<OutcomeBanner>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
