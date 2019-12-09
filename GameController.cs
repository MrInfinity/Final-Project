using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public static int lives = 3;
    public static int scoreToWin = 100;

    public AudioSource musicSource;
    public AudioClip winSound;
    public AudioClip loseSound;

    public Text ScoreText;
    public Text RestartText;
    public Text GameOverText;
    public Text WinText;
    public Text livesText;

    private bool gameOver;
    private bool restart;
    public static int score;

    void Start ()
    {
        gameOver = false;
        restart = false;
        RestartText.text = "";
        GameOverText.text = "";
        WinText.text = "";
        livesText.text = "Lives: 3";
        score = 0;
        UpdateScore();
        StartCoroutine (SpawnWaves ());
    }

    void Update ()
    {

        livesText.text = "Lives: " + lives;
        if (restart)
        {
            if (Input.GetKeyDown (KeyCode.L))
            {
                lives = 3;
                SceneManager.LoadScene("Current");
            }
        }

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    IEnumerator SpawnWaves ()
    {
            yield return new WaitForSeconds (startWait);
            while (true)
            {
                for (int i = 0; i < hazardCount; i++)
                {

                    GameObject hazard = hazards[Random.Range (0,hazards.Length)];
                    Vector3 spawnPosition = new Vector3 (Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                    Quaternion SpawnRotation = Quaternion.identity;
                    Instantiate (hazard, spawnPosition, SpawnRotation);
                    yield return new WaitForSeconds (spawnWait);
                }
                yield return new WaitForSeconds (waveWait);

                if (gameOver)
                {
                    RestartText.text = "Press 'L' to Restart";
                    restart = true;
                    break;
                }
            }

    }

    public void AddScore(int scoreValue)
    {
        score += scoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        ScoreText.text = "Points: " + score;

        if (score >= scoreToWin)
        {
            WinText.text = "You Win! \n Game Created by \n Austin Owens!";
            GameOver();

            musicSource.clip = winSound;
            musicSource.Play();
        }
    }

    public void GameOver ()
    {
        GameOverText.text = "Game Over!";
        gameOver = true;

        musicSource.clip = loseSound;
        musicSource.Play();

    }
}
