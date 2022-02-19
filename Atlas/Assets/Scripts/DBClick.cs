using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class DBClick : MonoBehaviour
{
    public bool universalIcon;
    public int nextScene;
   public void Click()
    {
        if (!universalIcon)
        {
            if (gameObject.name != "back")
                PrevButton.icon = this.GetComponent<Image>().sprite;
        }

        AppManagerScript.ChangeScene(gameObject, nextScene);
    }
}
public static class PrevButton
{
    public static Sprite icon { get; set; }
}