using UnityEngine;

public class GameManager : MonoBehaviour
{
    public AudioSource musicSource;
    public float songStartTime;
    public bool startPlaying;
    public BeatScroller beatScroller;

    public bool gameOver;

    public static GameManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
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
                songStartTime = Time.time;
            }
        }
        //check if song is over, if so set game over to true
        if (startPlaying && !gameOver && Time.time - songStartTime >= musicSource.clip.length)
        {
            gameOver = true;
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
