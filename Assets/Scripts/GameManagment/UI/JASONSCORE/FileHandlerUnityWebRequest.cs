using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using UnityEngine.Networking;
using System;


public class FileHandlerUnityWebRequest : MonoBehaviour
{

    ///* C:/Users/Olesia/AppData/LocalLow/olesiaZaidman/Don't Litter Here!/dontLitterHerePlayersEntries.json*/
    ////save an array of objects:


    //public static void SaveToJSON<T>(List<T> toSave, string fileName)
    //{ 
    //    Debug.Log("Path: " + GetPath(fileName)); // easier to find your file

    //    string content = JsonHelper.ToJson<T>(toSave.ToArray());
    //    string path = GetPath(fileName);
    //    monoBehaviour.StartCoroutine(WriteFileRoutine(path, content, "POST"));

    //}


    //private static IEnumerator WriteFileRoutine(string path, string content, string httpMethod)
    //{
    //    using (UnityWebRequest request = UnityWebRequest.PostWwwForm(path, httpMethod))
    //    {
    //        byte[] jsonBytes = new System.Text.UTF8Encoding().GetBytes(content);
    //        request.uploadHandler = new UploadHandlerRaw(jsonBytes);
    //        request.downloadHandler = new DownloadHandlerBuffer();
    //        request.SetRequestHeader("Content-Type", "application/json");

    //        yield return request.SendWebRequest();

    //        if (request.result != UnityWebRequest.Result.Success)
    //        {
    //            Debug.LogError(request.error);
    //        }
    //    }
    //}
    //public static void ReadListFromJSON<T>(string filename, Action<List<T>> onComplete)
    //{
    //    string path = GetPath(filename);
    //    MonoBehaviour monoBehaviour = new MonoBehaviour();
    //    monoBehaviour.StartCoroutine(ReadFileRoutine( (jsonString) => {
    //        if (!string.IsNullOrEmpty(jsonString))
    //        {
    //            List<T> list = JsonHelper.FromJson<T>(jsonString);
    //            onComplete(list);
    //        }
    //        else
    //        {
    //            onComplete(null);
    //        }
    //    }));
    //}
    //private static string GetPath(string fileName)
    //{
    //    return Application.persistentDataPath + "/" + fileName;
    //}

    //private static IEnumerator ReadFileRoutine(Action<string> onComplete) //string path,
    //{
    //    string path = "https://my-json-server.typicode.com/typicode/demo/posts";
    //    UnityWebRequest request = UnityWebRequest.Get(path);
    //    yield return request.SendWebRequest();

    //    if (request.result != UnityWebRequest.Result.Success)
    //    {
    //        Debug.LogError(request.error);
    //        onComplete("");
    //    }
    //    else
    //    {
    //        onComplete(request.downloadHandler.text);
    //    }

    //}


    //public static void SaveToJSON<T>(List<T> toSave, string fileName)
    //{
    //    //Debug.Log("Path: " + GetPath(fileName)); //easier to find your file
    //    //string content = JsonHelper.ToJson<T>(toSave.ToArray());
    //    //WriteFile(GetPath(fileName), content);

    //    Debug.Log("Path: " + GetPath(fileName)); // easier to find your file
    //    string content = JsonHelper.ToJson<T>(toSave.ToArray());
    //    WriteFile(GetPath(fileName), content, "POST");

    //}

    ////save one object:
    //public static void SaveToJSON<T>(T toSave, string fileName)
    //{
    //    Debug.Log("Path: " + GetPath(fileName)); //easier to find your file
    //    string content = JsonUtility.ToJson(toSave);
    //    WriteFile(GetPath(fileName), content, "POST");
    //    // WriteFile(GetPath(fileName), content);
    //}

    //load an array of objects:
    //public static List<T> ReadListFromJSON<T>(string filename)
    //{
    //    string content = ReadFile(GetPath(filename));
    //    if (string.IsNullOrEmpty(content) || content == "{}")
    //    {
    //        return new List<T>(); //return empty list if is empty
    //    }

    //    List<T> data = JsonHelper.FromJson<T>(content).ToList(); //add using System.Linq;
    //    return data;
    //}

    //// load one object:
    //public static T ReadFromJSON<T>(string filename)
    //{
    //    string content = ReadFile(GetPath(filename));
    //    if (string.IsNullOrEmpty(content) || content == "{}")
    //    {
    //        return default(T);
    //    }

