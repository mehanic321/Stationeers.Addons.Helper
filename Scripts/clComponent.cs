using UnityEngine;
using System.Reflection;

namespace StationeersAddonsHelper.Classes
{
    public class clComponent
    {
        public Component component;        
        public FieldInfo[] fields;
        public bool visibleFields = false;
        public clComponent(Component component, FieldInfo[] fields, bool visibleFields = false)
        {
            this.component = component;
            this.fields = fields;
            this.visibleFields = visibleFields;
        }
    }
}
