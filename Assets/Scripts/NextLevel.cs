using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public string levelName;

    public GameObject completedObject;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player"){
            if(levelName == "completed") {
                completedObject.SetActive(true);

                return;
            }

            SceneManager.LoadScene(levelName);
            
        }

    }
}
