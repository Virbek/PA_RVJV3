using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int nombreUnit;
    [SerializeField] private GameObject WinUI;
    [SerializeField] private GameObject LooseUI;
    private float timeToPlay;
    
    void Update()
    {
        timeToPlay += Time.deltaTime;
        nombreUnit = NumberUnit.guerrier + NumberUnit.archer + NumberUnit.geant;
        if (timeToPlay >= 1f)
        {
            if (nombreUnit == 0) 
            {
                LooseUI.SetActive(true);
            }

            if (NumberUnit.bat == 0)
            {
                WinUI.SetActive(true);
            } 
        }
        
    }

    public void RetourBase()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
