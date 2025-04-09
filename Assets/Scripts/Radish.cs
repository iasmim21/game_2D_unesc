using UnityEngine;

public class Radish : MonoBehaviour
{
    public float speed;
    public float moveTime;

    private bool dirRight;
    private float time;

    void Update()
    {
        if(dirRight){
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else{
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

        time += Time.deltaTime;

        if(time >= moveTime){
            dirRight = !dirRight;
            time = 0f;
        }
    }
}
