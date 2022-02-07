using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TotalNPCs : MonoBehaviour
{

    int totalFriendly;

    int totalInfected;

    [SerializeField] TextMeshProUGUI totalFriendlyText;
    [SerializeField] TextMeshProUGUI totalInfectedText;

    // Start is called before the first frame update
    void Start()
    {
        totalFriendly = 0;
        totalInfected = 0;
        totalFriendlyText.text = totalFriendly.ToString("0");
        totalInfectedText.text = totalInfected.ToString("0");
    }

    // Update is called once per frame
    void Update()
    {
        CheckAmount();
    }

    void CheckAmount() {
        totalFriendly = GameObject.FindGameObjectsWithTag("Friendly").Length;
        totalInfected = GameObject.FindGameObjectsWithTag("Enemy").Length;
        totalFriendlyText.text = totalFriendly.ToString("0");
        totalInfectedText.text = totalInfected.ToString("0");
        if(totalInfected)
            SceneManager.LoadScene("Win Scene");
    }
}
