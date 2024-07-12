using Unity.Entities;

namespace Script.Component
{
    public struct Minions : IComponentData
    {
        public Entity minionsPrefab;
        public bool spawn;

    }
}