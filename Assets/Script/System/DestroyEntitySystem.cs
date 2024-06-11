using Script.Component;
using Unity.Collections;
using Unity.Entities;

namespace Script.System
{
    partial struct DestroyEntitySystem : ISystem
    {
        public void OnUpdate(ref SystemState state)
        {
            var ecb = new EntityCommandBuffer(Allocator.Temp);
            foreach(var (health, entity) in SystemAPI.Query<RefRO<NombrePv>>()
                        .WithEntityAccess()
                   )
            {
                if(health.ValueRO.pv <= 0)
                {
                    ecb.RemoveComponent<IsBat>(entity);
                    ecb.AddComponent<Disabled>(entity);
                    
                }
            }
            ecb.Playback(state.EntityManager);
            ecb.Dispose();
        }
    }
}
