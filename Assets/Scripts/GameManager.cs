using UnityEngine;

public class GameManager : MonoBehaviour
{
    public AudioSource musicSource;
    public bool startPlaying;
    public BeatScroller beatScroller;

    public static GameManager instance;
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (!startPlaying)
        {
            if (Input.anyKeyDown)
            {
                startPlaying = true;
                beatScroller.hasStarted = true;
                musicSource.Play();
            }
        }
    }

    public void NoteHit()
    {
        Debug.Log("Note Hit!");
    }
    public void NoteMissed()
    {
        Debug.Log("Note Missed!");
    }
}
