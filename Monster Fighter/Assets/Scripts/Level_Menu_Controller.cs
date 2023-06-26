using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class Level_Menu_Controller : MonoBehaviour
{
    private string LEVEL_1_SCENE = "Level 1";
    private string LEVEL_2_SCENE = "Level 2";
    private string LEVEL_3_SCENE = "Level 3";
    private string MAIN_MENU_SCENE = "Main Menu";

    public UnityEngine.UI.Button Level_2;
    public UnityEngine.UI.Button Level_3;

    private void Start()
    {
        if (Game_Manager.Level_1_Won)
        {
            Level_2.interactable = true;
        }
        else
        {
            Level_2.interactable = false;
        }

        if (Game_Manager.Level_2_Won)
        {
            Level_3.interactable = true;
        }
        else
        {
            Level_3.interactable = false;
        }
    }

    public void returnToMainMenu()
    {
        SceneManager.LoadScene(MAIN_MENU_SCENE);
    }

    public void level1()
    {
        SceneManager.LoadScene(LEVEL_1_SCENE);
    }

    public void level2()
    {
        SceneManager.LoadScene(LEVEL_2_SCENE);
    }

    public void level3()
    {
        SceneManager.LoadScene(LEVEL_3_SCENE);
    }



}
