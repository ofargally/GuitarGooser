using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{

    public AudioSource theMusic;
    public float songStartTime;

    public bool startPlaying;

    public static GameManager instance;

    public BeatScroller theBS;

    public int currentScore;
    public int opponentScore;


    public int scorePerNote = 100;

    public int currentMultiplier;
    public int multiplierTracker;
    public int[] multiplierThresholds;

    public Text scoreText;

    public Text multiText;

    public bool playerAttack;
    public bool opponentAttack;
    public bool gameOver;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            scoreText.text = "Score: 0";
            currentMultiplier = 1;
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
                theBS.hasStarted = true;
                songStartTime = Time.time;
                theMusic.Play();
            }
        }
        //check if song is over, if so set game over to true
        if (startPlaying && !gameOver && Time.time - songStartTime >= theMusic.clip.length)
        {
            gameOver = true;
        }
    }

    public void NoteHit()
    {
        Debug.Log("Hit on time");
        if (currentMultiplier - 1 < multiplierThresholds.Length)
        {
            multiplierTracker++;

            if (multiplierThresholds[currentMultiplier - 1] <= multiplierTracker)
            {
                multiplierTracker = 0;
                currentMultiplier++;
            }

        }

        multiText.text = "Multiplier: x" + currentMultiplier;

        currentScore += scorePerNote * currentMultiplier;
        scoreText.text = "Score: " + currentScore;
        int opScoreChance = Random.Range(0, 10);
        if (opScoreChance > 2)
        {
            opponentScore += scorePerNote;
        }
    }

    public void NoteMiss()
    {
        Debug.Log("Missed note");

        currentMultiplier = 1;
        multiplierTracker = 0;
        multiText.text = "Multiplier: x" + currentMultiplier;

        int opScoreChance = Random.Range(0, 10);
        if (opScoreChance > 2)
        {
            opponentScore += scorePerNote;
        }
    }
}
