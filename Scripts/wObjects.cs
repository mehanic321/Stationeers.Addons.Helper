using UnityEngine;
using System;
using System.Reflection;

using StationeersAddonsHelper.Scripts;
using StationeersAddonsHelper.Classes;

namespace StationeersAddonsHelper.Windows.Objects
{
    class wObjects : MonoBehaviour
    {
        public static Vector2 scrollPosition;

        public static void windowObjects()
        {
            scrollPosition = GUILayout.BeginScrollView(scrollPosition);

            for (int i = 0; i < schHelper.listObjects.Count; i++)
            {
                clObject oneObject = schHelper.listObjects[i];
                string nameButton = oneObject.obj.name;

                if (nameButton.IndexOf(schWindows.searchString, StringComparison.OrdinalIgnoreCase) != -1 || schWindows.searchString.Length <= 0)
                {
                    GUILayout.BeginHorizontal();
                    string textV = (schHelper.listObjects[i].visibleComponents) ? "^" : "v";
                    if (GUILayout.Button(textV, GUILayout.Width(20)))
                    {
                        if (schHelper.listObjects[i].visibleComponents)
                        {
                            schHelper.listObjects[i].visibleComponents = false;
                        }
                        else
                        {
                            schHelper.listObjects[i].visibleComponents = true;
                        }
                    }
                    if (GUILayout.Button(nameButton))
                    {
                        
                    }
                    GUILayout.EndHorizontal();

                    if (schHelper.listObjects[i].visibleComponents)
                    {
                        for (int ii = 0; ii < schHelper.listObjects[i].components.Count; ii++)
                        {
                            clComponent comp = schHelper.listObjects[i].components[ii];                        
                            Component _comp = comp.component;
                            GUILayout.BeginHorizontal();
                            string nameButtonComp = _comp.GetType().ToString();
                            GUILayout.Space(30);

                            string _textV = (schHelper.listObjects[i].components[ii].visibleFields) ? "^" : "v";
                            if (GUILayout.Button(_textV, GUILayout.Width(20)))
                            {
                                if (schHelper.listObjects[i].components[ii].visibleFields)
                                {
                                    schHelper.listObjects[i].components[ii].visibleFields = false;
                                }
                                else
                                {
                                    schHelper.listObjects[i].components[ii].visibleFields = true;
                                }
                            }

                            if (GUILayout.Button(nameButtonComp))
                            {
                                schHelper.DebugProperties(schHelper.listObjects[i].components[ii].component);
                            }
                            GUILayout.EndHorizontal();

                            if (schHelper.listObjects[i].components[ii].visibleFields)
                            {
                                FieldInfo[] _fields;
                                _fields = schHelper.listObjects[i].components[ii].component.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
                                for (int iii = 0; iii < _fields.Length; iii++)
                                {
                                    FieldInfo _field = _fields[iii];
                                    GUILayout.BeginHorizontal();
                                    GUILayout.Space(60);
                                    if (GUILayout.Button(_field.ToString()))
                                    {
                                        
                                    }
                                    GUILayout.EndHorizontal();
                                }

                                _fields = schHelper.listObjects[i].components[ii].component.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance);
                                for (int iii = 0; iii < _fields.Length; iii++)
                                {
                                    FieldInfo _field = _fields[iii];
                                    GUILayout.BeginHorizontal();
                                    GUILayout.Space(60);
                                    if (GUILayout.Button(_field.ToString()))
                                    {

                                    }
                                    GUILayout.EndHorizontal();
                                }

                                _fields = schHelper.listObjects[i].components[ii].component.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Static);
                                for (int iii = 0; iii < _fields.Length; iii++)
                                {
                                    FieldInfo _field = _fields[iii];
                                    GUILayout.BeginHorizontal();
                                    GUILayout.Space(60);
                                    if (GUILayout.Button(_field.ToString()))
                                    {

                                    }
                                    GUILayout.EndHorizontal();
                                }

                                _fields = schHelper.listObjects[i].components[ii].component.GetType().GetFields(BindingFlags.Public | BindingFlags.Static);
                                for (int iii = 0; iii < _fields.Length; iii++)
                                {
                                    FieldInfo _field = _fields[iii];
                                    GUILayout.BeginHorizontal();
                                    GUILayout.Space(60);
                                    if (GUILayout.Button(_field.ToString()))
                                    {

                                    }
                                    GUILayout.EndHorizontal();
                                }
                            }
                        }
                    }
                }
            }

            GUILayout.EndScrollView();
        }
    }
}
