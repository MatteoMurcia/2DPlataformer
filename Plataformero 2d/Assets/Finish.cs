using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private AudioSource finishAudio;

    [SerializeField] ItemCollector itemCollector;

    private bool levelCompleted = false;
    void Start()
    {
        finishAudio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Player") && !levelCompleted)
        {
            finishAudio.Play();
            levelCompleted = true;
            Invoke("CompleteLevel", 2f);
        }
    }

    private void CompleteLevel(){
        PlayerPrefs.SetInt("score", itemCollector.getItem());
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
