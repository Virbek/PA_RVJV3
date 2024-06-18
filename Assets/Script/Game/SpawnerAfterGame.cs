using Script.Component;
using Unity.Entities;
using UnityEngine;

namespace Script.Game
{
    public class SpawnerAfterGame : MonoBehaviour
    {
        [SerializeField]private bool spawn;

        private void Start()
        {
            spawn = false;
        }
    
        private void Update()
        {
            if (!spawn)
            {
                if (GameStat.collecteur != 0)
                {
                    for (int i = 0; i < GameStat.collecteur; i++)
                    {
                        InvokeColl(GameStat.positionColl[i]);
                    }
                }

                spawn = true;
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
    }
}

