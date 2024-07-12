using Script.Component;
using Unity.Entities;
using UnityEngine;

namespace Script.Game
{
    public class SceneControler : MonoBehaviour
    {
        public static SceneControler Instance { get; set; }
        public GameObject MenuScene;
        public GameObject BaseScene;
        public GameObject Niveau1;
        public GameObject Troupes;
        
        
        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
            }
        }
        
        public void InvokeDestroyer(Vector3 position)
        {
        
            var query = World.DefaultGameObjectInjectionWorld.EntityManager.CreateEntityQuery(
                typeof(WantToSpawn)
            );

            query.SetSingleton(new WantToSpawn()
            {
                wantToSpawn = true,
                unit = 6,
                position = position
            });
        }
        
        public void InvokeLevel1(Vector3 position)
        {
        
            var query = World.DefaultGameObjectInjectionWorld.EntityManager.CreateEntityQuery(
                typeof(WantToSpawn)
            );

            query.SetSingleton(new WantToSpawn()
            {
                wantToSpawn = true,
                unit = 7,
                position = position
            });
        }
        
        public void InvokeLevel2(Vector3 position)
        {
        
            var query = World.DefaultGameObjectInjectionWorld.EntityManager.CreateEntityQuery(
                typeof(WantToSpawn)
            );

            query.SetSingleton(new WantToSpawn()
            {
                wantToSpawn = true,
                unit = 8,
                position = position
            });
        }
        
        public void InvokeLevel3(Vector3 position)
        {
        
            var query = World.DefaultGameObjectInjectionWorld.EntityManager.CreateEntityQuery(
                typeof(WantToSpawn)
            );

            query.SetSingleton(new WantToSpawn()
            {
                wantToSpawn = true,
                unit = 9,
                position = position
            });
        }
        
        public void InvokeLevel4(Vector3 position)
        {
        
            var query = World.DefaultGameObjectInjectionWorld.EntityManager.CreateEntityQuery(
                typeof(WantToSpawn)
            );

            query.SetSingleton(new WantToSpawn()
            {
                wantToSpawn = true,
                unit = 10,
                position = position
            });
        }
        
        public void InvokeTree(Vector3 position)
        {
        
            var query = World.DefaultGameObjectInjectionWorld.EntityManager.CreateEntityQuery(
                typeof(WantToSpawn)
            );

            query.SetSingleton(new WantToSpawn()
            {
                wantToSpawn = true,
                unit = 11,
                position = position
            });
        }
    }
}