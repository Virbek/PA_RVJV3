using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    [SerializeField] private GameObject mainCamera;

    [SerializeField] private GameObject cameraDessus;
    // Start is called before the first frame update
    void Start()
    {
        cameraDessus.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (cameraDessus.activeSelf)
            {
                cameraDessus.SetActive(false);
                mainCamera.SetActive(true);
            }
            else
            {
                mainCamera.SetActive(false);
                cameraDessus.SetActive(true);
            }
        }
    }
}
