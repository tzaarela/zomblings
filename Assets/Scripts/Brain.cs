using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Brain : MonoBehaviour
{
    [Header("BrainSettings")]

    [SerializeField]
    private float health = 100f;
    [SerializeField]
    private float wobbleMax = 2f;
    [SerializeField]
    private float wobbleDuration = 2f;
    [SerializeField]
    private Sprite fullBrain;
    [SerializeField]
    private Sprite damagedBrain;
    [SerializeField]
    private Sprite criticalBrain;
    [SerializeField]
    private Image UIHealthbar;

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
        WobbleBrain();
    }

    private void WobbleBrain()
    {
        transform.DOScale(wobbleMax, wobbleDuration).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
    }

    private void HandleOnEatAnimationFinished(ZombieController zombie)
    {
        TakeDamage(zombie.zombieData.damage);
        zombie.Die();
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
        UIHealthbar.fillAmount = health * 0.01f;
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
