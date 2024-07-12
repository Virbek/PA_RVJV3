using Script.Component;
using Script.Game.System;
using Script.System;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

namespace Script.Game
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GameObject troupes;
        private int nombreUnit;
        [SerializeField] private GameObject WinUI;
        [SerializeField] private GameObject LooseUI;
        [SerializeField] private GameObject Fin;
        [SerializeField] private Text Temps;
        [SerializeField] private Text Destruction;
        private float timeToPlay;
        private float _inGameTime;
        private bool visible;
        private int _batT;
        private bool batCheck;
        private string tempsFormate;
        private int percent;

        private void Start()
        {
            visible = true;
            _inGameTime = 59.0f;
            batCheck = false;
        }

        public void Update()
        {
            SpawnLevel();
            
            if (NumberUnit.bat != 0 && !batCheck)
            {
                _batT = NumberUnit.bat;
                batCheck = true;
            }
            //Affichage du chrono en haut de l'ecran
            var min = Mathf.FloorToInt(_inGameTime / 60f);
            var sec = _inGameTime % 60f;
            tempsFormate = string.Format("{0}:{1:00}", min, sec);
            Temps.text = tempsFormate;
            if (!tempsFormate.Equals("0:00"))
            {
                _inGameTime -= Time.deltaTime;
            }

            percent = 0;
            //affichage du taux de destruction des batimment;
            if (_batT != 0)
            {
                percent = NumberUnit.bat * 100;
                percent /= _batT;
                percent = 100 - percent;
            }
            Destruction.text = percent.ToString() + "%";
            
            timeToPlay += Time.deltaTime;
            nombreUnit = NumberUnit.guerrier + NumberUnit.archer + NumberUnit.geant + NumberUnit.ballon+ NumberUnit.ballonDef;
            if (nombreUnit == 0 || tempsFormate.Equals("0:00")) 
            {
                timeToPlay += Time.deltaTime;
                if (timeToPlay >= 1f)
                {
                    if (visible)
                    {
                        NumberRessources.charbon += percent;
                        LooseUI.SetActive(true);
                        visible = false;
                        Time.timeScale = 0;
                    }
                
                }
            }

            if (NumberUnit.bat == 0)
            {
                timeToPlay += Time.deltaTime;
                if (timeToPlay >= 1f)
                {
                    if (visible)
                    {
                        GameStat.Niveau += 1;
                        NumberUnit.unitToSpawn = nombreUnit;
                        if (GameStat.Niveau < 5)
                        {
                            NumberRessources.charbon += percent;
                            WinUI.SetActive(true);
                            visible = false;
                            Time.timeScale = 0;
                        }
                        else
                        {
                            Fin.SetActive(true);
                            visible = false;
                            Time.timeScale = 0;
                        }
                        
                    }
                }
            } 
            
        
        }

        public void RetourBase()
        {
            timeToPlay = 0;
            visible = true;
            _inGameTime = 59.0f;
            batCheck = false;
            var newTroupes = Instantiate( troupes, transform.position,Quaternion.identity);
            newTroupes.transform.SetParent(SceneControler.Instance.BaseScene.transform, true);
            SceneControler.Instance.Troupes = newTroupes;
            WinUI.SetActive(false);
            LooseUI.SetActive(false);
            GameStat.hasSpawnBat = false;
            GameStat.countSpawn = 0;
            Time.timeScale = 1;
            SceneControler.Instance.InvokeDestroyer(new Vector3());
            SceneControler.Instance.Niveau1.SetActive(false);
            SceneControler.Instance.BaseScene.SetActive(true);
        }

        public void FinJeu()
        {
            timeToPlay = 0;
            Fin.SetActive(false);
            visible = true;
            _inGameTime = 59.0f;
            batCheck = false;
            Time.timeScale = 1;
            SceneControler.Instance.Niveau1.SetActive(false);
            SceneControler.Instance.MenuScene.SetActive(true);
        }
        
        public void ShareToTwitter()
        {
            string message = "Regarder ce que j'ai reussi sur For Glory. J'ai fais le "
                             + SceneControler.Instance.Niveau1.tag +" En "
                             + tempsFormate+" en ayant détruit " + percent.ToString()
                             +"% des batiments. Incroyable !!!";
            string url = "https://twitter.com/intent/tweet?text=" + UnityEngine.Networking.UnityWebRequest.EscapeURL(message);
            Application.OpenURL(url);
        }

        private void SpawnLevel()
        {
            if (GameStat.levelHasSpawn)
            {
                if (GameStat.level == 1)
                {
                    SceneControler.Instance.InvokeLevel1(new Vector3(0,0,0));
                    GameStat.levelHasSpawn = false; 
                }

                if (GameStat.level == 2)
                {
                    SceneControler.Instance.InvokeLevel2(new Vector3(0,0,0));
                    GameStat.levelHasSpawn = false; 
                }
                if (GameStat.level == 3)
                {
                    SceneControler.Instance.InvokeLevel3(new Vector3(0,0,0));
                    GameStat.levelHasSpawn = false; 
                }

                if (GameStat.level == 4)
                {
                    SceneControler.Instance.InvokeLevel4(new Vector3(0,0,0));
                    GameStat.levelHasSpawn = false; 
                }
            }
        }
    }
}
