using Script.Component;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace Script.System
{
    [BurstCompile]
    public partial struct AttackSystem : ISystem
    {
        public void OnUpdate(ref SystemState state)
        {
            var ecb = new EntityCommandBuffer(Allocator.Temp);

            foreach (var (delay, degat, target,timeDelayAttack, entity)
                     in SystemAPI.Query<RefRW<DelayAttack>, RefRO<Puissance>, RefRO<Target>, RefRO<TimeDelayAttack>>()
                         .WithAll<OnAttack>()
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
                if (delay.ValueRO.delayAttack >= timeDelayAttack.ValueRO.timeDelayAttack){
                    var targetPv = state.EntityManager.GetComponentData<NombrePv>(targetEntity);
                    targetPv.pv -= degat.ValueRO.puissance;
                    state.EntityManager.SetComponentData(targetEntity, targetPv);
                    delay.ValueRW.delayAttack = 0;
                }
            }
            ecb.Playback(state.EntityManager);
            ecb.Dispose();
        }
    }
}