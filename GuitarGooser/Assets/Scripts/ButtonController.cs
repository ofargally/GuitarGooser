using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private SpriteRenderer spRenderer;
    public Sprite defaultImage;
    public Sprite pressedImage;
    public KeyCode keyToPress;
    void Start()
    {
        spRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Key Down -> When the key is pressed down

        if (Input.GetKeyDown(keyToPress))
        {
            spRenderer.sprite = pressedImage;
        }
        //Key Up -> When the key is released
        if (Input.GetKeyUp(keyToPress))
        {
            spRenderer.sprite = defaultImage;
        }
    }
}
