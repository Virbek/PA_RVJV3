using Script.Component;
using Script.Game;
using Script.Game.System;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;
using NotImplementedException = System.NotImplementedException;

namespace Script.System
{
    partial struct CollectGoldSystem : ISystem
    {

        public void OnUpdate(ref SystemState state)
        {
            if (NumberRessources.gold <= RessourcesLimit.maxGold)
            {
                foreach (var (timeToCollect, entity) in SystemAPI.Query<RefRW<Collectable>>()
                             .WithAll<IsRessourceGold>()
                             .WithEntityAccess()
                        )
                {
                    timeToCollect.ValueRW.timeToCollect += Time.deltaTime;
                    if (timeToCollect.ValueRO.timeToCollect >= 5.0f)
                    {
                        NumberRessources.gold += 200;
                        timeToCollect.ValueRW.timeToCollect = 0;
                    }
                }
            }
        }
    }
}