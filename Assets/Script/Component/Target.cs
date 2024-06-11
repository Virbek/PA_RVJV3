using Unity.Entities;
using UnityEngine;

namespace Script.Component
{
    public struct Target : IComponentData
    {
        public Entity target;
    }
}