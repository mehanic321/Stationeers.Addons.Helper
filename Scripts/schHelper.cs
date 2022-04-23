using UnityEngine;
using System.Collections.Generic;
using System;
using System.Reflection;
using StationeersAddonsHelper.Classes;
using StationeersAddonsHelper.Lang;

namespace StationeersAddonsHelper.Scripts
{
public class schHelper : MonoBehaviour
{

    public static bool useResourcesFolder = false;

    public static UnityEngine.Object[] allObjects;

    public static List<clObject> listObjects = new List<clObject>();

    void Awake()
    {
        ReloadItems();
    }

    //загрузить/перезагрузить обьекты
    public static void ReloadItems()
    {
        LoadObjects();
        GenerateNormalArrayObjects();
    }
    
    //установить занчение переменной отвечающей за откуда грузить обьекты
    public static void SetUseResourcesFolder(bool status)
    {
        useResourcesFolder = status;
        ReloadItems();
    }

    //вывести информацию об объекте
    public static void DebugObject(GameObject obj)
    {
        var output = JsonUtility.ToJson(obj, true);
        Debug.Log(output);
    }

    //вывести значения компонента в консоль
    public static void DebugProperties(Component component)
    {
        Debug.Log("===========");
        Debug.Log(Lang.Lang.component + " " + component.GetType());
        foreach (var property in component.GetType().GetProperties())
        {
            try
            {
                Debug.Log(Lang.Lang.name + ": " + property.Name + " | " + Lang.Lang.value + ": " + property.GetValue(component, null) + " | " + Lang.Lang.type + ": " + property.PropertyType + "\n");
            }
            catch (Exception e)
            {
                //Debug.LogError(e);
            }
        }
    }

    //сгенерировать нормальный массив
    public static void GenerateNormalArrayObjects()
    {
        listObjects.Clear();
        foreach (GameObject _oneObject in allObjects)
        {
            //КОСТЫЛЬ?!?!?!?
            if (_oneObject.name == "CameraWaypointPath") continue;

            List<clComponent> _clComponents = GetComponentsAndFieldsObject(_oneObject);
            listObjects.Add(new clObject(_oneObject, _clComponents));
        }
    }
    
    //получить компоненты и поля обьекта
    public static List<clComponent> GetComponentsAndFieldsObject(GameObject obj)
    {
        Component[] _components = obj.GetComponents(typeof(Component));
        List<clComponent> _listComponents = new List<clComponent>();
        foreach (Component _component in _components)
        {
            FieldInfo[] _fields = _component.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);            
            _listComponents.Add(new clComponent(_component, _fields));             
        }
        return _listComponents;
    }

    //загрузить обьекты
    public static void LoadObjects()
    {
        if (useResourcesFolder)
        {
            allObjects = LoadObjectsInScene();
        }
        else
        {
            allObjects = LoadResources();
        }
    }

    //получить все обьекты на сцене
    public static UnityEngine.Object[] LoadObjectsInScene()
    {
        return FindObjectsOfType<GameObject>();
    }

    //получить все обьекты из папки "Resources"
    public static UnityEngine.Object[] LoadResources()
    {
        return Resources.LoadAll("", typeof(GameObject));
    }
}

}
