using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleCollission : MonoBehaviour
{
    public Score Play;
    [SerializeField] private GameObject Restart;

    private void Start()
    {
        Restart.SetActive(false);
    }

    //Detect when player Dies
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Play.IsPlaying = false;
            Time.timeScale = 0;
            Restart.SetActive(true);
        }
    }

    //Restart the Game
    private void Update()
    {
        if (Input.GetButtonDown("Jump") && !Play.IsPlaying)
        {
            SceneManager.LoadScene("Level");
            Time.timeScale = 1; 
        }
    }
}
