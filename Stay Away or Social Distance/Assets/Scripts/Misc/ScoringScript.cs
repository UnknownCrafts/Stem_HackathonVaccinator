using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoringScript : MonoBehaviour
{
    int score;

    [SerializeField] TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreText.text =  score.ToString("0");
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text =  score.ToString("0");
    }

    public void AddScore(int addscore) {
        score += addscore;
    }
}
