using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe_behavior : MonoBehaviour
{

    [SerializeField]
    public float speed;

    private Rigidbody2D myBody;
    

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
       
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        myBody.velocity = new Vector2 (speed, myBody.velocity.y);
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Collector"))
        {
            Destroy(gameObject);
        }
    }
}
