using System;
using System.Collections;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
public class PlayerAnimate : MonoBehaviour
{


    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }
    public Sprite[] playerIdleSprites;
    public Sprite[] HitUpSprites;
    public Sprite[] HitDownSprites;
    public Sprite[] HitLeftSprites;
    public Sprite[] HitRightSprites;

    public Sprite[] GettingDamageSprites;
    public float animationSpeed = 0.2f;
    private SpriteRenderer spriteRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void PlayerHit()
    {
        StartCoroutine(LoopThroughSprites(HitLeftSprites));
    }
    IEnumerator LoopThroughSprites(Sprite[] sprites)
    {
        int index = 0;
        while (sprites != null && sprites.Length > 0)
        {
            spriteRenderer.sprite = sprites[index];
            index = (index + 1) % sprites.Length;
            yield return new WaitForSeconds(animationSpeed);
        }
    }
}
