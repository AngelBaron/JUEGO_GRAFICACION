using UnityEngine.SceneManagement;
using UnityEngine;

public class Finish_Point : MonoBehaviour {

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (colission.CompareTag("Player"))
        {
            SceneController.instance.NextLevel();
        }
    }*/

    void UnlockNewLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedIndex"))
        {
            PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel", 1) + 1);
            PlayerPrefs.Save();
        }
    }
}
