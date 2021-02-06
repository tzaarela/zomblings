using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private bool isWaveFinished;
    private bool isGameOver;
    private bool isPaused;

    public static GameController Instance;
    public Action onBrainDead;
    public Action onZombiesDead;

    public TextMeshProUGUI winText;
    public TextMeshProUGUI loseText;
    public TextMeshProUGUI waveText;
    public TextMeshProUGUI waveCounterText;
    public TextMeshProUGUI pauseText;

    [SerializeField] private float m_SoundInterval;

    public void Awake()
    {
        if (Instance != this)
            Instance = this;
    }

    public void Start()
    {
        onBrainDead += WaveComplete;
        onZombiesDead += Lose;
        StartCoroutine(MakeSounds());

        ShowCurrentWaveText();
        Invoke(nameof(HideCurrentWaveText), 2);
    }

    public void Update()
    {
        if(!isGameOver && !isWaveFinished && Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
                PauseGame();
            else
                UnpauseGame();
        }

        if (isGameOver || isPaused)
        {
            if (Input.GetKeyDown(KeyCode.R))
                RestartGame();
            else if (Input.GetKeyDown(KeyCode.Q))
                QuitGame();
        }
        else if (isWaveFinished)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Time.timeScale = 1;
                NextWave();
                isWaveFinished = false;
            }
        }
    }

    private void PauseGame()
    {
        Time.timeScale = 0;
        pauseText.gameObject.SetActive(true);
        isPaused = true;
    }

    private void UnpauseGame()
    {
        Time.timeScale = 1;
        pauseText.gameObject.SetActive(false);
        isPaused = false;
    }

    IEnumerator MakeSounds()
    {
        string randomSound;
        string[] zombieSounds = new string[] { "ZombieSound1", "ZombieSound2", "ZombieSound3" };
        while (!isGameOver)
        {
            yield return new WaitForSeconds(m_SoundInterval);
            System.Random random = new System.Random();
            int picker = random.Next(3);
            randomSound = zombieSounds[picker];
            SoundController.Instance.PlaySound(randomSound);
        }
    }

    private void ShowCurrentWaveText()
    {
        waveCounterText.gameObject.SetActive(true);
        waveCounterText.gameObject.GetComponentsInChildren<TextMeshProUGUI>()[1].text = 
            (SpawnController.Instance.currentWaveIndex + 1).ToString();
    }

    private void HideCurrentWaveText()
    {
        waveCounterText.gameObject.SetActive(false);
    }

    public void CheckIfZombiesDead()
    {
        StartCoroutine(WaitOneFrame());
    }

    private IEnumerator WaitOneFrame()
    {
        yield return 0;

        var zombies = FindObjectsOfType<ZombieController>();
        if (zombies.Length == 0)
            GameController.Instance.onZombiesDead.Invoke();
    }

    private void Lose()
    {
        isGameOver = true;
        loseText.gameObject.SetActive(true);
    }

    private void Win()
    {
        winText.gameObject.SetActive(true);
        isGameOver = true;
    }

    private void WaveComplete()
    {
        if (SpawnController.Instance.waveCount == SpawnController.Instance.currentWaveIndex)
        {
            Win();
        }
        else
        {
            waveText.gameObject.SetActive(true);
            isWaveFinished = true;
        }
    }

    private void RestartGame()
    {
        StartCoroutine(ReloadSceneAsync());
        SpawnController.Instance.ResetWaves();

        if (isPaused)
            UnpauseGame();
    }

    private void NextWave()
    {
        StartCoroutine(ReloadSceneAsync());
        SpawnController.Instance.NextWave();
    }

    IEnumerator ReloadSceneAsync()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(1);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    public void PlayNormalSpeed()
    {
        Time.timeScale = 1;
    }

    public void PlayFasterSpeed()
    {
        Time.timeScale += 1f;
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 4f);
    }

    private void QuitGame()
    {
        Application.Quit();
    }
}
