using System;
using UnityEngine;

public class PlayerAnimate : MonoBehaviour
{
    private float timer = 0f;
    public int currentFrame = 0;
    public float frameRate = 0.1f;
    public float idleFrameRate = 0.2f;
    private SpriteRenderer spriteRenderer;

    // Sprite Arrays
    public Sprite[] playerIdleSprites;
    public Sprite[] HitUpSprites;
    public Sprite[] HitLeftSprites;
    public Sprite[] HitRightSprites;
    public Sprite[] GettingDamageSprites;

    public bool triggerGetHitAnimation = false;
    public bool triggerHitAnimation = false;

    // Animation State Variables
    private bool isAnimating = false;
    private Sprite[] currentAnimationFrames;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (playerIdleSprites.Length > 0)
        {
            spriteRenderer.sprite = playerIdleSprites[0]; // Initialize with first idle sprite
        }
        else
        {
            Debug.LogError("PlayerIdleSprites array is empty. Please assign sprites in the Inspector.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (gameObject.CompareTag("Player"))
        {
            ExecutePlayerUpdate();
        }
        else
        {
            ExecuteEnemyUpdate();
        }

        // Continue Animating if an Animation is Active
        if (isAnimating)
        {
            Animate();
        }
        else
        {
            // Handle Idle Animation Loop
            HandleIdleAnimation();
        }
    }

    void ExecutePlayerUpdate()
    {
        timer += Time.deltaTime;
        //Handle Animation for Receiving Damage
        if (triggerGetHitAnimation && !isAnimating)
        {
            // Enemy is getting hit
            if (GettingDamageSprites.Length > 0)
            {
                StartAnimation(GettingDamageSprites);
                triggerGetHitAnimation = false; // Reset the flag
            }
            else
            {
                Debug.LogError("GettingDamageSprites array is empty. Please assign sprites in the Inspector.");
            }
        }
        // Handle Input for Hit Animations
        if (Input.GetKeyDown(KeyCode.UpArrow) && !isAnimating)
        {
            if (HitUpSprites.Length > 0)
            {
                StartAnimation(HitUpSprites);
            }
            else
            {
                Debug.LogError("HitUpSprites array is empty. Please assign sprites in the Inspector.");
            }
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && !isAnimating)
        {
            if (HitUpSprites.Length > 0)
            {
                StartAnimation(HitUpSprites);
            }
            else
            {
                Debug.LogError("HitDownSprites array is empty. Please assign sprites in the Inspector.");
            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && !isAnimating)
        {
            if (HitLeftSprites.Length > 0)
            {
                StartAnimation(HitLeftSprites);
            }
            else
            {
                Debug.LogError("HitLeftSprites array is empty. Please assign sprites in the Inspector.");
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && !isAnimating)
        {
            if (HitRightSprites.Length > 0)
            {
                StartAnimation(HitRightSprites);
            }
            else
            {
                Debug.LogError("HitRightSprites array is empty. Please assign sprites in the Inspector.");
            }
        }
    }
    void ExecuteEnemyUpdate()
    {
        if (triggerHitAnimation && !isAnimating)
        {
            // Enemy is hitting the player
            if (HitLeftSprites.Length > 0) // Choose appropriate animation
            {
                StartAnimation(HitLeftSprites);
                triggerHitAnimation = false; // Reset the flag
            }
            else
            {
                Debug.LogError("HitLeftSprites array is empty. Please assign sprites in the Inspector.");
            }
        }

        if (triggerGetHitAnimation && !isAnimating)
        {
            // Enemy is getting hit
            if (GettingDamageSprites.Length > 0)
            {
                StartAnimation(GettingDamageSprites);
                triggerGetHitAnimation = false; // Reset the flag
            }
            else
            {
                Debug.LogError("GettingDamageSprites array is empty. Please assign sprites in the Inspector.");
            }
        }
    }
    // Start the specified animation
    void StartAnimation(Sprite[] frames)
    {
        if (frames == null || frames.Length == 0)
        {
            Debug.LogError("Animation frames are null or empty.");
            return;
        }

        isAnimating = true;
        currentAnimationFrames = frames;
        currentFrame = 0;
        timer = 0f;
        spriteRenderer.sprite = currentAnimationFrames[currentFrame];
    }

    // Animate the current animation frames
    void Animate()
    {
        if (timer >= frameRate)
        {
            timer -= frameRate; // Subtract frameRate to handle any excess time
            currentFrame++;

            if (currentFrame < currentAnimationFrames.Length)
            {
                spriteRenderer.sprite = currentAnimationFrames[currentFrame];
            }
            else
            {
                // Animation Complete
                isAnimating = false;
                currentFrame = 0;
                timer = 0f;

                // Revert to Idle Sprite
                if (playerIdleSprites.Length > 0)
                {
                    spriteRenderer.sprite = playerIdleSprites[0];
                }
                else
                {
                    Debug.LogError("PlayerIdleSprites array is empty. Please assign sprites in the Inspector.");
                }
            }
        }
    }

    // Handle looping idle animations
    void HandleIdleAnimation()
    {
        if (playerIdleSprites.Length == 0)
            return;

        if (timer >= idleFrameRate)
        {
            timer -= idleFrameRate;
            currentFrame++;

            if (currentFrame < playerIdleSprites.Length)
            {
                spriteRenderer.sprite = playerIdleSprites[currentFrame];
            }
            else
            {
                currentFrame = 0;
                spriteRenderer.sprite = playerIdleSprites[currentFrame];
            }
        }
    }
}
