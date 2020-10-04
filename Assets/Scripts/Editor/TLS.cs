using UnityEngine;
using UnityEditor;
using System.Collections;
using System.IO;

public class TLS : EditorWindow
{
    private const string FOLDER_LOCATION = "Scripts/Utils/";
    private const string TAGS_SCRIPT = "Tags";
    private const string LAYER_SCRIPT = "Layers";
    private const string SCRIPT_EXTENSION = ".cs";

    [MenuItem("Utils/Create Tag and Layer Script")]
    static void CreateTagAndLayerClass()
    {
        string folderPath = Application.dataPath + "/" + FOLDER_LOCATION;
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }

        File.WriteAllText(folderPath + TAGS_SCRIPT + SCRIPT_EXTENSION, CreateTagElements(TAGS_SCRIPT, UnityEditorInternal.InternalEditorUtility.tags));
        File.WriteAllText(folderPath + LAYER_SCRIPT + SCRIPT_EXTENSION, CreateLayerElements(LAYER_SCRIPT, UnityEditorInternal.InternalEditorUtility.layers));
        
        AssetDatabase.ImportAsset("Assets/" + FOLDER_LOCATION + TAGS_SCRIPT + SCRIPT_EXTENSION, ImportAssetOptions.ForceUpdate);
        AssetDatabase.ImportAsset("Assets/" + FOLDER_LOCATION + LAYER_SCRIPT + SCRIPT_EXTENSION, ImportAssetOptions.ForceUpdate);
    }

    private static string CreateTagElements(string className, string[] tags)
    {
        string content = "";
        content += "public class " + className + "\n";
        content += "{\n";
        foreach (string tag in tags)
        {
            content += "\t"+ AddVariables(tag) + "\n";
        }
        content += "}";
        return content;
    }

    private static string CreateLayerElements(string className, string[] layers)
    {
        string content = "";
        content += "public class " + className + "\n";
        content += "{\n";
        foreach (string layer in layers)
        {
            content += "\t" + AddVariables(layer) + "\n";
        }
        content += "\n";

        foreach (string layer in layers)
        {
            content += "\t" + "public const int " + ConvertToUpperCase(layer) + "_INDEX" + " = " + LayerMask.NameToLayer(layer) + ";\n";
        }

        content += "}";
        return content;
    }

    private static string AddVariables(string variable)
    {
        return "public const string " + ConvertToUpperCase(variable) + " = " + '"' + variable + '"' + ";";
    }

    private static string ConvertToUpperCase(string varName)
    {
        string name = "" + varName[0];

        for (int n = 1; n < varName.Length; n++)
        {
            if ((char.IsUpper(varName[n]) || varName[n] == ' ') && !char.IsUpper(varName[n - 1]) && varName[n - 1] != '_' && varName[n - 1] != ' ')
            {
                name += "_";
            }

            if (varName[n] != ' ' && varName[n]!='_')
            {
                name += varName[n];
            }
        }

        name = name.ToUpper();
        return name;
    }
}