using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectFer : MonoBehaviour
{
    [SerializeField] private List<GameObject> unitIn = new List<GameObject>(2);
    [SerializeField] private int nombreFer = 1000;
    

    private void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("Unit") && unitIn.Count < 5)
        {
            unitIn.Add(other.gameObject);
        }
    }
    
}
