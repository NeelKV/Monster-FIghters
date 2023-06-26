using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launch_Axe : MonoBehaviour
{
    [SerializeField]
    private GameObject axeReference;

    private GameObject spawnedAxe;

    private SpriteRenderer player_sr;
    private Transform player_transform;

    private string PLAYER_TAG = "Player";

    // Start is called before the first frame update
    void Start()
    {
        player_transform = GameObject.FindWithTag(PLAYER_TAG).transform;
        player_sr = GameObject.FindWithTag(PLAYER_TAG).GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawn_Axe()
    {
        spawnedAxe = Instantiate(axeReference);
        spawnedAxe.transform.position = player_transform.transform.position;
        
        if(player_sr.flipX)
        {
            spawnedAxe.GetComponent<Axe_behavior>().speed = -15f;
            spawnedAxe.GetComponent<SpriteRenderer>().flipX = true;
        } else
        {
            spawnedAxe.GetComponent<Axe_behavior>().speed = 15f;
        }
        Destroy(spawnedAxe, 5f);
    }
}
