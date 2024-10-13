using UnityEngine;

public class MPManager : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    public Sprite mpBar;

    public Sprite[] mpStates;

    private int currentFrame = 0;

    public bool isPlayer;

    private int currentMp;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentMp = GameManager.instance.mp;

    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.mp > currentMp)
        {
            currentMp = GameManager.instance.mp;
            if (currentFrame < mpStates.Length - 1)
            {
                currentFrame++;
                spriteRenderer.sprite = mpStates[currentFrame];
                
            }
            
        }
        else if(GameManager.instance.mp == 0)
        {
            currentMp = 0;
            currentFrame = 0;
            spriteRenderer.sprite = mpStates[currentFrame];
        }
    }

}
