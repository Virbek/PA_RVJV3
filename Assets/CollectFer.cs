using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectFer : MonoBehaviour
{
    [SerializeField] private List<GameObject> _unitIn = new List<GameObject>(2);
    private float _startCollect = 0f;
    private float _endCollect = 5f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_startCollect >= _endCollect)
        {
            RessourcesManager.Instance.ModifNombreFer(200);
            _startCollect = 0f;
            _unitIn[0].transform.position = transform.position + new Vector3(-2, 0, 0);
            _unitIn[0].gameObject.SetActive(true);
            _unitIn.Remove(_unitIn[0]);
            
        }

        if (_unitIn.Count != 0)
        {
            _startCollect += Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("Unit"))
        {
            _unitIn.Add(other.gameObject);
            other.gameObject.SetActive(false);
        }
    }
    
}