    //    T data = JsonUtility.FromJson<T>(content); //add using System.Linq;
    //    return data;
    //}


    //IEnumerator WriteFileRoutine()
    //{
    //    string path = "https://my-json-server.typicode.com/typicode/demo/posts";
    //    WWWForm form = new WWWForm();
    //    form.AddField("title", "scores");
    //    using (UnityWebRequest request = UnityWebRequest.Post(path, form))
    //    {
    //        yield return request.SendWebRequest();
    //        if (request.isNetworkError || request.isHttpError)
    //            outputArea.text = request.error;
    //        else
    //            outputArea.text = request.downloadHandler.text;
    //    }
    //}
    //private static void WriteFile(string path, string content, string httpMethod)
    //{
    //    UnityWebRequest request = UnityWebRequest.PostWwwForm(path, httpMethod);
    //    byte[] jsonBytes = new System.Text.UTF8Encoding().GetBytes(content);
    //    request.uploadHandler = new UploadHandlerRaw(jsonBytes);
    //    request.downloadHandler = new DownloadHandlerBuffer();
    //    request.SetRequestHeader("Content-Type", "application/json");

    //    request.SendWebRequest();
    //    while (!request.isDone) ;

    //    if (request.result != UnityWebRequest.Result.Success)
    //    {
    //        Debug.LogError(request.error);
    //    }
    //}

    //private static void WriteFile(string path, string content)
    //{
    //    UnityWebRequest request = UnityWebRequest.Put(path, content);
    //    request.SetRequestHeader("Content-Type", "application/json");

    //    request.SendWebRequest();
    //    while (!request.isDone) ;

    //    if (request.result != UnityWebRequest.Result.Success)
    //    {
    //        Debug.LogError(request.error);
    //    }
    //}

    //private static void WriteFile(string path, string content)
    //{
    //    UnityWebRequest request = UnityWebRequest.Put(path, content);
    //    byte[] jsonBytes = new System.Text.UTF8Encoding().GetBytes(content);
    //    request.uploadHandler = new UploadHandlerRaw(jsonBytes);
    //    request.downloadHandler = new DownloadHandlerBuffer();
    //    request.SetRequestHeader("Content-Type", "application/json");

    //    request.SendWebRequest();
    //    while (!request.isDone) ;

    //    if (request.result != UnityWebRequest.Result.Success)
    //    {
    //        Debug.LogError(request.error);
    //    }
    //    UnityWebRequest request = UnityWebRequest.PostWwwForm(path, "POST");
    //    byte[] jsonBytes = new System.Text.UTF8Encoding().GetBytes(content);
    //    request.uploadHandler = new UploadHandlerRaw(jsonBytes);
    //    request.downloadHandler = new DownloadHandlerBuffer();
    //    request.SetRequestHeader("Content-Type", "application/json");

    //    request.SendWebRequest();
    //    while (!request.isDone) ;

    //    if (request.result != UnityWebRequest.Result.Success)
    //    {
    //        Debug.LogError(request.error);
    //    }
    // }
    //IEnumerator

    //public void MyFunction()
    //{
    //    string path = "https://my-json-server.typicode.com/typicode/demo/posts";

    //    StartCoroutine(ReadFileRoutine(path, (result) => {
    //        Debug.Log("Result: " + result);
    //    }));
    //}

    //private static IEnumerator ReadFileRoutine( Action<string> onComplete) //string path,
    //{
    //    string path = "https://my-json-server.typicode.com/typicode/demo/posts";
    //    UnityWebRequest request = UnityWebRequest.Get(path);
    //    yield return request.SendWebRequest();

    //    if (request.result != UnityWebRequest.Result.Success)
    //    {
    //        Debug.LogError(request.error);
    //        onComplete("");
    //    }
    //    else
    //    {
    //        onComplete(request.downloadHandler.text);
    //    }
    //    //UnityWebRequest request = UnityWebRequest.Get(path);

    //    //yield return request.SendWebRequest();

    //    //if (request.result != UnityWebRequest.Result.Success)
    //    //{
    //    //    Debug.LogError(request.error);
    //    //    callback("");
    //    //}
    //    //else
    //    //{
    //    //    callback(request.downloadHandler.text);
    //    //}


