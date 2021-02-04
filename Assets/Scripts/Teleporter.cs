using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
	private TeleporterExit[] teleporterExits;

	public void Start()
	{
		teleporterExits = FindObjectsOfType<TeleporterExit>();

		if (teleporterExits.Length == 0)
			Debug.LogError("No teleportExit found in scene, please add a prefab");
		if (teleporterExits.Length > 1)
			Debug.LogError("More then one teleportExit found in scene, please only use one for now!");

	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Zombie"))
		{
			var zombie = collision.gameObject.GetComponent<ZombieController>();
			zombie.transform.position = teleporterExits[0].transform.position;

			if (teleporterExits[0].transform.lossyScale.x == 1)
				zombie.ReverseDirection();
		}
	}
}
