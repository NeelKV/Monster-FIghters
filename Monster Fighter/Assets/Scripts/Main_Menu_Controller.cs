using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu_Controller : MonoBehaviour
{
    
    public TextMeshProUGUI text;
    private string LEVEL_SELECTION_SCENE = "Level Selection";
    private string CHARACTER_SELECTION_SCENE = "Character Selection";
    private string HOW_TO_PLAY_SCENE = "How To Play";

    
    private void Start()
    {
        text.text = "X" + Game_Manager.coin_Count;
    }
    public void Level_Selection()
    {
        SceneManager.LoadScene(LEVEL_SELECTION_SCENE);
    }

    public void Character_Selection()
    {
        SceneManager.LoadScene(CHARACTER_SELECTION_SCENE);
    }

    public void How_To_Play()
    {
        SceneManager.LoadScene(HOW_TO_PLAY_SCENE);
    }
}
