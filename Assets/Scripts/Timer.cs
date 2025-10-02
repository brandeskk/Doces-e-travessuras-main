using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TMP_Text timerText;

    float timerRemaining = 60f;
    bool timerIsRunning = true;

    public GameObject panelLose; 

    void Start ()
    {
        panelLose.SetActive(false);
    }
    void Update()
    {
        if (timerIsRunning)
        {
            if (timerRemaining > 0)
            {
                timerRemaining -= Time.deltaTime;
                UpdateTimerDisplay(timerRemaining);
                
            }
            else
            {
                timerRemaining = 0;
                timerIsRunning = false;
                panelLose.SetActive(true); 
                UpdateTimerDisplay(0);                

            }
        }
    }

    void UpdateTimerDisplay(float timeToDisplay)
    {
        int minutes = Mathf.FloorToInt(timeToDisplay / 60);
        int seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}


