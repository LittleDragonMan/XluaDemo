using UnityEngine;
using UnityEditor;
using System.Collections;
using System.IO;

public class FileCtrl : Editor {
    [MenuItem ("TestFile/File Move")]
    private static void FileMove() {
        string searchPath = Application.dataPath + "/XLua/Examples/Test";
        string[] dirs = Directory.GetFiles(searchPath, "*.txt", SearchOption.AllDirectories);
        Debug.Log("dirs.Count--------:"+dirs.Length);
        foreach(string str in dirs){
           
        }
    }

    /// <summary>
    /// 递归拷贝所有子目录。
    /// </summary>
    /// <param >源目录</param>
    /// <param >目的目录</param>
    private void copyDirectory(string sPath, string dPath) {
        string[] directories = System.IO.Directory.GetDirectories(sPath);
        if (!System.IO.Directory.Exists(dPath))
            System.IO.Directory.CreateDirectory(dPath);
        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(sPath);
        System.IO.DirectoryInfo[] dirs = dir.GetDirectories();
        CopyFile(dir, dPath);
        if (dirs.Length > 0) {
            foreach (System.IO.DirectoryInfo temDirectoryInfo in dirs) {
                string sourceDirectoryFullName = temDirectoryInfo.FullName;
                string destDirectoryFullName = sourceDirectoryFullName.Replace(sPath, dPath);
                if (!System.IO.Directory.Exists(destDirectoryFullName)) {
                    System.IO.Directory.CreateDirectory(destDirectoryFullName);
                }
                CopyFile(temDirectoryInfo, destDirectoryFullName);
                copyDirectory(sourceDirectoryFullName, destDirectoryFullName);
            }
        }

    }

    /// <summary>
    /// 拷贝目录下的所有文件到目的目录。
    /// </summary>
    /// <param >源路径</param>
    /// <param >目的路径</param>
    private void CopyFile(System.IO.DirectoryInfo path, string desPath) {
        string sourcePath = path.FullName;
        System.IO.FileInfo[] files = path.GetFiles();
        foreach (System.IO.FileInfo file in files) {
            string sourceFileFullName = file.FullName;
            string destFileFullName = sourceFileFullName.Replace(sourcePath, desPath);
            file.CopyTo(destFileFullName, true);
        }
    }
	
}
