using UnityEngine;

public class NoteObject : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public bool canBePressed;
    public KeyCode keyToPress;

    public float beatTempo;

    public int ArrowDirection;
    private bool obtained = false;

    public GameObject hitEffect, missEffect;

    void Start()
    {
        beatTempo /= 60f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToPress) && canBePressed)
        {
            GameManager.instance.NoteHit();
            obtained = true;
            gameObject.SetActive(false);
            GameObject hitEffectObj = Instantiate(hitEffect, transform.position, hitEffect.transform.rotation);
            Destroy(hitEffectObj, 1f);
        }
        //Left Arrow -> Moving to the right from negative X to Positive X
        if (ArrowDirection == 0)
        {
            transform.position += new Vector3(beatTempo * Time.deltaTime, 0f, 0f);
        }

        //Down
        else if (ArrowDirection == 1)
        {
            transform.position += new Vector3(0f, beatTempo * Time.deltaTime, 0f);
        }
        //Up
        else if (ArrowDirection == 2)
        {
            transform.position -= new Vector3(0f, beatTempo * Time.deltaTime, 0f);
        }
        //Right -> 3
        else
        {
            transform.position -= new Vector3(beatTempo * Time.deltaTime, 0f, 0f);
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
                gameObject.SetActive(false);
                GameObject missEffectobj = Instantiate(missEffect, transform.position, missEffect.transform.rotation);
                Destroy(missEffectobj, 1f);
            }
        }
    }
}
