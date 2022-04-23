using UnityEngine;
using System.Collections.Generic;

namespace StationeersAddonsHelper.Classes
{
    public class clObject
    {
        public GameObject obj;
        public List<clComponent> components;
        public bool visibleComponents = false;

        public clObject(GameObject obj, List<clComponent> components, bool visibleComponents = false)
        {
            this.obj = obj;
            this.components = components;
            this.visibleComponents = visibleComponents;            
        }
    }
}
