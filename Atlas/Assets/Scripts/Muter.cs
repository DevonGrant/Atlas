using UnityEngine;

public class Muter : MonoBehaviour
{
    private bool mute;

    // Start is called before the first frame update
    void Start()
    {
        mute = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (mute)
            {
                MusicContinuity.Instance.GetComponent<AudioSource>().Play();
                SoundContinuity.Instance.GetComponent<AudioSource>().enabled = true;
            }
            else
            {
                MusicContinuity.Instance.GetComponent<AudioSource>().Pause();
                SoundContinuity.Instance.GetComponent<AudioSource>().enabled = false;
            }

            mute = !mute;
        }
    }
}
