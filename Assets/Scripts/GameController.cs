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

    public static GameController Instance;
    public Action onBrainDead;
    public Action onZombiesDead;

    public TextMeshProUGUI winText;
    public TextMeshProUGUI loseText;
    public TextMeshProUGUI waveText;

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
    }

    public void Update()
    {
        if (isGameOver)
        {
            if (Input.GetKeyDown(KeyCode.R))
                RestartGame();
            else if (Input.GetKeyDown(KeyCode.Escape))
                QuitGame();
        }
        else if (isWaveFinished)
        {
            if (Input.anyKey)
            {
                Time.timeScale = 1;
                NextWave();
                isWaveFinished = false;
            }
        }
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
        waveText.gameObject.SetActive(true);
        isWaveFinished = true;
    }

    private void RestartGame()
    {
        StartCoroutine(ReloadSceneAsync());
        SpawnController.Instance.ResetWaves();
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

    private void QuitGame()
    {
        Application.Quit();
    }
}
