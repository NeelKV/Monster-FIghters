using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 10f;
    [SerializeField]
    private float jumpForce = 16f;
    
    private float movementX;

    private Rigidbody2D myBody;

    private SpriteRenderer sr;

    private Animator anim;
    private string RUN_ANIMATION = "Running";
    private string ATTACK_ANIMATION = "Attack";
    private string COIN_TAG = "Coin";
    private string GROUND_TAG = "Ground";
    private string ENEMY_TAG = "Enemy";
    private string GAME_OVER_SCENE = "Game Over";

    private bool isGrounded = true;
    private bool canAttack = true;

    private Launch_Axe launch_Axe;
    

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        launch_Axe = GetComponent<Launch_Axe>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyboard();
        AnimatePlayer();
        PlayerAttack();
    }

    private void FixedUpdate()
    {
        PlayerJump();
    }

    void PlayerMoveKeyboard()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;
    }

    void AnimatePlayer()
    {
        if(movementX > 0)
        {
            anim.SetBool(RUN_ANIMATION, true);
            sr.flipX = false;
        } 
        else if (movementX < 0)
        {
            anim.SetBool(RUN_ANIMATION, true);
            sr.flipX = true;
        } 
        else
        {
            anim.SetBool(RUN_ANIMATION, false);
        }
    }

    void PlayerJump()
    {
        if (Input.GetButtonDown("Vertical") && isGrounded)
        {
            isGrounded = false;
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        } 
    }

    void PlayerAttack()
    {
        if (Input.GetButtonDown("Jump") && canAttack)
        {
            canAttack = false;
            anim.SetBool(ATTACK_ANIMATION, true);
            launch_Axe.spawn_Axe();
        }

        if (Input.GetButtonUp("Jump"))
        {
            canAttack = true;
            anim.SetBool(ATTACK_ANIMATION, false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG))
        {
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag(ENEMY_TAG))
        {
            Destroy(gameObject);
            Game_Manager.coinCount(Coin_Manager.coinCount);
            if(SceneManager.GetActiveScene().name == "Level 1")
            {
                Game_Manager.Level_1_Won = false;
            } else if (SceneManager.GetActiveScene().name == "Level 2")
            {
                Game_Manager.Level_2_Won = false;
            }
            SceneManager.LoadScene(GAME_OVER_SCENE);
        }       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(COIN_TAG))
        {
            Destroy(collision.gameObject);
            Coin_Manager.instance.changeCount();
        }
    }
}
