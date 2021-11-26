using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface ITrait
{
    string Name {get;}
    string Description {get; set;}
    void Apply(Customer customer);
}
