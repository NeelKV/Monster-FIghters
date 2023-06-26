using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Over_Controller : MonoBehaviour
{
    public TextMeshProUGUI text;

    private string MAIN_MENU_SCENE = "Main Menu";


    private void Start()
    {
        text.text = "X" + Game_Manager.coin_Count;
    }

    public void returnToMainMenu()
    {
        SceneManager.LoadScene(MAIN_MENU_SCENE);
    }
}
