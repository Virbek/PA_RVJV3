using System;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using Unity.Entities;
using Unity.Scenes;
using Unity.VisualScripting;

namespace Script.Game
{
 
    public class SubSceneLoaderTest : MonoBehaviour
    {
        [SerializeField] private GameObject test;
        private Entity subScene;
        private bool isDelete;

        private void Start()
        {
        }

        private void Update()
        {
        }

        private void LoadSubScene(SubScene subSceneToLoad)
        {
            var loadParameters = new SceneSystem.LoadParameters
            {
                Flags = SceneLoadFlags.NewInstance
            };
 
            subScene = SceneSystem.LoadSceneAsync(World.DefaultGameObjectInjectionWorld.Unmanaged, subSceneToLoad.SceneGUID, loadParameters);
 
            StartCoroutine(CheckScene());
        }
 
        private void UnLoadSubScene()
        {
            // Specify unload parameters, you can adjust these based on your requirements.
            var unloadParameters = SceneSystem.UnloadParameters.DestroyMetaEntities;
 
            SceneSystem.UnloadScene(World.DefaultGameObjectInjectionWorld.Unmanaged, subScene, unloadParameters);
        }
 
        IEnumerator CheckScene()
        {
            while(!SceneSystem.IsSceneLoaded(World.DefaultGameObjectInjectionWorld.Unmanaged, subScene))
            {
                yield return null;
            }
        }
        
        IEnumerator CheckDeleteScene()
        {
            while(SceneSystem.IsSceneLoaded(World.DefaultGameObjectInjectionWorld.Unmanaged, subScene))
            {
                
                yield return null;
            }
            
        }

        public void Jouer(SubScene subSceneToLoad)
        {
            LoadSubScene(subSceneToLoad);
        }
        
        public void Quiter()
        {
           
            UnLoadSubScene();
            
        }
    }
}