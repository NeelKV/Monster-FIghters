using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour
{

    [SerializeField]
    private GameObject[] enemyReference;

    private GameObject spawnedEnemy;

    [SerializeField]
    private Transform posLeft, posRight, posCenter, posTop_left, posTop_Right;

    private int randomIndex, randomSide;

    private int monsterCount = 20;
    public static int currentMonsterCount = 0;

    private string GAME_OVER_SCENE = "Game Over";

    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnedMonster());
        if(monsterCount != 20)
        {
            monsterCount = 20;
        }

        if(currentMonsterCount != 0)
        {
            currentMonsterCount = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (monsterCount <= 0 && currentMonsterCount == 0)
        {
            if (SceneManager.GetActiveScene().name == "Level 1")
            {
                Game_Manager.Level_1_Won = true;
            }
            else if (SceneManager.GetActiveScene().name == "Level 2")
            {
                Game_Manager.Level_2_Won = true;
            }
            Game_Manager.coinCount(Coin_Manager.coinCount);
            SceneManager.LoadScene(GAME_OVER_SCENE);
        }
    }

    IEnumerator spawnedMonster()
    {
        while (monsterCount > 0)
        {
            yield return new WaitForSeconds(Random.Range(1, 5));

            randomIndex = Random.Range(0, enemyReference.Length);
            randomSide = Random.Range(0, 5);

            spawnedEnemy = Instantiate(enemyReference[randomIndex]);
            monsterCount--;
            currentMonsterCount++;
            Debug.Log("Monster created reducing monster count by 1: " + monsterCount + " increasing current conster count by 1: " + currentMonsterCount);

            if (randomSide == 0)
            {
                spawnedEnemy.transform.position = posLeft.position;
                spawnedEnemy.GetComponent<Enemy>().speed = Random.Range(4, 8);
            }
            else if (randomSide == 1)
            {
                spawnedEnemy.transform.position = posRight.position;
                spawnedEnemy.GetComponent<Enemy>().speed = -Random.Range(4, 8);
                spawnedEnemy.GetComponent<SpriteRenderer>().flipX = true;
            }
            else if (randomSide == 2)
            {
                spawnedEnemy.transform.position = posTop_left.position;

                if (Random.Range(0, 2) == 0)
                {
                    spawnedEnemy.GetComponent<Enemy>().speed = Random.Range(4, 8);
                }
                else
                {
                    spawnedEnemy.GetComponent<Enemy>().speed = -Random.Range(4, 8);
                    spawnedEnemy.GetComponent<SpriteRenderer>().flipX = true;
                }
            }
            else if (randomSide == 3)
            {
                spawnedEnemy.transform.position = posTop_Right.position;

                if (Random.Range(0, 2) == 0)
                {
                    spawnedEnemy.GetComponent<Enemy>().speed = Random.Range(4, 8);
                }
                else
                {
                    spawnedEnemy.GetComponent<Enemy>().speed = -Random.Range(4, 8);
                    spawnedEnemy.GetComponent<SpriteRenderer>().flipX = true;
                }
            }
            else
            {
                spawnedEnemy.transform.position = posCenter.position;

                if (Random.Range(0, 2) == 0)
                {
                    spawnedEnemy.GetComponent<Enemy>().speed = Random.Range(4, 8);
                }
                else
                {
                    spawnedEnemy.GetComponent<Enemy>().speed = -Random.Range(4, 8);
                    spawnedEnemy.GetComponent<SpriteRenderer>().flipX = true;
                }
            }
        }
        Debug.Log("while loop ended");
    }
}
