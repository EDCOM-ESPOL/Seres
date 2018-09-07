using DigitalRuby.SoundManagerNamespace;
using System.Collections;
using System.Collections.Generic;
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

    public void SaveSession(GameMetaData data)
    {
        //StoryMetaData data = new StoryMetaData(SessionManager.Instance.getPlayerID().ToString());
        Debug.Log(JsonUtility.ToJson(data));
    }

    public void SendJSON(string json)
    {
        //StoryMetaData data = new StoryMetaData(SessionManager.Instance.getPlayerID().ToString());
        Debug.Log(json);

        Dictionary<string, string> postHeader = new Dictionary<string, string>
        {
            { "Content-Type", "application/json" }
        };
        byte[] body = Encoding.UTF8.GetBytes(json);
        //Debug.Log(body);
        WWW www = new WWW(API_URL, body, postHeader);
        StartCoroutine("Upload", www);


        //StartCoroutine(Upload(json));

    }

    IEnumerator Upload(WWW www)
    {
        yield return www;
        if (www.error != null)
        {
            Debug.Log("Data Submitted");
        }
        else
        {
            Debug.Log(www.error);
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

}