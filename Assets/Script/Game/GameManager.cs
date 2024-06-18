using UnityEngine;
using UnityEngine.SceneManagement;

namespace Script.Game
{
    public class GameManager : MonoBehaviour
    {
        private int nombreUnit;
        [SerializeField] private GameObject WinUI;
        [SerializeField] private GameObject LooseUI;
        [SerializeField] private GameObject Fin;
        private float timeToPlay;
        private bool visible;

        private void Start()
        {
            visible = true;
        }

        void Update()
        {
            timeToPlay += Time.deltaTime;
            nombreUnit = NumberUnit.guerrier + NumberUnit.archer + NumberUnit.geant;
            if (timeToPlay >= 1f)
            {
                if (nombreUnit == 0) 
                {
                    timeToPlay += Time.deltaTime;
                    if (timeToPlay >= 1f)
                    {
                        if (visible)
                        {
                            NumberRessources.charbon += 25;
                            LooseUI.SetActive(true);
                            visible = false;
                        }
                    
                    }
                }

                if (NumberUnit.bat == 0)
                {
                    timeToPlay += Time.deltaTime;
                    GameStat.Niveau += 1;
                    if (timeToPlay >= 1f)
                    {
                        if (visible)
                        {
                            if (GameStat.Niveau < 3)
                            {
                                NumberRessources.charbon += 100;
                                WinUI.SetActive(true);
                                visible = false;
                            }
                            else
                            {
                                Fin.SetActive(true);
                            }
                        
                        }
                    }
                } 
            }
        
        }

        public void RetourBase()
        {
            SceneManager.LoadScene("SampleScene");
        }

        public void FinJeu()
        {
            SceneManager.LoadScene("MenuScene");
        }
    }
}
