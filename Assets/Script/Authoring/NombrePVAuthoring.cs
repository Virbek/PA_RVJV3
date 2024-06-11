using Script.Component;
using Unity.Entities;
using UnityEngine;
using NotImplementedException = System.NotImplementedException;

namespace Script.Authoring
{
    public class NombrePvAuthoring : MonoBehaviour
    {
        public int pv;
        private class Baker : Baker<NombrePvAuthoring>
        {
            public override void Bake(NombrePvAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                
                AddComponent(entity, new NombrePv()
                {
                    pv = authoring.pv
                });
            }
        }
    }
}