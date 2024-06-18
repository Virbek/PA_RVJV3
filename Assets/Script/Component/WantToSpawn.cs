using Unity.Entities;
using Unity.Mathematics;

namespace Script.Component
{
    public struct WantToSpawn : IComponentData
    {
        public bool wantToSpawn;
        public int unit;
        public float3 position;
    }
}