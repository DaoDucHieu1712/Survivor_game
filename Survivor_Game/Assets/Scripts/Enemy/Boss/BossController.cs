using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cinemachine.DocumentationSortingAttribute;

public class BossController : MonoBehaviour
{
    public GameObject _bat;
    public GameObject _flower;
    public GameObject _evil;
    public float spawnInterval = 4f;
    private float timeSinceLastSpawn;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
		player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;
        if (timeSinceLastSpawn >= spawnInterval)
        {
            SpawnBoss();
            timeSinceLastSpawn = 0f;
        }
    }

    private void SpawnBoss()
    {
        Vector3 topRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, Camera.main.nearClipPlane));
        Vector3 bottomLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
        float right = topRight.x;
        float left = bottomLeft.x;
        float top = topRight.y;
        float bot = bottomLeft.y;
        Vector3 targetPos = new Vector3(Random.Range(right, left), Random.Range(top, bot), 0);

        int randb = Random.Range(1, 5);
        GameObject boss;
        Vector3 bossBody = new Vector3(0.4f, 0.4f, 0);
        if (randb == 2)
        {
            boss = Instantiate(_bat, targetPos, Quaternion.identity);
            boss.GetComponent<BatProperty>().Damage = boss.GetComponent<BatProperty>().Damage * 2;
            boss.GetComponent<BatProperty>().CurrentHealth = boss.GetComponent<BatProperty>().CurrentHealth * 5;
            boss.transform.localScale = new Vector3(20f, 20f, 0);
        }
        else if (randb == 3)
        {
            boss = Instantiate(_flower, targetPos, Quaternion.identity);
            boss.GetComponent<FlowerShoot>().dame = boss.GetComponent<FlowerShoot>().dame * 2;
            boss.GetComponent<FlowerShoot>().hp = boss.GetComponent<FlowerShoot>().hp * 5;
            boss.transform.localScale = bossBody;
            StartCoroutine(MoveToPlayer(_flower));
        }
        else if (randb == 4)
        {
            boss = Instantiate(_evil, targetPos, Quaternion.identity);
            boss.GetComponent<EvilShoot>().dame = boss.GetComponent<EvilShoot>().dame * 3;
            boss.GetComponent<EvilShoot>().hp = boss.GetComponent<EvilShoot>().hp * 4;
            boss.transform.localScale = new Vector3(1.5f, 1.5f, 0);
            //boss.transform.localScale = bossBody;
        }

    }

    private IEnumerator MoveToPlayer(GameObject target)
    {
        yield return new WaitForSeconds(3f); // Wait for 3 seconds

        Vector3 prevPlayerPos = player.transform.position;
        bool isMovingToPlayer = true;

        while (true)
        {
            Vector3 currPlayerPos = player.transform.position;

            // Check if the target object has been destroyed before accessing its position
            if (target == null)
            {
                break;
            }

            float distToPlayer = Vector3.Distance(target.transform.position, currPlayerPos);

            if (isMovingToPlayer)
            {
                // If the target is moving towards the player, check if it has reached the desired distance
                if (distToPlayer <= 4f)
                {
                    // Stop moving and freeze in the current position
                    target.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                    isMovingToPlayer = false;
                    yield return new WaitForSeconds(3f); // Wait for 3 seconds before moving again
                }
                else
                {
                    // Set the velocity of the prefabTarget Rigidbody to move towards the player
                    Vector3 dirToPlayer = (currPlayerPos - target.transform.position).normalized;
                    target.GetComponent<Rigidbody2D>().velocity = dirToPlayer * 2f;
                }
            }
            else
            {
                // If the target is frozen, check if the player has moved more than 2 units away from its previous position
                float distMoved = Vector3.Distance(prevPlayerPos, currPlayerPos);
                if (distMoved >= 3f)
                {
                    // Calculate the direction towards the player's new position
                    Vector3 dirToPlayer = (currPlayerPos - target.transform.position).normalized;
                    isMovingToPlayer = true;
                }
            }

            yield return null;
        }
    }
}
