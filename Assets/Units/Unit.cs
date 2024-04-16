using System;
using UnityEngine;

namespace Units
{
    public class Unit : MonoBehaviour
    {
        public bool onCollect = false;
        public bool recup = false;
        [SerializeField] private int enPoche;
    
        // Start is called before the first frame update
        void Start()
        {
            UnitSelectManager.Instance.allUnitsList.Add(gameObject); 
        
        }

        private void Update()
        {
            if (onCollect)
            {
                OnCollect();
            }

            if (recup)
            {
                Recup();
            }
        }

        private void OnDestroy()
        {
            UnitSelectManager.Instance.allUnitsList.Remove(gameObject); 
        }

        private void OnCollect()
        {
            
        }

        private void Recup()
        {
            
        }
    }
}
