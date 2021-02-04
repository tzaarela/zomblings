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

			float[] scales = new float[2]
			{
				-0.4f,
				0.4f
			};

			zombie.transform.localScale = new Vector3(scales[Random.Range(0, 1)], zombie.transform.localScale.y, 1);
		}
	}
}
