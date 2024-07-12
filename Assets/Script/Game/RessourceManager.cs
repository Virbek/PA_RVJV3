using UnityEngine;
using UnityEngine.UI;

namespace Script.Game
{
    public class RessourceManager : MonoBehaviour
    {
        [SerializeField] private Text gold;
        [SerializeField] private Text charbon;
        [SerializeField] private Text bois;
        [SerializeField] private int nombreGold;
        [SerializeField] private int nombreCharbon;
    


        private void Update()
        {
            nombreGold = NumberRessources.gold;
            nombreCharbon = NumberRessources.charbon; 
            gold.text = nombreGold.ToString();
            charbon.text = nombreCharbon.ToString();
            bois.text = NumberRessources.bois.ToString();
        }
    
    
    }
}
