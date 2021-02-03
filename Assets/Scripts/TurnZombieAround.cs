﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnZombieAround : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Zombie"))
        {
            collision.gameObject.GetComponent<ZombieController>().ReverseDirection();
        }
    }
}
