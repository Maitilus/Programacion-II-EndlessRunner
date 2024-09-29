using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    #region Variables

    public float CurrentScore;
    public string ScoreDisplay() {return Mathf.RoundToInt(CurrentScore).ToString();}
    public string HiScoreDisplay() {return Mathf.RoundToInt(PlayerPrefs.GetFloat("SavedHighScore", 0)).ToString();}
    public bool IsPlaying = true;

    #endregion

    private void Start()
    {
        IsPlaying = true;
    }

    private void Update()
    {
        //Increase Score with time
        if (IsPlaying) {CurrentScore += Time.deltaTime;}

        //Set HighScore
        if (CurrentScore > PlayerPrefs.GetFloat("SavedHighScore", 0)) 
        {
            PlayerPrefs.SetFloat("SavedHighScore", CurrentScore);
        }
    }   

    //Reset Score When Lost
    public void GameOver() {CurrentScore = 0;}
}
