using UnityEngine;

public class NoteObject : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public bool canBePressed;
    public KeyCode keyToPress;
    private bool obtained = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToPress) && canBePressed)
        {
            GameManager.instance.NoteHit();
            obtained = true;
            gameObject.SetActive(false);


        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Activator"))
        {
            canBePressed = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Activator"))
        {
            canBePressed = false;
            if (!obtained)
            {
                GameManager.instance.NoteMiss();
            }
        }
    }
}
