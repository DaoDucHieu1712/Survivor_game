using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
	public GameObject prefabTarget;
	private Vector3 targetPos;

	public float spawnInterval = 3f;

	private float timeSinceLastSpawn;
	private void Start()
	{
	}
	void Update()
	{
		timeSinceLastSpawn += Time.deltaTime;
		if (timeSinceLastSpawn >= spawnInterval)
		{
			SetNewTargetPos();
			timeSinceLastSpawn = 0f;
		}
	}

	private void SetNewTargetPos()
	{
		Vector3 topRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, Camera.main.nearClipPlane));
		Vector3 bottomLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
		float right = topRight.x;
		float left = bottomLeft.x;
		float top = topRight.y;
		float bot = bottomLeft.y;
		targetPos = new Vector3(Random.Range(right, left), Random.Range(top, bot), 0);
		GameObject newPrefabTarget = Instantiate(prefabTarget, targetPos, Quaternion.identity);
	}
}
