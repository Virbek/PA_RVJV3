using UnityEngine;

namespace Units
{
    public class Unit : MonoBehaviour
    {
    
        // Start is called before the first frame update
        void Start()
        {
            UnitSelectManager.Instance.allUnitsList.Add(gameObject); 
        
        }

        private void OnDestroy()
        {
            UnitSelectManager.Instance.allUnitsList.Remove(gameObject); 
        }
    }
}
