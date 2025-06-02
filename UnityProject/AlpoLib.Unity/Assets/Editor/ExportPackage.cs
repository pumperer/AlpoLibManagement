using UnityEditor;
using UnityEditor.PackageManager;
using UnityEditor.PackageManager.Requests;

public static class ExportPackage
{
    [MenuItem("Packages/Export Package Core", priority = 101)]
    public static void Export_Core()
    {
        Process("Core");
    }
    
    [MenuItem("Packages/Export Package Util", priority = 102)]
    public static void Export_Util()
    {
        Process("Util");
    }
    
    [MenuItem("Packages/Export Package Data", priority = 201)]
    public static void Export_Data()
    {
        Process("Data");
    }
    
    [MenuItem("Packages/Export Package UI", priority = 202)]
    public static void Export_UI()
    {
        Process("UI");
    }
    
    private static PackRequest _request;

    private static void Process(string path)
    {
        EditorUtility.DisplayProgressBar("Export", "Exporting...", 0);
        _request = Client.Pack($"Assets/AlpoLib/{path}", "Export");
        EditorApplication.update += Progress;
    }
    
    private static void Progress()
    {
        if (_request.IsCompleted)
        {
            if (_request.Status == StatusCode.Success)
            {
                UnityEngine.Debug.Log($"Pack is complete. \"{_request.Result.tarballPath}\"");
                EditorUtility.RevealInFinder(_request.Result.tarballPath);
            }
            else if (_request.Status >= StatusCode.Failure)
            {
                UnityEngine.Debug.LogError(_request.Error.message);
            }
            EditorApplication.update -= Progress;
            EditorUtility.ClearProgressBar();
        }
    }
}
