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
        [SerializeField] private GameObject menu;
        [SerializeField] private GameObject optionsPanel;
       
        

        void Start()
        {
            GameStat.hasSpawnBat = false;
            GameStat.collecteur = 0;
            GameStat.countSpawn = 0;
            GameStat.caserne = 0;
            GameStat.maxCollecteur = 3;
            GameStat.maxCaserne = 1;
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
            World.DefaultGameObjectInjectionWorld.EntityManager.CreateSingleton<WantToSpawn>();
            NumberUnit.unitToSpawn = 0;
            RessourcesLimit.maxGold = 1500;
            GameStat.collecteur = 1;
            GameStat.caserne += 1;
            GameStat.NiveauHdv = 3;
            GameStat.Niveau =3;
            GameStat.positionColl[0] = new float3(0.05f, 0.07f, 0.47f);
            SceneManager.LoadScene("BaseScene", LoadSceneMode.Additive);
            SceneManager.LoadScene("SampleScene");
        }

        public void Quit()
        {
            Application.Quit();
        }

        public void Update()
        {
            GameStat.collecteur = 1;
            GameStat.maxCollecteur = 3;
            GameStat.NiveauHdv = 3;
            GameStat.Niveau = 3;
            NumberRessources.gold = 0;
            NumberRessources.charbon = 0;
            NumberUnit.guerrier = 0;
            NumberUnit.archer = 0;
            NumberUnit.geant = 0;
            NumberUnit.bat = 0;
        
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                optionsPanel.SetActive(false);
                menu.SetActive(true);
                
            }
        }
        
    }
}
