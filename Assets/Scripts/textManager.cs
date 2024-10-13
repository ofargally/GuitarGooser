using UnityEngine;

public class TextManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.startPlaying)
        {
            gameObject.SetActive(false);
        }
    }
}
