using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverPanel; // �� Panel ��� �� Game Over
    public Text gameOverText;

    void Start()
    {
        gameOverPanel.SetActive(false); // ������ ����������������
    }

    public void TriggerGameOver()
    {
        Debug.Log("Game Over Triggered"); // ������� �� � ������� ��������
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true); // ������������ ��� Panel
            if (gameOverText != null)
            {
                gameOverText.text = "Game Over!";
            }
            Time.timeScale = 0; // ������ ����������
        }
        else
        {
            Debug.LogError("Game Over Panel ��� ���� �������� ��� Inspector!");
        }
    }


    public void RestartGame()
    {
        Time.timeScale = 1; // ��������� ��� ������
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // ������������ ������
    }

    public void ExitGame()
    {
        Application.Quit(); // ������ ��� �� ��������
    }
}
