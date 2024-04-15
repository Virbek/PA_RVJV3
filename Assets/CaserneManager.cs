using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaserneManager : MonoBehaviour
{
    [SerializeField] private GameObject ui;
    private UnityEngine.Camera _mainCamera;
    [SerializeField]private LayerMask caserne;

    private void Start()
    {
        _mainCamera = UnityEngine.Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            var ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, caserne))
            {
                if (ui.activeInHierarchy)
                {
                    ui.SetActive(false);
                }
                else
                {
                    ui.SetActive(true);
                }
            }
        }
    }

    public void CreateUnit(GameObject unit)
    {
        var newUnit = Instantiate(unit, transform.position, Quaternion.identity);
    }
}
