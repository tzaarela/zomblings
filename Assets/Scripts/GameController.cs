using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    public Action onBrainDead;

    public void Awake()
    {
        if (Instance != this)
            Instance = this;
    }

    public void Start()
    {
        onBrainDead += HandleOnBrainDead;
    }

    private void HandleOnBrainDead()
    {
        Debug.Log("GAME OVER!!");
    }
}
