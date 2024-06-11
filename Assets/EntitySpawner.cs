using System.Collections;
using System.Collections.Generic;
using Script.Component;
using Unity.Entities;
using UnityEngine;

public class EntitySpawner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        World.DefaultGameObjectInjectionWorld.EntityManager.CreateSingleton<WantToSpawn>();
    }

    // Update is called once per frame
    void Update()
    {
        
        var query = World.DefaultGameObjectInjectionWorld.EntityManager.CreateEntityQuery(
            typeof(WantToSpawn)
        );

        query.SetSingleton(new WantToSpawn()
        {
            wantToSpawn = true
        });
        
    }
}
