using UnityEngine;

public class MusicContinuity : MonoBehaviour
{
    private static MusicContinuity instance = null;
    public static MusicContinuity Instance
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
}
