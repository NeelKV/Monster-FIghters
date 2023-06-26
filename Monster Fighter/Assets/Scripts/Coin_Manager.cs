using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Coin_Manager : MonoBehaviour
{
    public static Coin_Manager instance;
    public TextMeshProUGUI text;
    public static int coinCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        if(coinCount !=0 )
        {
            coinCount = 0;
        }
    }

    public void changeCount()
    {
        coinCount++;
        text.text = "X" + coinCount.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
