using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class AppManagerScript : MonoBehaviour
{
    public static Stack<int> PreviousSceneIndex = new Stack<int>();
    private static AppManagerScript instance = null;
    public static AppManagerScript Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
    }

    public static void ChangeScene(GameObject sender, int nextScene)
    {
        if (sender.name != "back")
            PreviousSceneIndex.Push(SceneManager.GetActiveScene().buildIndex);
        else
            PreviousSceneIndex.Pop();

        foreach (int item in PreviousSceneIndex.ToArray())
        {
            Debug.Log(item);
        }
        Debug.Log("---------------------------");
        
        SceneManager.LoadScene(nextScene);
    }
}