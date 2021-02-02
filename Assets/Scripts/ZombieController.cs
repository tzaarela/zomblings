using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    [SerializeField]
    private ZombieData zombieData;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void FixedUpdate()
    {
        MoveRight();
    }

    public void MoveRight()
    {
        rb.velocity = Vector2.right * zombieData.moveSpeed;
    }

    public void ReverseDirection()
    {
        rb.velocity = new Vector2(rb.velocity.x * -1, rb.velocity.y);
    }

    public void Die()
    {

    }

    public void EatBrain()
    {

    }

}
