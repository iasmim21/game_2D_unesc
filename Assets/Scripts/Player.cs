using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed;
    public float JumpForce;

    public bool isJumping;
    public bool doubleJump;


    private Rigidbody2D Rigidbody;
    private Animator anim;

    void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
    }

    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        float movement = Input.GetAxis("Horizontal");
        Rigidbody.linearVelocity = new Vector2(movement * Speed, Rigidbody.linearVelocity.y);

        if(movement > 0f){
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }

        if(movement < 0f){
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }

        if(movement == 0){
            anim.SetBool("walk", false);
        }
    }

    void Jump()
    {
        if(Input.GetButtonDown("Jump")){
            if(!isJumping){
                Rigidbody.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                doubleJump = true;
                anim.SetBool("jump", true);
            } else {
                if(doubleJump) {
                    Rigidbody.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                    doubleJump = false;
                    anim.SetBool("jump", false);
                }
            }
        }
    }

     void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 6){
            isJumping = false;
            anim.SetBool("jump", false);
        }

        if(collision.gameObject.layer == 7){//game over
            GameControler.instance.gameOver();

            Destroy(gameObject);
        }
    }

     void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 6){
            isJumping = true;
            // anim.SetBool("jump", true);
        }
    }
}
