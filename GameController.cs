using System.Collections;
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
    public AudioSource musicSource1;
    public AudioSource musicSource2;
    public AudioSource musicSource3;
    public AudioClip musicClipOne;
    public AudioClip musicClipTwo;
    public AudioClip musicClipThree;

    public Text ScoreText;
    public Text RestartText;
    public Text GameOverText;
    public Text winText;
    public Text hardModeText;
    public Text timeAttackText;
    public Text timerText;
    public Text endScoreText;
    public float startTime;

    private bool gameWin;
    private bool gameOver;
    public bool restart;
    private bool tmode;
    private bool scores;
    private int score;
    private int repeat;
    Scene currentScene;

    
    void Start()
    {
        tmode = false;
        gameWin = false;
        gameOver = false;
        restart = false;
        scores = false;
        GameOverText.text = "";
        RestartText.text = "";
        winText.text = "";
        hardModeText.text = "";
        timeAttackText.text = "";
        timerText.text = "";
        endScoreText.text = "";
        score = 0;
        repeat = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());
        musicSource1.clip = musicClipOne;
        musicSource1.Play();
        currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName == "TimeAttack")
        {
            tmode = true;
        }
    }

    private void Update()
    {
        if (restart)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene("SampleScene");
            }

            if(Input.GetKeyDown(KeyCode.H))
            {
                SceneManager.LoadScene("HardMode");
            }

            if (Input.GetKeyDown(KeyCode.T))
            {
                SceneManager.LoadScene("TimeAttack");
            }
        }

        if (tmode == true)
        {
            startTime -= Time.deltaTime;
            timerText.text = startTime.ToString("f2");
            if (startTime <= 0)
            {
                scores = true;
                timerText.text = "0.00";
                if ((scores == true) && (gameOver == false) && (repeat == 0))
                {
                    endScoreText.text = "Level Completed \nGame Created By David Kingsley! \nYou Scored : " + score;
                    restart = true;
                    musicSource1.Stop();
                    musicSource2.clip = musicClipTwo;
                    musicSource2.Play();
                    repeat = 1;
                }
            }
        }

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
    IEnumerator SpawnWaves()
    {
        while (true)
        {
            yield return new WaitForSeconds(startWait);
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver || gameWin || scores)
            {
                RestartText.text = "Press 'E' for Easy Mode";
                hardModeText.text = "Press 'H' for Hard Mode";
                timeAttackText.text = "Press 'T' for Time Attack Mode";
                restart = true;
                break;
            }
        }
    }

    public void AddScore (int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

       public void UpdateScore()
    {
        ScoreText.text = "Points: " + score;
        if (tmode != true)
            if (score >= 100)
            {
                winText.text = "You Win! \nGame Created By David Kingsely!";
                gameWin = true;
                restart = true;
                musicSource1.Stop();
                musicSource2.clip = musicClipTwo;
                musicSource2.Play();
            }
    }

    public void Gameover()
    {
        gameOver = true;

        if ((gameWin == true) || (scores == true))
        {
            GameOverText.text = "";
        }

        else if (tmode == true)
        {
            GameOverText.text = "Game Over!";
            endScoreText.text = "Your Score : " + score;
            timerText.text = "0.00";
            musicSource1.Stop();
            musicSource3.clip = musicClipThree;
            musicSource3.Play();
        }

        else
        {
            GameOverText.text = "Game Over!";
            musicSource1.Stop();
            musicSource3.clip = musicClipThree;
            musicSource3.Play();
        }
    }
}
