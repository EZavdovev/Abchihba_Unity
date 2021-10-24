using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public abstract class PickedItem : MonoBehaviour
{
    [SerializeField]
    protected int countResources;
    [SerializeField]
    protected float speedRotation;
    private void OnTriggerEnter(Collider other)
    {
        GetItem(other);   
    }

    private void OnTriggerStay(Collider other)
    {
        GetItem(other);
    }
    protected virtual void Update()
    {
        transform.Rotate(new Vector3(0, speedRotation * Time.deltaTime,0));
    }
    
    protected abstract void GetItem(Collider other);
}
