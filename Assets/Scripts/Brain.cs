using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brain : MonoBehaviour
{
    [Header("BrainSettings")]
    [SerializeField]
    private float health = 100f;
    [SerializeField]
    private Sprite fullBrain;
    [SerializeField]
    private Sprite damagedBrain;
    [SerializeField]
    private Sprite criticalBrain;
    private SpriteRenderer spriteRenderer;

    public Action<ZombieController> onEatAnimationFinished;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        onEatAnimationFinished += HandleOnEatAnimationFinished;
        spriteRenderer.sprite = fullBrain;
    }

    private void HandleOnEatAnimationFinished(ZombieController zombie)
    {
        TakeDamage(zombie.zombieData.damage);
        Destroy(zombie.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Zombie"))
        {
            var zombie = collision.gameObject.GetComponent<ZombieController>();
            zombie.EatBrain(this);
        }
    }

    private void TakeDamage(float damage)
    {
        health -= damage;
        ChangeSprite();
        if (health <= 0)
        {
            GameController.Instance.onBrainDead.Invoke();
            Destroy(gameObject);
        }
    }

    private void ChangeSprite()
    {
        if (health <= 60 && health > 30)
        {
            spriteRenderer.sprite = damagedBrain;
        }
        else if(health <= 30)
        {
            spriteRenderer.sprite = criticalBrain;
        }
    }
}