    //    /*In this example, the ReadFile function now takes an additional parameter onComplete, 
    //     * which is a callback function that will be called with the result of the request. 
    //     * The function returns an IEnumerator so it can be used as a coroutine. 
    //     * The yield return request.SendWebRequest() statement will pause the coroutine until
    //     * the request completes,
    //     * and then resume execution when it does.*/
    //}
//    private static string ReadFile(string path)
//    {
//        /*path is something like       
//         * string path = "https://my-json-server.typicode.com/typicode/demo/posts";
//It is recommended to use a coroutine for making web requests to prevent blocking the main thread 
//        while waiting for the response.*/
//        UnityWebRequest request = UnityWebRequest.Get(path);
//        request.SendWebRequest();
//        while (!request.isDone) ;

//        if (request.result != UnityWebRequest.Result.Success )
//        {
//            Debug.LogError(request.error);
//            return ""; //or return request.error;
//        }

//        return request.downloadHandler.text;
//    }
   





    //  public static void SaveToJSON<T>(List<T> toSave, string fileName)
    //  {
    //      Debug.Log("Path: " + GetPath(fileName)); //easier to find your file
    //      string content = JsonHelper.ToJson<T>(toSave.ToArray());        //    string json = JsonUtility.ToJson(data);
    //      CoroutineHandler.StartCoroutine(WriteFile(GetPath(fileName), content));
    //  }

    //  public static void ReadListFromJSON<T>(string filename, System.Action<List<T>> callback)
    //  {
    //      CoroutineHandler.StartCoroutine(ReadFile(GetPath(filename), (content) =>
    //      {
    //          if (string.IsNullOrEmpty(content) || content == "{}")
    //          {
    //              callback(new List<T>()); //return empty list if is empty
    //          }
    //          else
    //          {
    //              List<T> data = JsonHelper.FromJson<T>(content).ToList(); //add using System.Linq;
    //              callback(data);
    //          }
    //      }));
    //  }

    //  private static string GetPath(string fileName)
    //  {
    //      return Application.dataPath + "/" + fileName;
    //      //"/savefile.json"
    //      //"/randomPlayerScores.json"
    //  }

    //  /*To use UnityWebRequest to save and load data in JSON format, 
    //* you can modify the WriteFile and ReadFile functions in FileHandler class to use UnityWebRequest 
    //* instead of FileStream and StreamReader. 
    //* Here's how you can modify the code:*/

    //  private static IEnumerator WriteFile(string path, string content)
    //  {
    //      UnityWebRequest www = new UnityWebRequest(path, "PUT");
    //      byte[] contentBytes = System.Text.Encoding.UTF8.GetBytes(content);
    //      UploadHandlerRaw uploadHandler = new UploadHandlerRaw(contentBytes);
    //      www.uploadHandler = uploadHandler;
    //      www.downloadHandler = new DownloadHandlerBuffer();
    //      yield return www.SendWebRequest();

    //      if (www.result != UnityWebRequest.Result.Success)
    //      {
    //          Debug.LogError(www.error);
    //      }
    //  }

    //  private static IEnumerator ReadFile(string path, System.Action<string> callback)
    //  {
    //      UnityWebRequest www = UnityWebRequest.Get(path);
    //      yield return www.SendWebRequest();

    //      if (www.result != UnityWebRequest.Result.Success)
    //      {
    //          Debug.LogError(www.error);
    //      }
    //      else
    //      {
    //          string content = www.downloadHandler.text;
    //          callback(content);
    //      }
    //  }
}



//public static class JsonHelper
//{
//    public static T[] FromJson<T>(string json)
//    {
//        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
//        return wrapper.Items;
//    }

//    public static string ToJson<T>(T[] array)
//    {
//        Wrapper<T> wrapper = new Wrapper<T>();
//        wrapper.Items = array;
//        return JsonUtility.ToJson(wrapper);
//    }

//    public static string ToJson<T>(T[] array, bool prettyPrint)
//    {
//        Wrapper<T> wrapper = new Wrapper<T>();
//        wrapper.Items = array;
//        return JsonUtility.ToJson(wrapper, prettyPrint);
//    }

//    [System.Serializable]
//    private class Wrapper<T>
//    {
//        public T[] Items;
//    }
//}

