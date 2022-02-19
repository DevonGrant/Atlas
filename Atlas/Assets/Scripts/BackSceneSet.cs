using UnityEngine;

public class BackSceneSet : MonoBehaviour
{
    void Start()
    {
        if (AppManagerScript.PreviousSceneIndex.Count > 0)
            GetComponent<DBClick>().nextScene = AppManagerScript.PreviousSceneIndex.Peek();       
    }
}