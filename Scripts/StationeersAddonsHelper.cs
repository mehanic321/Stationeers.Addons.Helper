using Stationeers.Addons;
using UnityEngine;
using StationeersAddonsHelper.Scripts;
using StationeersAddonsHelper.Windows;

namespace StationeersAddonsHelper.Main
{
    public class StationeersAddonsHelper : IPlugin
    {
        public void OnLoad()
        {
            var gameObject = new GameObject("Helper");
            UnityEngine.Object.DontDestroyOnLoad(gameObject);
            gameObject.AddComponent<schHelper>();
            gameObject.AddComponent<schWindows>();
        }

        public void OnUnload()
        {
            
        }
    }
}

