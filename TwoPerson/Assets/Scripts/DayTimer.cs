using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DayTimer : MonoBehaviour
{
    [SerializeField] private Slider dayTimer;
    [SerializeField] private GameObject potato;

    private GameManager gameManager;

    private float dayLength = 10.0f; // day length in seconds
    private bool isDay;

    void Start()
    {
        gameManager = GameManager.Instance;
        NewDay();
        
    }

    void NewDay()
    {
        isDay = true;

        dayTimer.maxValue = dayLength;
        dayTimer.value = 0;

        gameManager.NextDay();

        StartCoroutine(Countdown());

        if(potato.GetComponent<EnemySpawner>().spawnInterval > 2f)
        {
            potato.GetComponent<EnemySpawner>().spawnInterval -= 1f; // Decrease spawn interval for enemies
        }
    }

    void DayEnd()
    {
        isDay = false;

        StartCoroutine(CountUntilNextDay());
    }

    IEnumerator CountUntilNextDay()
    {
        int timer = 0;

        while (!isDay)
        {
            yield return new WaitForSeconds(1f);
            timer += 1;
            Debug.Log(timer);

            if (timer >= 2f)
            {
                NewDay();
            }
        }
    }

    IEnumerator Countdown()
    {
        while(isDay)
        {
            yield return new WaitForSeconds(1f);
            dayTimer.value += 1;

            if(dayTimer.value >= dayLength)
            {
                DayEnd();
            }

        }
    }
}
