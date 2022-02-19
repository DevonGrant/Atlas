using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitScreenNavigator : MonoBehaviour
{
    AudioClip backSound;
    AudioSource audioSource;

    private void Start()
    {
        backSound = Resources.Load<AudioClip>("Sounds/back");
        audioSource = SoundContinuity.Instance.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (SceneManager.GetActiveScene().buildIndex == 0)
            {
                audioSource.PlayOneShot(backSound);
                SceneManager.LoadScene(1);
            }
                
            else
            {
                DBClick backButtonScript = GameObject.Find("back").GetComponent<DBClick>();

                if (backButtonScript != null)
                {
                    audioSource.PlayOneShot(backSound);
                    SceneManager.LoadScene(backButtonScript.nextScene);
                }
            }
                
        }
    }
}
