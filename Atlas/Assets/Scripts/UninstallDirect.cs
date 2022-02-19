using UnityEngine;

public class UninstallDirect : MonoBehaviour
{
    public int nextScene;

    private AudioSource audioSource;
    private AudioClip blackHoleSound;

    private void Start()
    {
        audioSource = GameObject.Find("sound_manager").GetComponent<AudioSource>();

        blackHoleSound = Resources.Load<AudioClip>("Sounds/black_hole");
    }

    private void OnTriggerEnter(Collider other)
    {
        audioSource.PlayOneShot(blackHoleSound);

        AppManagerScript.ChangeScene(gameObject, nextScene);
    }
}
