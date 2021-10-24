using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealthItem : PickedItem
{
    protected override void GetItem(Collider other)
    {
        HealthManager health;
        if(other.gameObject.TryGetComponent<HealthManager>(out health))
        {
            if(health.NameEntity == "Player" && health.GetCoefficient() != 1f) 
            {
                health.GetHealth(countResources);
                Destroy(gameObject);
            }
        }
    }
}
