﻿using Script.Component;
using Unity.Entities;
using UnityEngine;

namespace Script.Authoring
{
    public class TimeDelayAttackAuthoring : MonoBehaviour
    {
        public float timedelayAttack;
        public class Baker : Baker<TimeDelayAttackAuthoring>
        {
            public override void Bake(TimeDelayAttackAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
            
                AddComponent(entity, new TimeDelayAttack
                {
                    timeDelayAttack = authoring.timedelayAttack
                });
            }
        }
    }
    
}