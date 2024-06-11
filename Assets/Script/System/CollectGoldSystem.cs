using Script.Component;
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
            foreach (var (timeToCollect, entity) in SystemAPI.Query<RefRW<Collectable>>()
                         .WithAll<IsRessourceGold>()
                         .WithEntityAccess()
                    )
            {
                timeToCollect.ValueRW.timeToCollect += Time.deltaTime;
                if (timeToCollect.ValueRO.timeToCollect > 30f)
                {
                    RessourceManager.Instance.AddGold(50);
                    timeToCollect.ValueRW.timeToCollect = 0;
                }
            }
        }
    }
}