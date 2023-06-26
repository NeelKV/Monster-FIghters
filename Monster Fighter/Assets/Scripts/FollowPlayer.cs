using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    private Transform player;
    private Vector3 tempPos;

    [SerializeField]
    private float minX, maxX;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // LateUpdate is called once per frame after Update has been called
    void LateUpdate()
    {
       
        if(player ==null)
            return;

        tempPos = transform.position;
        tempPos.x = player.position.x;
        tempPos.y = player.position.y;

        if (tempPos.x < minX)
            tempPos.x = minX;
        if (tempPos.x > maxX)
            tempPos.x = maxX;

        transform.position = tempPos;
    }
}
