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
        NumberUnit.numberUnitInCamp = GameStat.caserne * 100;
    }

    public void Niveau1()
    {
        Destroy(SceneControler.Instance.Troupes);
        SceneControler.Instance.InvokeDestroyer(new Vector3());
        GameStat.startBattle = true;
        GameStat.levelHasSpawn = true;
        GameStat.level = 1;
        SceneControler.Instance.BaseScene.SetActive(false);
        SceneControler.Instance.Niveau1.SetActive(true);
    }
    
    public void Niveau2()
    {
        Destroy(SceneControler.Instance.Troupes);
        SceneControler.Instance.InvokeDestroyer(new Vector3());
        GameStat.startBattle = true;
        GameStat.levelHasSpawn = true;
        GameStat.level = 2;
        SceneControler.Instance.BaseScene.SetActive(false);
        SceneControler.Instance.Niveau1.SetActive(true);
    }
    
    public void Niveau3()
    {
        Destroy(SceneControler.Instance.Troupes);
        SceneControler.Instance.InvokeDestroyer(new Vector3());
        GameStat.startBattle = true;
        GameStat.levelHasSpawn = true;
        GameStat.level = 3;
        SceneControler.Instance.BaseScene.SetActive(false);
        SceneControler.Instance.Niveau1.SetActive(true);
    }
    
    public void Niveau4()
    {
        Destroy(SceneControler.Instance.Troupes);
        SceneControler.Instance.InvokeDestroyer(new Vector3());
        GameStat.startBattle = true;
        GameStat.levelHasSpawn = true;
        GameStat.level = 4;
        SceneControler.Instance.BaseScene.SetActive(false);
        SceneControler.Instance.Niveau1.SetActive(true);
    }
    
    
    
    
    
}
