using UnityEngine;

public class Plataforma : MonoBehaviour
{
    public float time;

    private TargetJoint2D target;
    private BoxCollider2D collider;

    void Start()
    {
        target = GetComponent<TargetJoint2D>();
        collider = GetComponent<BoxCollider2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player"){
            Invoke("falling", time);
        }

        if(collision.gameObject.layer == 7){//game over
            Destroy(gameObject);
        }
    }

     void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.layer == 7){//game over
            Destroy(gameObject);
        }
    }

    void falling() {
            target.enabled = false;
            collider.isTrigger = true;
    }
}
