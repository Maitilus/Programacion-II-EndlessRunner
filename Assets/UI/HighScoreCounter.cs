using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighScoreCounter : MonoBehaviour
{
    public TextMeshProUGUI HiScoreText;
    public Score UI;

    private void Start()
    {
        HiScoreText.text = $"HI: {UI.HiScoreDisplay()}";
    }   

    private void Update()
    {
        HiScoreText.text = $"HI: {UI.HiScoreDisplay()}";
    }
}
