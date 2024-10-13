using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    void Update()
    {
        if (Input.anyKeyDown)
        {
            restartGame();
        }
    }
    public void restartGame()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
