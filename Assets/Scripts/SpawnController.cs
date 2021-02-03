using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [Header("SpawnSettings")]
    [SerializeField] private GameObject m_ZombiePrefab;
    [SerializeField] private Transform m_SpawnPoint;
    [SerializeField] private float m_SpawnRate;
    [SerializeField] private int m_SpawnAmount;
    public bool m_MoveleftFromStart;


    public void Start()
    {
        StartWave();
    }

    public void StartWave()
    {
        StartCoroutine(SpawnZombie());
    }

    //Spawns a zombie as fast as the SpawnRate
    public IEnumerator SpawnZombie()
    {
        for (int i = 0; i < m_SpawnAmount; i++)
        {
            yield return new WaitForSeconds(m_SpawnRate);
            Instantiate(m_ZombiePrefab, m_SpawnPoint.position, Quaternion.identity);
        }
    }
}
