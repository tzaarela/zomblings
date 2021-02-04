using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocker : MonoBehaviour
{
    public BlockerData blockerData;

    private float durability;


    private void Start()
    {
        durability = blockerData.durability;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Zombie"))
        {
            var zombie = collision.gameObject.GetComponent<ZombieController>();
            ReduceDurability(zombie);
            zombie.FlipDirection();
        }
    }

    private void ReduceDurability(ZombieController zombie)
    {
        //TODO - Change sprite depending on state
        durability -= zombie.zombieData.damage;

        if (durability <= 0 && !gameObject.CompareTag("Empower"))
            Destroy(this.gameObject);
    }
}
