using System.Collections;
using System.Collections.Generic;
using Script.Component;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

partial struct GameSystem : ISystem
{
    public void OnUpdate(ref SystemState state)
    {
        var nombreBat = 0;
        foreach (var (batTransform, batEntity) 
                 in SystemAPI.Query<RefRO<LocalTransform>>()
                     .WithAll<IsBat>()
                     .WithEntityAccess()
                )
        {
            nombreBat += 1;
        }
        NumberUnit.bat = nombreBat;
        
    }
}
