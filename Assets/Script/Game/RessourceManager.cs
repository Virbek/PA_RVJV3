using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RessourceManager : MonoBehaviour
{
    [SerializeField] private Text gold;
    [SerializeField] private Text charbon;
    [SerializeField] private int nombreGold;
    [SerializeField] private int nombreCharbon;
    


    private void Update()
    {
        nombreGold = NumberRessources.gold;
        nombreCharbon = NumberRessources.charbon; 
        gold.text = nombreGold.ToString();
        charbon.text = nombreCharbon.ToString();
    }
    
    
}
