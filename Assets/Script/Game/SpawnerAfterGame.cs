using System;
using Script.Component;
using Unity.Entities;
using Unity.Scenes;
using UnityEngine;

namespace Script.Game
{
    public class SpawnerAfterGame : MonoBehaviour
    {
        
        
        private void LateUpdate()
        {
            if (GameStat.countSpawn < GameStat.collecteur)
            {
                
                var pos = new Vector3(GameStat.positionColl[GameStat.countSpawn].x, GameStat.positionColl[GameStat.countSpawn].y, GameStat.positionColl[GameStat.countSpawn].z);
                InvokeColl(pos);
            }
            if (GameStat.countCabSpawn < GameStat.cabane)
            {
                
                var pos = new Vector3(GameStat.positionCab[GameStat.countCabSpawn].x, GameStat.positionCab[GameStat.countCabSpawn].y, GameStat.positionCab[GameStat.countCabSpawn].z);
                InvokeCab(pos);
            }
            
        }
    

        public void InvokeColl(Vector3 position)
        {
        
            var query = World.DefaultGameObjectInjectionWorld.EntityManager.CreateEntityQuery(
                typeof(WantToSpawn)
            );

            query.SetSingleton(new WantToSpawn()
            {
                wantToSpawn = true,
                unit = 5,
                position = position
            });
        }
        public void InvokeCab(Vector3 position)
        {
        
            var query = World.DefaultGameObjectInjectionWorld.EntityManager.CreateEntityQuery(
                typeof(WantToSpawn)
            );

            query.SetSingleton(new WantToSpawn()
            {
                wantToSpawn = true,
                unit = 12,
                position = position
            });
        }
    }
}

