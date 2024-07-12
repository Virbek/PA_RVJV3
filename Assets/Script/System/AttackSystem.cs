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
    public partial struct AttackSystem : ISystem
    {

        public void OnUpdate(ref SystemState state)
        {
            var ecb = new EntityCommandBuffer(Allocator.Temp);

            foreach (var (delay, degat, target,timeDelayAttack, entity)
                     in SystemAPI.Query<RefRW<DelayAttack>, RefRO<Puissance>, RefRO<Target>, RefRO<TimeDelayAttack>>()
                         .WithAll<OnAttack>()
                         .WithNone<IsRanged>()
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
            foreach (var (localEnty,delay, degat, target,timeDelayAttack,projectiles, entity)
                     in SystemAPI.Query<RefRW<LocalTransform>,RefRW<DelayAttack>, RefRO<Puissance>, RefRO<Target>,RefRO<TimeDelayAttack>, RefRO<Projectiles>>()
                         .WithAll<OnAttack>()
                         .WithAll<IsRanged>()
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
                if (delay.ValueRO.delayAttack >= timeDelayAttack.ValueRO.timeDelayAttack)
                {
                    var proj = ecb.Instantiate(projectiles.ValueRO.prefab);
                    ecb.RemoveComponent<PhysicsCollider>(proj);
                    ecb.SetComponent(proj, new LocalTransform
                    {
                            Position = localEnty.ValueRO.Position,
                            Rotation = quaternion.identity,
                            Scale = 1f
                    });
                    ecb.AddComponent(proj, new Move());
                    ecb.AddComponent(proj, new IsProj());
                    ecb.AddComponent(proj, new Target
                    {
                        target = targetEntity
                    });
                    delay.ValueRW.delayAttack = 0;
                }
            }
            foreach (var (degat, target, entity)
                     in SystemAPI.Query<RefRO<Puissance>, RefRO<Target>>()
                         .WithAll<OnAttack>()
                         .WithAll<IsProj>()
                         .WithEntityAccess()
                    )
            {
                var targetEntity = target.ValueRO.target;
                if (state.EntityManager.HasComponent<Disabled>(targetEntity))
                {
                    ecb.RemoveComponent<OnAttack>(entity);
                    ecb.RemoveComponent<Target>(entity);
                    ecb.AddComponent<Disabled>(entity);
                    continue;
                }

                var targetPv = state.EntityManager.GetComponentData<NombrePv>(targetEntity);
                targetPv.pv -= degat.ValueRO.puissance;
                state.EntityManager.SetComponentData(targetEntity,targetPv);
                ecb.AddComponent<Disabled>(entity);
            }
            ecb.Playback(state.EntityManager);
            ecb.Dispose();
        }
    }
}