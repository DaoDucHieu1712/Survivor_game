using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatMove : MonoBehaviour
{
    private GameObject player; // Reference to the player object
    public float moveSpeed = 2f;
     
    void Start()
    {
        // Find the player object using its tag
        player = GameObject.FindGameObjectWithTag("Player");

    }
    public IEnumerator MoveToPlayer(GameObject target)
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
                    target.GetComponent<Rigidbody2D>().velocity = dirToPlayer * moveSpeed;
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
