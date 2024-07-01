using Unity.Entities;
using UnityEngine;

namespace Script.Component
{
    public struct Projectiles : IComponentData
    {
        public Entity prefab;
    }
}