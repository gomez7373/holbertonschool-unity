using UnityEngine;
using UnityEditor;

public static class FindMissingScripts
{
    [MenuItem("Tools/Find Missing Scripts in Scene")]
    public static void Find()
    {
        int count = 0;
        foreach (var go in Object.FindObjectsOfType<GameObject>())
        {
            var comps = go.GetComponents<Component>();
            foreach (var c in comps)
            {
                if (c == null)
                {
                    Debug.LogWarning("Missing script on: " + GetPath(go), go);
                    count++;
                }
            }
        }
        Debug.Log($"Done. Objects with missing scripts: {count}");
    }

    static string GetPath(GameObject obj)
    {
        string path = obj.name;
        while (obj.transform.parent != null)
        {
            obj = obj.transform.parent.gameObject;
            path = obj.name + "/" + path;
        }
        return path;
    }
}
