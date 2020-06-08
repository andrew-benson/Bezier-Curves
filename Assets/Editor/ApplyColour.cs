using UnityEditor;
using UnityEngine;

public class ApplyColour : EditorWindow
{
    private Color selectedColor;

    [MenuItem("Window/Apply Object Colour")]
    static void ShowWindow()
    {
        GetWindow<ApplyColour>().Show();
    }

    private void OnGUI()
    {
        GUILayout.Label("Colour Picker", new GUIStyle { fontStyle = FontStyle.Bold });

        selectedColor = EditorGUILayout.ColorField("Colour", selectedColor);

        if (GUILayout.Button("Apply"))
        {           
            foreach (var obj in Selection.gameObjects)
            {
                var component = obj.GetComponent<Renderer>();
                if(component)
                {
                    component.sharedMaterial.color = selectedColor;
                }
            }
        }
    }
}
