using Unity.Entities;

namespace Script.Component
{
    public struct Spawner : IComponentData
    {
        public Entity WarPrefab;
        public Entity ArrPrefab;
        public Entity GeaPrefab;
        public Entity BallPrefab;
        public Entity BallDefPrefab;
        public Entity GoldPrefab;
        public Entity DestroyPrefab;
        public Entity Level1Prefab;
        public Entity Level2Prefab;
        public Entity Level3Prefab;
        public Entity Level4Prefab;
        public Entity TreePrefab;
        public Entity CabanePrefab;
        
    }
}