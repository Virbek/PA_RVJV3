using System;
using System.Collections;
using System.Collections.Generic;
using Units;
using Unity.VisualScripting;
using UnityEngine;

public class CollectFer : MonoBehaviour
{
    public double fer;


    private void Start()
    {
        fer = gameObject.GetComponent<RessourcesIn>().nombreFer;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<RessourcesIn>().nombreFer == 0)
        {
            other.gameObject.GetComponent<GoDestination>().enabled = false;
            other.gameObject.GetComponent<Collect>().enabled = true;
            other.gameObject.GetComponent<Collect>().ressources = gameObject;  
        }
    }

    private void OnCollisionExit(Collision other)
    {
        fer = gameObject.GetComponent<RessourcesIn>().nombreFer;
    }

    // Update is called once per frame
    void Update()
    {
        if (fer == 0)
        {
            Destroy(gameObject);
        }
    }
    
}
