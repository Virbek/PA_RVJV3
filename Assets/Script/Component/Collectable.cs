using Unity.Entities;

namespace Script.Component
{
    public struct Collectable : IComponentData
    {
        public float timeToCollect;
    }
}