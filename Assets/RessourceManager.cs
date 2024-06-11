using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RessourceManager : MonoBehaviour
{
    public static RessourceManager Instance { get; private set; }
    [SerializeField] private Text gold;
    [SerializeField]
    private int nombreGold;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddGold(int gold)
    {
        nombreGold += gold;
        this.gold.text = nombreGold.ToString();

    }

    public int GetGold()
    {
        return nombreGold;
    }
    
}
