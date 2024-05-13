using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class RessourcesManager : MonoBehaviour
{
    public static RessourcesManager Instance { get; set; }

    private double _numberFer;
    private int _numberHuman;
    private double _numberCharbon;

    [SerializeField] private Text nombreFer;
    [SerializeField] private Text nombreCharbon;

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
        _numberCharbon = 0;
        nombreFer.text = _numberFer.ToString();
    }

    public void ModifNombreFer(double fer)
    {
        _numberFer = _numberFer + fer;
        nombreFer.text = _numberFer.ToString();

    }

    public double GetNombreFer()
    {
        return _numberFer;
    }
    
    public void ModifNombreCharbon(double charbon)
    {
        _numberCharbon = _numberCharbon + charbon;
        nombreCharbon.text = _numberCharbon.ToString();

    }

    public double GetNombreCharbon()
    {
        return _numberCharbon;
    }

}
