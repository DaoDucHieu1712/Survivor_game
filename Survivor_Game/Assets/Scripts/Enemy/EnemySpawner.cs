using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	public GameObject[] enemyPrefabs;
	public Transform[] spawnPoints;

	public float timeBetweenWaves = 2f;
	public float timeBetweenSpawn = 5f;

	private float coundown = 2f;
	private float waveIndex = 0;
	// Start is called before the first frame update



	// Update is called once per frame
	void Update()
	{
		if (coundown <= 0f)
		{
			StartCoroutine(SpawnWave());
			coundown = timeBetweenWaves;

		}
		coundown -= Time.deltaTime;
	}

	IEnumerator SpawnWave()
	{
		waveIndex++;

		for (int i = 0; i < waveIndex; i++)
		{
			SpawnEnemy();
			yield return new WaitForSeconds(5f);
		}
	}

	private void SpawnEnemy()
	{
		int enemyIndex = Random.Range(0, enemyPrefabs.Length);
		GameObject enemy = enemyPrefabs[enemyIndex];

		int spawnIndex = Random.Range(0, spawnPoints.Length);
		Transform spawnPoint = spawnPoints[spawnIndex];

		GameObject spawnEnemy = Instantiate(enemy, spawnPoint.position, Quaternion.identity);
	}
}
