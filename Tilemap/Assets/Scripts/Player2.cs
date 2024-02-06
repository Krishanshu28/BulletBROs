using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;
public class Player2 : MonoBehaviour
{
    
        Vector2 inputMove;
        public Rigidbody2D myrigidbody2D;
        Animator myAnimaitor;
        LayerMask platform;
        CapsuleCollider2D player_collider;

    public static Player2 instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
        float Speed = 10.0f;

        // Start is called before the first frame update
        void Start()
        {
            myrigidbody2D = GetComponent<Rigidbody2D>();
            myAnimaitor = GetComponent<Animator>();
            player_collider = GetComponent<CapsuleCollider2D>();
        }

        // Update is called once per frame
        void Update()
        {
        
        flipper();
            Run();
    }

        void OnMove(InputValue value)
        {
            inputMove = value.Get<Vector2>();
        }

        void OnJump(InputValue value)
        {
            if (!player_collider.IsTouchingLayers(LayerMask.GetMask("Destructable")))
            { return; }

            if (value.isPressed)
            { myrigidbody2D.velocity += new Vector2(0f, 30f);
            myAnimaitor.SetTrigger("jump");
        }


        }

        void Run()
        {
            Vector2 playerVelocity = new Vector2(inputMove.x * Speed, myrigidbody2D.velocity.y);
            myrigidbody2D.velocity = playerVelocity;
          

        }

        void flipper()
        {
            Vector3 flip = transform.localScale;

            bool Hspeed = Mathf.Abs(myrigidbody2D.velocity.x) > Mathf.Epsilon;

            // Use a small threshold to account for floating-point precision
            float threshold = 0.01f;

            if (myrigidbody2D.velocity.x < -threshold)
            {
                flip.x = 2;
                myAnimaitor.SetBool("Run", true);
            }
            else if (myrigidbody2D.velocity.x > threshold)
            {
                flip.x = -2;
                myAnimaitor.SetBool("Run", true);
            }
            else
            {
                myAnimaitor.SetBool("Run", false);
            }

            transform.localScale = flip;
        }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            SpawningPlayer2.instance.playerIsDead = true;
            Destroy(collision.gameObject);
            Destroy(gameObject);
            
        }
    }

}


