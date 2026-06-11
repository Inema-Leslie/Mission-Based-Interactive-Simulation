#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

public class FixTreeMaterials : MonoBehaviour
{
    [MenuItem("Tools/Fix Tree Materials for URP")]
    static void FixMaterials()
    {
        // Find all materials in the project
        string[] guids = AssetDatabase.FindAssets("t:Material", 
            new[] { "Assets/Tree9" });
        
        foreach (string guid in guids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            Material mat = AssetDatabase.LoadAssetAtPath<Material>(path);
            
            if (mat != null)
            {
                mat.shader = Shader.Find("Universal Render Pipeline/Lit");
                EditorUtility.SetDirty(mat);
                Debug.Log("Fixed: " + path);
            }
        }
        
        AssetDatabase.SaveAssets();
        Debug.Log("All Tree9 materials converted to URP!");
    }
}
#endif