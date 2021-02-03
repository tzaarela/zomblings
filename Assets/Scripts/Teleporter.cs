using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Teleporter teleporterExit;
    public bool isExit;

    public void Start()
    {
        if(isExit)
            GetComponent<BoxCollider2D>().enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Zombie"))
        {
            var zombie = collision.gameObject.GetComponent<ZombieController>();
            zombie.transform.position = teleporterExit.transform.position;

            if (teleporterExit.transform.lossyScale.x == 1)
                zombie.ReverseDirection();
        }
    }
}
