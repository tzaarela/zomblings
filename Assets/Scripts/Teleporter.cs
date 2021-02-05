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
			zombie.GetComponent<SpriteRenderer>().sortingLayerName = "Zombies";
			zombie.GetComponent<SpriteRenderer>().sortingOrder = 0;

			//Continue
			switch (teleporterExit.exitType)
			{
				case Assets.Scripts.ExitType.Random:
					//zombie.direction = 
					break;
				case Assets.Scripts.ExitType.Left:
					break;
				case Assets.Scripts.ExitType.Right:
					break;
				
			}
		}
	}
}
