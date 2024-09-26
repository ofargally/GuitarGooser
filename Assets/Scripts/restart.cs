using UnityEngine;
using UnityEngine.SceneManagement;

public class restart : MonoBehaviour
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
