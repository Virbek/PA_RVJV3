using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Units
{
    public class UnitSelectManager : MonoBehaviour
    {
    
        public static UnitSelectManager Instance { get; set; }
        public List<GameObject> allUnitsList = new List<GameObject>();
        public List<GameObject> unitsSelected = new List<GameObject>();


        public GameObject Hdv;
        
        private UnityEngine.Camera _mainCamera;

        public LayerMask clickable;
        public LayerMask ground;
        public LayerMask ressources;
        public GameObject groundMarker;
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

        private void Start()
        {
            _mainCamera = UnityEngine.Camera.main;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                var ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
                //si on touche un objet clickable
                if (Physics.Raycast(ray, out hit, Mathf.Infinity, clickable))
                {
                    if (Input.GetKey(KeyCode.LeftShift))
                    {
                        MultSelect(hit.collider.gameObject);
                    }
                    else
                    {
                        SelectClick(hit.collider.gameObject);
                    }
                }
                else //si on touche aucun objet clickable
                {
                    if (Input.GetKey(KeyCode.LeftShift) == false)
                    {
                        DeselectAll();
                    }
                }
            }


            if (Input.GetMouseButtonDown(1) && unitsSelected.Count > 0)
            {
                RaycastHit hit;
                var ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
                if(Physics.Raycast(ray, out hit, Mathf.Infinity, ressources))
                {
                    foreach (var unit in unitsSelected)
                    {
                        var collect = unit.GetComponent<InCollect>();
                        if (!collect)
                        {
                            unit.GetComponent<GoDestination>().target = hit.transform.position;
                            unit.GetComponent<GoDestination>().enabled = true;
                        }
                    }
                }else if (Physics.Raycast(ray, out hit, Mathf.Infinity, ground))
                {
                    groundMarker.transform.position = hit.point;
                    groundMarker.SetActive(false);
                    groundMarker.SetActive(true);
                }
            }
        }

        private void MultSelect(GameObject unit)
        {
            if (unitsSelected.Contains(unit) == false)
            {
                unitsSelected.Add(unit);
                EnableUnitMove(unit, true);
                TriggerSelectIndicator(unit, true);
            }
            else
            {
                EnableUnitMove(unit, false);
                TriggerSelectIndicator(unit, false);
                unitsSelected.Remove(unit);
            }
        }

        private void DeselectAll()
        {
            foreach (var unit in unitsSelected)
            {
                EnableUnitMove(unit, false);
                TriggerSelectIndicator(unit, false);
            }
            groundMarker.SetActive(false);
            unitsSelected.Clear();
        }

        private void SelectClick(GameObject unit)
        {
            DeselectAll();
            unitsSelected.Add(unit);
            TriggerSelectIndicator(unit, true);
            EnableUnitMove(unit, true);
        }

        private void EnableUnitMove(GameObject unit, bool canMove)
        {
            unit.GetComponent<DeplacementUnit>().enabled = canMove;
        }

        private void TriggerSelectIndicator(GameObject unit, bool isSelected)
        {
            unit.transform.GetChild(0).gameObject.SetActive(isSelected);
        }
    }
}
