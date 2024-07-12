using System.Collections.Generic;
using Script.Component;
using Script.Game.System;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Script.Game
{
    public class MenuController : MonoBehaviour
    {
        [SerializeField] private GameObject MenuScene;
        [SerializeField] private GameObject BaseScene;
        [SerializeField] private GameObject menu;
        [SerializeField] private GameObject optionsPanel;
        [SerializeField] private GameObject troupes;
       
        

        void Start()
        {
            World.DefaultGameObjectInjectionWorld.EntityManager.CreateSingleton<WantToSpawn>();
            GameStat.hasSpawnBat = false;
            GameStat.collecteur = 0;
            GameStat.countSpawn = 0;
            GameStat.cabane = 0;
            GameStat.countCabSpawn = 0;
            GameStat.caserne = 0;
            GameStat.maxCollecteur = 3;
            GameStat.maxCaserne = 1;
            GameStat.maxCabane = 2;
        }

        public void Option()
        {
            if (menu != null && optionsPanel != null)
            {
                menu.SetActive(false);
                optionsPanel.SetActive(true);
            }
        }

        public void Jouer()
        {
            if (!GameStat.hasSpawn)
            {
                GameStat.hasSpawn = true;
            }

            var newTroupes = Instantiate(troupes, transform.position,Quaternion.identity);
            newTroupes.transform.SetParent(SceneControler.Instance.BaseScene.transform, true);
            SceneControler.Instance.InvokeTree(new Vector3(1,2,1));
            SceneControler.Instance.Troupes = newTroupes;
            GameStat.countSpawn = 0;
            GameStat.countCabSpawn = 0;
            NumberUnit.unitToSpawn = 0;
            RessourcesLimit.maxGold = 1500;
            GameStat.cabane = 0;
            GameStat.collecteur = 1;
            GameStat.caserne = 1;
            GameStat.NiveauHdv = 1;
            GameStat.Niveau = 1;
            GameStat.positionColl[0] = new float3(0.05f, 0.07f, 0.47f);
            MenuScene.SetActive(false);
            BaseScene.SetActive(true);
        }

        public void Quit()
        {
            Application.Quit();
        }

        public void Update()
        {
            GameStat.collecteur = 1;
            GameStat.cabane = 0;
            GameStat.maxCollecteur = 3;
            GameStat.maxCaserne = 1;
            GameStat.maxCabane = 2;
            GameStat.NiveauHdv = 1;
            GameStat.Niveau = 1;
            NumberRessources.gold = 0;
            NumberRessources.charbon = 0;
            NumberRessources.bois = 0;
            NumberUnit.guerrier = 0;
            NumberUnit.archer = 0;
            NumberUnit.geant = 0;
            NumberUnit.ballon = 0;
            NumberUnit.ballonDef = 0;
            NumberUnit.bat = 0;
        
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                optionsPanel.SetActive(false);
                menu.SetActive(true);
                
            }
        }
        
    }
}
