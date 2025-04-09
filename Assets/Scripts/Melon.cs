using UnityEngine;

public class Melon : MonoBehaviour
{
    private SpriteRenderer sr;
    private CircleCollider2D circle;

    public GameObject collected;
    public int score;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        circle = GetComponent<CircleCollider2D>();
    }

     void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player"){
            sr.enabled = false;
            circle.enabled = false;

            collected.SetActive(true);

            GameControler.instance.totalScore += score;

            GameControler.instance.updateScoreText();


            Destroy(gameObject, 0.3f);
        }
    }
}
