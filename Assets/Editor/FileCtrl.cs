using UnityEngine;
using UnityEditor;
using System.Collections;
using System.IO;

public class FileCtrl : Editor {
    [MenuItem ("TestFile/File Move")]
    private static void FileMove() {
        string searchPath = Application.dataPath + "/XLua/Examples";
        string[] dirs = Directory.GetFiles(searchPath, "*.txt", SearchOption.AllDirectories);
        Debug.Log("dirs.Count--------:"+dirs.Length);
        foreach(string str in dirs){
           
        }
    }
	
}
