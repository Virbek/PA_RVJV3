using Script.Component;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics;
using Unity.Transforms;
using UnityEngine;
using NotImplementedException = System.NotImplementedException;

namespace Script.System
{
    [BurstCompile]
    public partial struct FarmSystem : ISystem
    {

        public void OnUpdate(ref SystemState state)
        {
            var ecb = new EntityCommandBuffer(Allocator.Temp);

            foreach (var (delay, degat, target,timeDelayAttack, home, entity)
                     in SystemAPI.Query<RefRW<DelayAttack>, RefRO<Puissance>, RefRW<Target>, RefRO<TimeDelayAttack>, RefRO<Home>>()
                         .WithAll<OnAttack>()
                         .WithAll<IsFarmer>()
                         .WithEntityAccess()
                    )
            {
                var targetEntity = target.ValueRO.target;
                if (state.EntityManager.HasComponent<Disabled>(targetEntity))
                {
                    ecb.RemoveComponent<OnAttack>(entity);
                    ecb.RemoveComponent<Target>(entity);
                    continue;
                }
                
                delay.ValueRW.delayAttack += Time.deltaTime;
                var targetPv = state.EntityManager.GetComponentData<NombrePv>(targetEntity);
                if (delay.ValueRO.delayAttack >= timeDelayAttack.ValueRO.timeDelayAttack){
                    targetPv.pv -= degat.ValueRO.puissance;
                    state.EntityManager.SetComponentData(targetEntity, targetPv);
                    delay.ValueRW.delayAttack = 0;
                }

                if (targetPv.pv <= 0)
                {
                    target.ValueRW.target = home.ValueRO.home;
                    ecb.AddComponent<GoHome>(entity);
                    ecb.AddComponent<Move>(entity);
                    ecb.RemoveComponent<OnAttack>(entity);
                }
            }
            ecb.Playback(state.EntityManager);
            ecb.Dispose();
        }
    }
}