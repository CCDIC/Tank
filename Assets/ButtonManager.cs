using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void RestartGame()
    {
        Time.timeScale = 1f; // »Ö¸´Ê±¼ä
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
