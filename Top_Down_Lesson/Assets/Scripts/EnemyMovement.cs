using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5.0f;

    private Rigidbody2D enemyRb;
    private Vector2 playerPosition;
    private Vector2 lookDirection;
    private float angle;
    private GameObject playerGO;


    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        playerGO = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate()
    {
        // Update player position varible for use as target for enemy
        playerPosition = playerGO.transform.position;

        // Calculate and apply rotation and movement to enemy
        enemyRb.transform.position = Vector3.MoveTowards(transform.position, playerPosition, movementSpeed * Time.fixedDeltaTime);
        

        lookDirection = playerPosition - enemyRb.position;

        angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90.0f;

        enemyRb.SetRotation(angle);
    }
}
