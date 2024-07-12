using Unity.Entities;
using UnityEngine;

namespace Script.Component
{
    public struct Home : IComponentData
    {
        public Entity home;
    }
}