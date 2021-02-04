using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
	private TeleporterExit teleporterExit;

	public int id;

	public void Start()
	{
		teleporterExit = FindObjectsOfType<TeleporterExit>().FirstOrDefault(x => x.id == id);

		if (teleporterExit == null)
			Debug.LogError($"No matching exit found for teleport id:{id}");
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
