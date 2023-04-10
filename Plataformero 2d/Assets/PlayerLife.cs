using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    [SerializeField] private AudioSource deathSoundEffect;

    [SerializeField] private TextMeshProUGUI lifeText;

    [SerializeField] ItemCollector itemCollector;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        lifeText.text = "LIFES: "+PlayerPrefs.GetInt("lives");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }
    }

    private void Die()
    {
        deathSoundEffect.Play();
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("Death");
        PlayerPrefs.SetInt("lives", PlayerPrefs.GetInt("lives")-1);
    }

    private void RestartLevel()
    {   
        if(PlayerPrefs.GetInt("lives")>0){
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else if(PlayerPrefs.GetInt("lives")<=0){
            PlayerPrefs.SetInt("score", itemCollector.getItem());
            SceneManager.LoadScene(4);
        }
    }
}
