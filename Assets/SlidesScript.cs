using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class SlidesScript : MonoBehaviour
{
    public InputActionProperty NextSlideButton;
    public InputActionProperty PrevSlideButton;
    public Image primarySlideImage;
    public Image secondarySlideImage;
    public TMP_Dropdown slideDropdown;
    int i = 0;
    public List<Sprite> slidesSpriteList1 = new();
    public List<Sprite> slidesSpriteList2 = new();
    public List<Sprite> slidesSpriteList3 = new();
    public List<List<Sprite>> AllSlidesList = new();


    void Start()
    {
        AllSlidesList.Add(slidesSpriteList1);
        AllSlidesList.Add(slidesSpriteList2);
        AllSlidesList.Add(slidesSpriteList3);

        slideDropdown.value = PlayerPrefs.GetInt("SlidePosition");

        primarySlideImage.sprite = AllSlidesList[slideDropdown.value][0];
        secondarySlideImage.sprite = AllSlidesList[slideDropdown.value][0];
    }

    void Update()
    {
        if (NextSlideButton.action.WasPressedThisFrame())
        {
            if (i < AllSlidesList[slideDropdown.value].Count-1)
            {
                i++;
                primarySlideImage.sprite = AllSlidesList[slideDropdown.value][i];
                secondarySlideImage.sprite = AllSlidesList[slideDropdown.value][i];
            }
            
        }
        else if(PrevSlideButton.action.WasPressedThisFrame()) 
        {
            if(i > 0)
            {
                i--;
                primarySlideImage.sprite = AllSlidesList[slideDropdown.value][i];
                secondarySlideImage.sprite = AllSlidesList[slideDropdown.value][i];
            }

        }
    }

    //PlayerPrefs updates the position of the current slide on the slide dropdown.
    public void UpdateSlidePosition()
    {
        PlayerPrefs.SetInt("SlidePosition", slideDropdown.value);
        primarySlideImage.sprite = AllSlidesList[slideDropdown.value][0];
        secondarySlideImage.sprite = AllSlidesList[slideDropdown.value][0];
    }


}
