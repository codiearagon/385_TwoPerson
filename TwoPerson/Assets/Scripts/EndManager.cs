using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndManager : MonoBehaviour
{
    [SerializeField] private TMP_Text statusText;

    private GameManager gameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameManager.Instance;

        if (gameManager.win)
            statusText.text = "You win!";
        else
            statusText.text = "You lose!";
    }

    public void RestartGame()
    {
        Destroy(GameManager.Instance.gameObject);
        GameManager.Instance = null;
        SceneManager.LoadScene("Main");
    }
}
