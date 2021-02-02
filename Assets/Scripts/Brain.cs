using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brain : MonoBehaviour
{
    [SerializeField]
    private float health = 100f;

    public Action<ZombieController> onEatAnimationFinished;

    private void Start()
    {
        onEatAnimationFinished += HandleOnEatAnimationFinished;
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

        if (health <= 0)
        {
            GameController.Instance.onBrainDead.Invoke();
        }
    }
}
