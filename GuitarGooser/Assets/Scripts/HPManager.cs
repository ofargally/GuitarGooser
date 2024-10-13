using UnityEngine;
using UnityEngine.SceneManagement;

public class HPManager : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite[] hpStates;
    private int currentFrame = 0;
    public bool isPlayer;
    public int threshold = 100;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {

        if (!isPlayer)
        {
            if (currentFrame >= hpStates.Length - 2)
            {

                currentFrame = 0;
            }
            else
            {
                if (GameManager.instance.enemyHp < threshold)
                {
                    threshold -= 10;
                    currentFrame++;
                    spriteRenderer.sprite = hpStates[currentFrame];
                }
                
            }
        }
        else if (isPlayer)
        {
            if (currentFrame >= hpStates.Length - 2)
            {

                currentFrame = 0;
            }
            else
            {
                if (GameManager.instance.playerHp < threshold)
                {
                    threshold -= 10;
                    currentFrame++;
                    spriteRenderer.sprite = hpStates[currentFrame];
                }

            }
        }
    }
}
