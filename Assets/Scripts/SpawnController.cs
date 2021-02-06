using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SpawnController : MonoBehaviour
{
    public static SpawnController Instance;

    [Header("SpawnSettings")]
    [SerializeField] private GameObject m_ZombiePrefab;
    [SerializeField] List<Transform> m_SpawnPoints;
    [SerializeField] private float m_SpawnRate;

    public int currentWaveIndex;
    public int waveCount;

    [SerializeField]
    public Wave[] waves;

    public void Awake()
    {
        if (Instance != null)
            Destroy(this.gameObject);
        else
            Instance = this;

        DontDestroyOnLoad(gameObject);
    }

    public void Start()
    {
        currentWaveIndex = 0;
        NextWave();
    }

    public void NextWave()
    {
        
        StartCoroutine(SpawnZombie());
    }

    public void ResetWaves()
    {
        currentWaveIndex = 0;
    }

    //Spawns a zombie as fast as the SpawnRate
    public IEnumerator SpawnZombie()
    {
        for (int i = 0; i < waves[currentWaveIndex].zombieCount; i++)
        {
            var randomSpawnIndex = Random.Range(0, m_SpawnPoints.Count); 
            yield return new WaitForSeconds(m_SpawnRate);
            var zombie = Instantiate(m_ZombiePrefab, m_SpawnPoints[randomSpawnIndex].position, Quaternion.identity).GetComponent<ZombieController>();
            zombie.GetComponent<Rigidbody2D>().isKinematic = true;
            zombie.zombieData.moveSpeed = waves[currentWaveIndex].zombieSpeed;
        }
        currentWaveIndex++;
    }
}
