using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class EndMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    private void Start() {
        scoreText.text = "SCORE:"+ PlayerPrefs.GetInt("score").ToString();
    }
    public void Quit(){
        Application.Quit();
    }
}
