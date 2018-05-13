using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour {

    public GameObject MainMenu;
    public GameObject PlayMenu;
    public GameObject OptionsMenu;

    private void Start()
    {
        showMenu();
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void showPlay()
    {
        for (int i = 0; i < OptionsMenu.transform.childCount; i++)
        {
            OptionsMenu.transform.GetChild(i).gameObject.SetActive(false);
        }
        for (int i = 0; i < PlayMenu.transform.childCount; i++)
        {
            PlayMenu.transform.GetChild(i).gameObject.SetActive(true);
        }
        for (int i = 0; i < MainMenu.transform.childCount; i++)
        {
            MainMenu.transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    public void showOptions()
    {
        for (int i = 0; i < OptionsMenu.transform.childCount; i++)
        {
            OptionsMenu.transform.GetChild(i).gameObject.SetActive(true);
        }
        for (int i = 0; i < PlayMenu.transform.childCount; i++)
        {
            PlayMenu.transform.GetChild(i).gameObject.SetActive(false);
        }
        for (int i = 0; i < MainMenu.transform.childCount; i++)
        {
            MainMenu.transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    public void showMenu()
    {
        for (int i = 0; i < OptionsMenu.transform.childCount; i++)
        {
            OptionsMenu.transform.GetChild(i).gameObject.SetActive(false);
        }
        for (int i = 0; i < PlayMenu.transform.childCount; i++)
        {
            PlayMenu.transform.GetChild(i).gameObject.SetActive(false);
        }
        for (int i = 0; i < MainMenu.transform.childCount; i++)
        {
            MainMenu.transform.GetChild(i).gameObject.SetActive(true);
        }
    }
}

