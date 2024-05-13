using System.Collections.Generic;
using UnityEngine;

namespace Units
{
    public class UnitSelectManager : MonoBehaviour
    {
    
        public static UnitSelectManager Instance { get; set; }
        public List<GameObject> allUnitsList = new List<GameObject>();
        public List<GameObject> unitsSelected = new List<GameObject>();

        private UnityEngine.Camera _mainCamera;

        public LayerMask clickable;
        public LayerMask ground;
        public LayerMask attackable;
        public GameObject groundMarker;

        public bool attackCursorVisible;
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
                //si on touche un objet clickable
                if (Physics.Raycast(ray, out hit, Mathf.Infinity, ground))
                {
                    groundMarker.transform.position = hit.point;
                    groundMarker.SetActive(false);
                    groundMarker.SetActive(true);
                }
            }

            if (unitsSelected.Count > 0 && AtleasOneOffensiveUnit(unitsSelected))
            {
                RaycastHit hit;
                var ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
                //si on touche un objet clickable
                if (Physics.Raycast(ray, out hit, Mathf.Infinity, attackable))
                {
                    Debug.Log("Enemy Hovered with mouse");

                    attackCursorVisible = true;

                    if (Input.GetMouseButtonDown(1))
                    {
                        Transform target = hit.transform;

                        foreach (GameObject unit in unitsSelected)
                        {
                            if (unit.GetComponent<AttackController>())
                            {
                                unit.GetComponent<AttackController>().targetToAttack = target;
                            }
                            
                        }
                    }
                }
                else
                {
                    attackCursorVisible = false;
                }
            }
        }

        
        
        private bool AtleasOneOffensiveUnit(List<GameObject> gameObjects)
        {
            foreach (GameObject unit in unitsSelected)
            {
                if (unit.GetComponent<AttackController>())
                {
                    return true;
                }
            }
            return false;
        }


        private void MultSelect(GameObject unit)
        {
            if (unitsSelected.Contains(unit) == false)
            {
                unitsSelected.Add(unit);
                SelectUnit(unit, true);
            }
            else
            {
                SelectUnit(unit, false);
                unitsSelected.Remove(unit);
            }
        }

        public void DeselectAll()
        {
            foreach (var unit in unitsSelected)
            {
                SelectUnit(unit, false);
            }
            groundMarker.SetActive(false);
            unitsSelected.Clear();
        }

        private void SelectClick(GameObject unit)
        {
            DeselectAll();
            unitsSelected.Add(unit);
            SelectUnit(unit, true);
        }
        
        public void DragSelect(GameObject unit)
        {
            if (unitsSelected.Contains(unit) == false)
            {
                unitsSelected.Add(unit);
                SelectUnit(unit, true);
            }
        }


        private void SelectUnit(GameObject unit, bool isSelected)
        {
            TriggerSelectIndicator(unit, isSelected);
            EnableUnitMove(unit, isSelected);
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
