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
        var nombreUnit = 0;
        var nombreBat = 0;
        foreach (var (unitTransform, unitEntity) 
                     in SystemAPI.Query<RefRO<LocalTransform>>()
                         .WithAll<IsUnit>()
                         .WithEntityAccess()
                 )
        {
            nombreUnit += 1;
        }
        foreach (var (batTransform, batEntity) 
                 in SystemAPI.Query<RefRO<LocalTransform>>()
                     .WithAll<IsBat>()
                     .WithEntityAccess()
                )
        {
            nombreBat += 1;
        }

        if (nombreUnit == 0)
        {
            return;
        }
        
        if(nombreBat == 0)
        {
            return;
        }
    }
}
