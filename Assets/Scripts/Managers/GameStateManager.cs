using DigitalRuby.SoundManagerNamespace;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class GameStateManager : UnitySingleton<GameStateManager>
{

    private const string API_URL = "http://hidden-wildwood-12729.herokuapp.com/api/v1/entrance/AlmacenarDatosController";



    // Use this for initialization
    void Start()
    {
        print(Application.persistentDataPath);
        AudioManager.Instance.PlayMusic("BGM");
        //sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //    GoBack();
        //}
    }

    public void LoadScene(string sceneName)
    {
        AudioManager.Instance.StopMusic("BGM");
        AudioManager.Instance.StopAllVoices();
        SceneManager.LoadScene(sceneName);
    }

    //public void GoBack()
    //{
    //    int index = getCurrentSceneIndex();
    //    if (index < 1)
    //    {
    //        Application.Quit();
    //    }
    //    else
    //    {
    //        SceneManager.LoadScene(index - 1);
    //    }
    //}

    public int getCurrentSceneIndex()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }

    public string getCurrentSceneName()
    {
        return SceneManager.GetActiveScene().name;
    }

    public void ReloadCurrentScene()
    {
        LoadScene(getCurrentSceneName());
    }

    public bool CheckNet()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            Debug.Log("Error. Check internet connection!");
            return false;
        }
        return true;
    }

    public void SendJSON(string json)
    {
        List<string> jsonList = ReadLocalFile();
        Debug.Log(json);

        if (!CheckNet())
        {
            jsonList.Add(json);

            foreach (string jsonItem in jsonList)
            {
                //Dictionary<string, string> postHeader = new Dictionary<string, string>
                //{
                //    { "Content-Type", "application/json" }
                //};
                //byte[] body = Encoding.UTF8.GetBytes(jsonItem);
                //WWW www = new WWW(API_URL, body, postHeader);
                //StartCoroutine("Upload", www);
            }
        }
        else
        {
            jsonList.Add(json);
            SaveLocal(jsonList);
        }
        
    }

    IEnumerator Upload(WWW www)
    {
        yield return www;
        if (www.error != null)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Data Submitted");
        }


        // convert json string to byte
        //var formData = System.Text.Encoding.UTF8.GetBytes(json);

        //www = new WWW(API_URL, formData, postHeader);
        //StartCoroutine(WaitForRequest(www));
        //return www;



        //UnityWebRequest www = UnityWebRequest.Put(API_URL, json);
        //www.SetRequestHeader("Content-Type", "application/json");
        //yield return www.SendWebRequest();

        //if (www.isNetworkError || www.isHttpError)
        //{
        //    Debug.Log(www.error);
        //}
        //else
        //{
        //    Debug.Log("Upload complete!");
        //}
    }


    public List<string> ReadLocalFile()
    {
        List<string> save = new List<string>();
        if (File.Exists(Application.persistentDataPath + "/gamesave.save"))
        {
            Debug.Log("SAVE DATA FOUND");
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(Application.persistentDataPath + "/gamesave.save", FileMode.Open);
                save = (List<string>)bf.Deserialize(file);
                file.Close();
                return save;
            }
            catch (System.Exception)
            {
                Debug.Log("ERROR READING FILE");
                throw;
            }

        }
        else
        {
            Debug.Log("SAVE DATA NOT FOUND");
            return save;
        }

    }

    public void SaveLocal(List<string> jsonList)
    {
        try
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath + "/gamesave.save");
            bf.Serialize(file, jsonList);
            file.Close();

            Debug.Log("Saved Locally");
        }
        catch (System.Exception)
        {
            Debug.Log("ERROR SAVING FILE");
            throw;
        }

    }
}





//check connection

//true
//	check file
//		true
//			Load file

//            add JSON to List
	
//	for each json in list
//        upload json
//false
//	add JSON to List

//    save List locally