using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocker : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Zombie"))
        {
            print("collidet");
            collision.gameObject.GetComponent<ZombieWalkTmp>().FlipVelocity();
        }
    }

}
