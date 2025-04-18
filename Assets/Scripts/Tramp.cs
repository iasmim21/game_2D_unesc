using UnityEngine;

public class Tramp : MonoBehaviour
{
    public float jumpForce;

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

     void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player"){
            anim.SetTrigger("jump");
            collision.gameObject.GetComponent<Rigidbody2D>()
            .AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }
}
