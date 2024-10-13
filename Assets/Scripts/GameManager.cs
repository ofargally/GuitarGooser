using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public AudioSource theMusic;
    public float songStartTime;

    public bool startPlaying;

    public static GameManager instance;

    public PlayerAnimate player;
    public PlayerAnimate enemy;

    public int currentScore;
    public int opponentScore;


    public int scorePerNote = 1;

    public int currentMultiplier;
    public int multiplierTracker;
    public int[] multiplierThresholds;

    public Text scoreText;

    public Text multiText;

    public bool playerAttack;
    public bool opponentAttack;
    public bool gameOver;

    public int playerHp;
    public int enemyHp;
    public int enemyMult;
    public int mp = 0;

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
                songStartTime = Time.time;
                theMusic.Play();
            }
        }
        //check if song is over, if so set game over to true
        if (startPlaying && !gameOver && Time.time - songStartTime >= theMusic.clip.length)
        {
            gameOver = true;
        }

        if (playerHp < 0)
        {
            Debug.Log("opponent win");
            SceneManager.LoadSceneAsync(1);
        }

        if (enemyHp < 0)
        {
            Debug.Log("you win");
            SceneManager.LoadSceneAsync(2);
        }

        if (mp > 7)
        {
            playerAttack = true;
            Debug.Log("player can attack now");
        }
    }

    public void NoteHit()
    {
        mp++;
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

        if (playerAttack)
        {
            enemyHp -= scorePerNote * currentMultiplier;
        }

    }
    public void NoteMiss()
    {
        mp = 0;
        Debug.Log("Missed note");

        currentMultiplier = 1;
        multiplierTracker = 0;
        multiText.text = "Multiplier: x" + currentMultiplier;
        playerHp -= scorePerNote * enemyMult;
    }
}
