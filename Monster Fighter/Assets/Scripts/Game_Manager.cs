using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour
{
    public static Game_Manager instance;
    
    [SerializeField]
    private GameObject[] playerCharacters;

    private GameObject spawnedPlayer;

    public static int coin_Count= 0;

    public static bool Level_1_Won = false;
    public static bool Level_2_Won = false;

    public static bool char2Unlocked = false;
    public static bool char3Unlocked = false;

    private int char_Index;
    public int CharIndex
    { 
        get { return char_Index; } 
        set { char_Index = value; }
    }


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }


    public static void coinCount(int count) {
        coin_Count += count; 
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        if(scene.name == "Level 1")
        {
            spawnedPlayer = Instantiate(playerCharacters[char_Index]);
            spawnedPlayer.transform.position = new Vector3(0, -2, 0);
        }

        if(scene.name == "Level 2")
        {
            spawnedPlayer = Instantiate(playerCharacters[char_Index]);
            spawnedPlayer.transform.position = new Vector3(-6, -1, 0);
        }

        if(scene.name == "Level 3")
        {
            spawnedPlayer = Instantiate(playerCharacters[char_Index]);
            spawnedPlayer.transform.position = new Vector3(0, -1, 0);
        }
    }
}
