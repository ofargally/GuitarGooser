using UnityEngine;
using UnityEngine.UI;
public class gameManager : MonoBehaviour


{

    public AudioSource theMusic;

    public bool startPlaying;

    public static gameManager instance;

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


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        instance = this;
        scoreText.text = "Score: 0";
        currentMultiplier = 1;
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

                theMusic.Play();
            }
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
        if(opScoreChance > 2)
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
