using Unity.Entities;

namespace Script.Component
{
    public struct Spawner : IComponentData
    {
        public Entity WarPrefab;
        public Entity ArrPrefab;
        public Entity GeaPrefab;
        public Entity GoldPrefab;
    }
}