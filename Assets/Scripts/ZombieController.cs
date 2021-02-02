﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    [SerializeField]
    private ZombieData zombieData;

    private Rigidbody2D rb;
    private SpriteRenderer SpriteRenderer;

    private Vector2 direction;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        SpriteRenderer.sprite = zombieData.sprite;
        direction = Vector2.right;
    }

    public void FixedUpdate()
    {
        MoveRight();
    }

    public void MoveRight()
    {
        rb.velocity = new Vector2(zombieData.moveSpeed * direction.x, rb.velocity.y);
    }

    public void ReverseDirection()
    {
        Debug.Log("Zombie Reversing");
        direction = direction * -1;
    }

    public void Die()
    {

    }

    public void EatBrain()
    {

    }

}
