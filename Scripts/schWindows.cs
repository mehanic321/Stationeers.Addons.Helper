using UnityEngine;
using StationeersAddonsHelper.Windows.Objects;
using StationeersAddonsHelper.Lang;
using StationeersAddonsHelper.Scripts;

namespace StationeersAddonsHelper.Windows
{
    class schWindows : MonoBehaviour
    {

        public static int width = 800;

        public static string searchString = "";

        void OnGUI()
        {
            Header();
            wObjects.windowObjects();
            Footer();
        }

        public void Header()
        {
            GUILayout.BeginArea(new Rect(Screen.width / 2, Screen.height / 2 - width / 2, width, Screen.height / 2), "Stationeers Addons Helper", "Box");
            GUILayout.Label("");
            GUILayout.BeginHorizontal();
            GUILayout.Label(Lang.Lang.select + ": ");
            if (GUILayout.Button(Lang.Lang.objects))
            {

            }
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Toggle(schHelper.useResourcesFolder, Lang.Lang.toggleText);
            if (GUILayout.Button(Lang.Lang.falseText))
            {
                schHelper.SetUseResourcesFolder(false);
            }
            if (GUILayout.Button(Lang.Lang.trueText))
            {
                schHelper.SetUseResourcesFolder(true);
            }
            GUILayout.EndHorizontal();

            GUILayout.Label(Lang.Lang.dontSee);
            GUILayout.Label(Lang.Lang.search+":");

            searchString = GUILayout.TextField(searchString);
        }

        public void Footer()
        {
            GUILayout.Label(Lang.Lang.author + ": mehanic321 https://github.com/mehanic321/");
            GUILayout.EndArea();
        }

    }
}
