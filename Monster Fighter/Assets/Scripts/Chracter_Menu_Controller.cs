using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class Chracter_Menu_Controller : MonoBehaviour
{

    int selectedChar;
    public TextMeshProUGUI text;

    public UnityEngine.UI.Button character2_button;
    public UnityEngine.UI.Button character3_button;
    public UnityEngine.UI.Button char2Unlock;
    public UnityEngine.UI.Button char3Unlock;

    

    private void Start()
    {
        text.text = "X" + Game_Manager.coin_Count;
        
        if(Game_Manager.char2Unlocked)
        {
            character2_button.interactable = true;
            Destroy(char2Unlock.gameObject);

        } else
        {
            character2_button.interactable = false;
        }
            
        if (Game_Manager.char3Unlocked)
        {
            character3_button.interactable = true;
            Destroy(char3Unlock.gameObject);
        } else
        {
            character3_button.interactable = false;
        }
        
        
        
    }



    public void returnToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void character1()
    {
        selectedChar = 0;
        Game_Manager.instance.CharIndex = selectedChar;
    }

    public void character2()
    {
        selectedChar = 1;
        Game_Manager.instance.CharIndex = selectedChar;
    }

    public void character3()
    {
        selectedChar = 2;
        Game_Manager.instance.CharIndex = selectedChar;
    }

    public void unlockChar2()
    {
        if(Game_Manager.coin_Count >= 10)
        {
            character2_button.interactable = true;
            Game_Manager.coinCount(-10);
            Game_Manager.char2Unlocked = true;
            Destroy(char2Unlock.gameObject);
        }
    }

    public void unlockChar3()
    {
        if (Game_Manager.coin_Count >= 20)
        {
            character3_button.interactable = true;
            Game_Manager.coinCount(-20);
            Game_Manager.char3Unlocked = true;
            Destroy(char3Unlock.gameObject);
        }
    }
}
