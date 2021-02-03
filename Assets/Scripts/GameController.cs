using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    public bool GameOver;
    public Action onBrainDead;
    [SerializeField] private float m_SoundInterval;

    public void Awake()
    {
        if (Instance != this)
            Instance = this;
    }

    public void Start()
    {
        onBrainDead += HandleOnBrainDead;
        StartCoroutine(MakeSounds());
    }

    IEnumerator MakeSounds()
    {
        string[] zombieSounds = new string[] { "ZombieSound1", "ZombieSound2", "ZombieSound3" };
        while (!GameOver)
        {
            yield return new WaitForSeconds(m_SoundInterval);
            System.Random random = new System.Random();
            int picker = random.Next(3);
            string randomSound = zombieSounds[picker];
            SoundController.Instance.PlaySound(randomSound);

        }
    }

    private void HandleOnBrainDead()
    {
        Debug.Log("GAME OVER!!");
    }
}
