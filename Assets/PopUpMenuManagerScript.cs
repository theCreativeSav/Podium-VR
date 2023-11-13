using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class MenuManagerScript : MonoBehaviour
{

    public GameObject timerScreen, timerCanvas, primarySlides, primarySlideImage, secondarySlides, secondarySlideImage, podiumStand, StandingMic;
    public GameObject popUpmenu;
    public InputActionProperty showPopUpButton;
    public Transform head;
    public float popUpMenuSpawnDistance = 1.5f;
    public TMP_Dropdown timerDropDown;
    public TMP_Dropdown slideDropdown;


    void Start()
    {

    }
 
    void Update()
    {
        if (showPopUpButton.action.WasPressedThisFrame())
        {
            popUpmenu.SetActive(!popUpmenu.activeSelf);
            popUpmenu.transform.position = head.position + new Vector3(head.forward.x, 0, head.forward.z).normalized * popUpMenuSpawnDistance;

        }

        popUpmenu.transform.LookAt(new Vector3(head.position.x, popUpmenu.transform.position.y, head.position.z));
        popUpmenu.transform.forward *= -1;
    }

 

    public void ShowTimer()
    {

        timerScreen.SetActive(!timerScreen.activeSelf);
        timerCanvas.SetActive(!timerCanvas.activeSelf);
    }

    public void ShowPrimarySlides()
    {
        primarySlides.SetActive(!primarySlides.activeSelf);
        primarySlideImage.SetActive(!primarySlideImage.activeSelf);


    }
    public void ShowSecondarySlides()
    {
        secondarySlides.SetActive(!secondarySlides.activeSelf);
        secondarySlideImage.SetActive(!secondarySlideImage.activeSelf);
    }

    public void ShowPodiumStand()
    {
        podiumStand.SetActive(!podiumStand.activeSelf);
    }

    public void ShowStandingMic()
    {
        StandingMic.SetActive(!StandingMic.activeSelf);
    }

    public void NavigateToScene(TMP_Text sceneName)
    {
        SceneManager.LoadScene(sceneName.text);
    }


}
