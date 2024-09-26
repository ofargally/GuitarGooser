using UnityEngine;

public class MPManager : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    public Sprite mpBar;

    public Sprite[] mpStates;

    private int currentFrame = 0;

    public bool isPlayer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayer)
        {
            if (GameManager.instance.currentScore > 99)
            {
                GameManager.instance.currentScore -= 100;
                if (currentFrame >= mpStates.Length - 1)
                {
                    currentFrame = 0;
                    GameManager.instance.playerAttack = true;
                    Debug.Log("player attack charged");
                }
                else
                {
                    currentFrame++;
                    spriteRenderer.sprite = mpStates[currentFrame];
                }
            }

        }
        else
        {
            if (GameManager.instance.opponentScore > 99)
            {
                GameManager.instance.opponentScore -= 100;
                if (currentFrame >= mpStates.Length - 1)
                {
                    currentFrame = 0;
                    GameManager.instance.opponentAttack = true;
                    Debug.Log("opponent attack charged");
                }
                else
                {
                    currentFrame++;
                    spriteRenderer.sprite = mpStates[currentFrame];
                }
            }
        }

    }

}
