using UnityEngine;
using UnityEngine.SceneManagement;

public class HPManager : MonoBehaviour
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
        if (GameManager.instance.playerAttack && !isPlayer)
        {
            GameManager.instance.playerAttack = false;
            if (currentFrame >= hpStates.Length - 1)
            {
                Debug.Log("you win");
                SceneManager.LoadSceneAsync(2);
                currentFrame = 0;
            }
            else
            {
                currentFrame++;
                spriteRenderer.sprite = hpStates[currentFrame];
            }
        }
        else if (GameManager.instance.opponentAttack && isPlayer)
        {
            GameManager.instance.opponentAttack = false;
            if (currentFrame >= hpStates.Length - 1)
            {
                Debug.Log("opponent win");
                SceneManager.LoadSceneAsync(1);
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
