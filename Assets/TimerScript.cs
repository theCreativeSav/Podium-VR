using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime;
    public GameObject popUpMenu;
    public GameObject StopSessionScreen;
    public GameObject startSessButton;
    public GameObject stopSessButton;
    public TMP_Dropdown timerDropDown;


    private void Start()
    {
        timerDropDown.value = PlayerPrefs.GetInt("TimerPosition");
    }
    void Update()
    {
        //Every frame, the script checks the value of the remaining time
        //to determine whether to stop the timer or keep it going.
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;                  
        }
        else if (remainingTime < 0) 
        { 
            remainingTime = 0;
            startSessButton.SetActive(true);
            stopSessButton.SetActive(false);
            ShowSessionEndedScreen();
            popUpMenu.SetActive(true);
        }
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

    }

    public void StartSession()
    {
        switch (timerDropDown.value)
        {
            case 0:
                remainingTime = 60;
                break;
            case 1:
                remainingTime = 180;
                break;
            case 2:
                remainingTime = 300;    
                break;
            case 3:
                remainingTime = 600;
                break;
            default: 
                remainingTime = 15; 
                break;
        }


        remainingTime += 1;
        startSessButton.SetActive(false);
        stopSessButton.SetActive(true);

        popUpMenu.SetActive(false);
    }

    public void StopSession() 
    {
        remainingTime = 0;
        startSessButton.SetActive(true);
        stopSessButton.SetActive(false);
    }

    public void ShowSessionEndedScreen()
    {
        StopSessionScreen.SetActive(true);
    }

    public void UpdateTimerPosition()
    {
        PlayerPrefs.SetInt("TimerPosition", timerDropDown.value);
    }

}
