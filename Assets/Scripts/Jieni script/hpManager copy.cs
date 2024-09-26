using UnityEngine;

public class hpManager : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite[] hpStates;
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
        if (gameManager.instance.playerAttack && !isPlayer)
        {
            gameManager.instance.playerAttack = false;
            if (currentFrame >= hpStates.Length - 1)
            {
                Debug.Log("you win");
                currentFrame = 0;
            }
            else
            {
                currentFrame++;
                spriteRenderer.sprite = hpStates[currentFrame];
            }
        }
        else if (gameManager.instance.opponentAttack && isPlayer)
        {
            gameManager.instance.opponentAttack = false;
            if (currentFrame >= hpStates.Length - 1)
            {
                Debug.Log("opponent win");
                currentFrame = 0;
            }
            else
            {
                currentFrame++;
                spriteRenderer.sprite = hpStates[currentFrame];
            }
        }
    }
}
