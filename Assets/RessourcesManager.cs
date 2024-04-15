using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class RessourcesManager : MonoBehaviour
{
    public static RessourcesManager Instance { get; set; }

    private int _numberFer;
    private int _numberHuman;

    [SerializeField] private Text nombreFer;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
        _numberFer = 200;
        nombreFer.text = _numberFer.ToString();
    }

    public void ModifNombreFer(int fer)
    {
        _numberFer = _numberFer + fer;
        nombreFer.text = _numberFer.ToString();

    }

    public int GetNombreFer()
    {
        return _numberFer;
    }

}
