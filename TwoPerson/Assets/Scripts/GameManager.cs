using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool win;

    [SerializeField] private TMP_Text dayCountText;

    private float dayCount = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if(Instance == null)
            Instance = this;

        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextDay()
    {
        dayCount++;
        dayCountText.text = "Day " + dayCount;

        if(dayCount > 7)
        {
            win = true;
            SceneManager.LoadScene("End");
        }

    }
}
