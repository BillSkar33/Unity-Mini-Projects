using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverPanel; // Το Panel για το Game Over
    public Text gameOverText;

    void Start()
    {
        gameOverPanel.SetActive(false); // Αρχικά απενεργοποιημένο
    }

    public void TriggerGameOver()
    {
        Debug.Log("Game Over Triggered"); // Έλεγχος αν η μέθοδος καλείται
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true); // Ενεργοποίηση του Panel
            if (gameOverText != null)
            {
                gameOverText.text = "Game Over!";
            }
            Time.timeScale = 0; // Πάγωμα παιχνιδιού
        }
        else
        {
            Debug.LogError("Game Over Panel δεν έχει συνδεθεί στο Inspector!");
        }
    }


    public void RestartGame()
    {
        Time.timeScale = 1; // Επαναφορά του χρόνου
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Επαναφόρτωση σκηνής
    }

    public void ExitGame()
    {
        Application.Quit(); // Έξοδος από το παιχνίδι
    }
}
