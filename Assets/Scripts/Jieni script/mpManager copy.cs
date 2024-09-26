using UnityEngine;

public class mpManager : MonoBehaviour
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
            if (gameManager.instance.currentScore > 99)
            {
                gameManager.instance.currentScore -= 100;
                if (currentFrame >= mpStates.Length - 1)
                {
                    currentFrame = 0;
                    gameManager.instance.playerAttack = true;
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
            if (gameManager.instance.opponentScore > 99)
            {
                gameManager.instance.opponentScore -= 100;
                if (currentFrame >= mpStates.Length - 1)
                {
                    currentFrame = 0;
                    gameManager.instance.opponentAttack = true;
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
