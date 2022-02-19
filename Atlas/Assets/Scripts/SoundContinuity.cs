using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundContinuity : MonoBehaviour
{
    private static SoundContinuity instance;


    public static SoundContinuity Instance
    {
        get { return instance; }
    }

    private void Awake()
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
}
