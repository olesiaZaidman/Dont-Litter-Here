using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
public static class FileHandler
{
    //save an array of objects:
    public static void SaveToJSON<T>(List<T> toSave, string fileName)
    {
        Debug.Log("Path: " + GetPath(fileName)); //easier to find your file
        string content = JsonHelper.ToJson<T>(toSave.ToArray());        //    string json = JsonUtility.ToJson(data);
        WriteFile(GetPath(fileName), content);
    }

    //save one object:
    public static void SaveToJSON<T>(T toSave, string fileName)
    {
        Debug.Log("Path: " + GetPath(fileName)); //easier to find your file
        string content = JsonUtility.ToJson(toSave);        //    string json = JsonUtility.ToJson(data);
        WriteFile(GetPath(fileName), content);
    }

    //load an array of objects:
    public static List<T> ReadListFromJSON<T>(string filename)
    {
        string content = ReadFile(GetPath(filename));
        if (string.IsNullOrEmpty(content) || content == "{}")
        {
            return new List<T>(); //return empty list if is empty
        }

        List<T> data = JsonHelper.FromJson<T>(content).ToList(); //add using System.Linq;
        return data;
    }


    // load one object:
    public static T ReadFromJSON<T>(string filename)
    {
        string content = ReadFile(GetPath(filename));
        if (string.IsNullOrEmpty(content) || content == "{}")
        {
            return default(T);
        }

        T data = JsonUtility.FromJson<T>(content); //add using System.Linq;
        return data;
    }



    private static string GetPath(string fileName)
    {
        return Application.persistentDataPath + "/" + fileName;
        //"/savefile.json"
        //"/randomPlayerScores.json"
    }


    /*To use UnityWebRequest to save and load data in JSON format, 
     * you can modify the WriteFile and ReadFile functions in FileHandler class to use UnityWebRequest 
     * instead of FileStream and StreamReader. 
     * Here's how you can modify the code:*/

    private static void WriteFile(string path, string content)
    {
        FileStream fileStream = new FileStream(path, FileMode.Create);
        using (StreamWriter writer = new StreamWriter(fileStream))
        {
            writer.Write(content);
        }
    }

    private static string ReadFile(string path)
    {
        if (File.Exists(path))
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string content = reader.ReadToEnd();
                return content;
            }
        }
        return "";
    }
}


public static class JsonHelper
{
    public static T[] FromJson<T>(string json)
    {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
        return wrapper.Items;
    }

    public static string ToJson<T>(T[] array)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper);
    }

    public static string ToJson<T>(T[] array, bool prettyPrint)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper, prettyPrint);
    }

    [System.Serializable]
    private class Wrapper<T>
    {
        public T[] Items;
    }
}

