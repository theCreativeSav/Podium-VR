using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class MainMenuManagerScript : MonoBehaviour
{
    private int i;
    public GameObject mainMenu;
    public GameObject scenarioMenu;
    public TMP_Dropdown slideDropdown, timerDropdown;


    public TMP_Text scenarioTitle;

    public Button scenarioMenuButton, trainingsMenuButton, settingsMenuButton, rateMenuButton;

    public GameObject scenarioSidePanel, trainingsSidePanel, settingsSidePanel, rateSidePanel;


    public Color Transpcolor = new Color(255, 255, 255, 0);
    public Image scenarioImage;

    public List<Sprite> scenarioImagesList = new List<Sprite>();


    private List<string> scenarioList = new List<string>();


    // Start is called before the first frame update
    void Start()
    {
        scenarioList.Add("Pitch Presentation");
        scenarioList.Add("Keynote Speech");
        scenarioList.Add("Panel Session");
        scenarioList.Add("Extra Scenario");


        i = 0;

        //transparency level of the inactive buttons
        Transpcolor.a = 0.1f;

        timerDropdown.value = PlayerPrefs.GetInt("SlidePosition");
        slideDropdown.value = PlayerPrefs.GetInt("TimerPosition");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BackToHome()
    {
        mainMenu.SetActive(true);
        scenarioMenu.SetActive(false);
    }

    public void EnterScenarioMenu(int j)
    {
        i = j;
        scenarioTitle.text = scenarioList[i];
        scenarioImage.sprite = scenarioImagesList[i];
        mainMenu.SetActive(false);
        scenarioMenu.SetActive(true);
    }


    public void ScenarioScrollerRight()
    {

        if (i <= scenarioList.Count - 2)
        {
            i++;

            scenarioTitle.text = scenarioList[i];
            scenarioImage.sprite = scenarioImagesList[i];
        }
        else
        {
            i = 0;
            scenarioTitle.text = scenarioList[i];
            scenarioImage.sprite = scenarioImagesList[i];
        }

    }
    public void ScenarioScrollerLeft()
    {
        if (i <= 0)
        {
            i = scenarioList.Count - 1;
            scenarioTitle.text = scenarioList[i];
            scenarioImage.sprite = scenarioImagesList[i];
        }
        else
        {
            i--;
            scenarioTitle.text = scenarioList[i];
            scenarioImage.sprite = scenarioImagesList[i];

        }

    }

    public void NavigateToScene(TMP_Text sceneName)
    {
        SceneManager.LoadScene(sceneName.text);
    }


    public void UpdateTimerPosition()
    {
        PlayerPrefs.SetInt("TimerPosition", timerDropdown.value);
    }

    public void UpdateSlidePosition()
    {
        PlayerPrefs.SetInt("SlidePosition", slideDropdown.value);
    }


    public void MakescenarioButtonActive()
    {
        scenarioMenuButton.image.color = new Color(255, 255, 255, 225);
        trainingsMenuButton.image.color = Transpcolor;
        settingsMenuButton.image.color = Transpcolor;
        rateMenuButton.image.color = Transpcolor;
        scenarioSidePanel.SetActive(true);
        trainingsSidePanel.SetActive(false);
        settingsSidePanel.SetActive(false);
        rateSidePanel.SetActive(false);
    }
    public void MaketrainingsButtonActive()
    {
        scenarioMenuButton.image.color = Transpcolor;
        trainingsMenuButton.image.color = new Color(255, 255, 255, 255);
        settingsMenuButton.image.color = Transpcolor;
        rateMenuButton.image.color = Transpcolor;
        scenarioSidePanel.SetActive(false);
        trainingsSidePanel.SetActive(true);
        settingsSidePanel.SetActive(false);
        rateSidePanel.SetActive(false);
    }
    public void MakesettingsButtonActive()
    {
        scenarioMenuButton.image.color = Transpcolor;
        trainingsMenuButton.image.color = Transpcolor;
        settingsMenuButton.image.color = new Color(255, 255, 255, 255);
        rateMenuButton.image.color = Transpcolor;
        scenarioSidePanel.SetActive(false);
        trainingsSidePanel.SetActive(false);
        settingsSidePanel.SetActive(true);
        rateSidePanel.SetActive(false);
    }
    public void MakerateButtonActive()
    {
        scenarioMenuButton.image.color = Transpcolor;
        trainingsMenuButton.image.color = Transpcolor;
        settingsMenuButton.image.color = Transpcolor;
        rateMenuButton.image.color = new Color(255, 255, 255, 255);
        scenarioSidePanel.SetActive(false);
        trainingsSidePanel.SetActive(false);
        settingsSidePanel.SetActive(false);
        rateSidePanel.SetActive(true);

    }
}
