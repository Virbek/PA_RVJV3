using Script.Component;
using Script.Game;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace Script.System
{
    public partial struct MovementSystem : ISystem
    {
        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            var ecb = new EntityCommandBuffer(Allocator.Temp);
        
            foreach (var (localTransform, speed, range, target,entity) 
                     in SystemAPI.Query<RefRW<LocalTransform>, RefRO<Speed>, RefRO<RangeAttack>, RefRO<Target>>()
                         .WithAll<IsUnit>()
                         .WithNone<GoHome>()
                         .WithAll<Move>()
                         .WithEntityAccess()
                    )
            {
                var targetEntity = target.ValueRO.target;
                if (state.EntityManager.HasComponent<Disabled>(targetEntity))
                {
                    ecb.RemoveComponent<Move>(entity);
                    ecb.RemoveComponent<Target>(entity);
                    continue;
                }

                var targetLocalTransform = state.EntityManager.GetComponentData<LocalTransform>(targetEntity);
                var directionVector = targetLocalTransform.Position - localTransform.ValueRO.Position;
                var distanceToTarget = math.length(directionVector);

                var wishedMovementDistance = speed.ValueRO.speed * SystemAPI.Time.DeltaTime;
                var effectiveMovementDistance = math.min(distanceToTarget, wishedMovementDistance);

                localTransform.ValueRW.Position += math.normalizesafe(directionVector) * effectiveMovementDistance;

                if (distanceToTarget <= range.ValueRO.rangeAttack){
                    ecb.RemoveComponent<Move>(entity);
                    ecb.AddComponent<OnAttack>(entity);
                }
            }
            foreach (var (localTransform, speed, range, target,entity) 
                     in SystemAPI.Query<RefRW<LocalTransform>, RefRO<Speed>, RefRO<RangeAttack>, RefRO<Target>>()
                         .WithAll<IsProj>()
                         .WithAll<Move>()
                         .WithEntityAccess()
                    )
            {
                var targetEntity = target.ValueRO.target;
                if (state.EntityManager.HasComponent<Disabled>(targetEntity))
                {
                    ecb.AddComponent<Disabled>(entity);
                    ecb.RemoveComponent<Move>(entity);
                    ecb.RemoveComponent<IsProj>(entity);
                    ecb.RemoveComponent<Target>(entity);
                    continue;
                }

                var targetLocalTransform = state.EntityManager.GetComponentData<LocalTransform>(targetEntity);
                var directionVector = targetLocalTransform.Position - localTransform.ValueRO.Position;
                var distanceToTarget = math.length(directionVector);

                var wishedMovementDistance = speed.ValueRO.speed * SystemAPI.Time.DeltaTime;
                var effectiveMovementDistance = math.min(distanceToTarget, wishedMovementDistance);

                localTransform.ValueRW.Position += math.normalizesafe(directionVector) * effectiveMovementDistance;

                if (distanceToTarget <= range.ValueRO.rangeAttack){
                    ecb.RemoveComponent<Move>(entity);
                    ecb.AddComponent<OnAttack>(entity);
                }
            }
            ecb.Playback(state.EntityManager);
            ecb.Dispose();
        }
    }
}