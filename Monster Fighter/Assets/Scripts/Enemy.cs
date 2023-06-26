using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed;

    private Rigidbody2D myBody;

    private int randomCoin;
    private string AXE_TAG = "Axe";
    private string COLLECTOR_TAG = "Collector";

    [SerializeField]
    private GameObject coinReference;
    private GameObject spawnedCoin;

    // Start is called before the first frame update
    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        myBody.velocity = new Vector2(speed, myBody.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(AXE_TAG))
        {
            Destroy(gameObject);
            spawnCoin(gameObject);
            Spawner.currentMonsterCount--;
            
        }

        if (collision.gameObject.CompareTag(COLLECTOR_TAG))
        {
            Destroy(gameObject);
            Spawner.currentMonsterCount--;
        }
    }

    private void spawnCoin(GameObject obj)
    {
        randomCoin = Random.Range(0, 5);
        if(randomCoin == 0)
        {
            spawnedCoin = Instantiate(coinReference);
            spawnedCoin.transform.position = obj.transform.position;
        }
    }




}
