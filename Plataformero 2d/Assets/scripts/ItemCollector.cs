using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemCollector : MonoBehaviour
{
    public int item = 0;

    [SerializeField] private TextMeshProUGUI itemText;

    [SerializeField] private AudioSource collectionSoundEffect;

    private void Start() {
        item = PlayerPrefs.GetInt("score");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            item++;
            itemText.text = "SCORE: " + item;
        }
    }

    public int getItem(){
        return item;
    }
}
