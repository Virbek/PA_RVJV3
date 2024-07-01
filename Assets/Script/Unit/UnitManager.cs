using System;
using System.Collections;
using System.Collections.Generic;
using Script.Component;
using Script.Game;
using Unity.Entities;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UnitManager : MonoBehaviour
{
    private void Update()
    {
        NumberUnit.numberUnitInCamp = GameStat.caserne * 50;
    }

    public void Niveau1()
    {
        SceneManager.LoadScene("CombatScene");
    }
    
    public void Niveau2()
    {
        SceneManager.LoadScene("Niveau2Scene");
    }
    
    
    
    
    
}
