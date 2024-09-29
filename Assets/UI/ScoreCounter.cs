using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    public Score UI;

    private void Start()
    {
        ScoreText.text = $"Score: {UI.ScoreDisplay()}";
    }
    
    private void Update()
    {
        ScoreText.text = $"Score: {UI.ScoreDisplay()}";
    }

}
