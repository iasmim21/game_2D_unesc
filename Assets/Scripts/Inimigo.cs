using UnityEngine;

public class Inimigo : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    private Animator anim;

    public float speed;

    public Transform rightCol;
    public Transform leftCol;

    public Transform headPoint;

    private bool colliding;

    public LayerMask layer;

    public BoxCollider2D box2D;
    public CircleCollider2D circle2D;


    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    void Update()
    {
        rigidbody.linearVelocity = new Vector2(speed, rigidbody.linearVelocity.y);

        colliding = Physics2D.Linecast(rightCol.position, leftCol.position, layer);

        Debug.Log(colliding);

        if(colliding) {
            transform.localScale = new Vector2(transform.localScale.x * -1f, transform.localScale.y);
            speed *= -1f;

            Debug.Log(speed);
        }
    }

    bool playerDestroyed;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player") {
            float height = collision.contacts[0].point.y - headPoint.position.y;

            if(height > 0 && !playerDestroyed) {
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                speed = 0;
                anim.SetTrigger("matar");

                box2D.enabled = false;
                circle2D.enabled = false;

                rigidbody.bodyType = RigidbodyType2D.Kinematic;

                Destroy(gameObject, 0.4f);
            } else {
                playerDestroyed = true;
                GameControler.instance.gameOver();

                Destroy(collision.gameObject);
            }
        }
    }
}
