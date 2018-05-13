using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour {

    public void Arena1()
    {
        SceneManager.LoadScene("arena1");
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

}
