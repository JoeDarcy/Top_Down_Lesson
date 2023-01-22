using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5.0f;

    private Rigidbody2D playerRb;
    private Vector2 movement;
    private Vector2 mousePos;
    private Vector2 lookDirection;
    private float angle;
    private GameObject cameraGO;
    private Camera mainCamera;


    private void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        cameraGO = GameObject.FindGameObjectWithTag("MainCamera");
        mainCamera = cameraGO.GetComponent<Camera>();
    }

    // Update is called once per frame
    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        // Apply player movement
        playerRb.MovePosition(playerRb.position + movement * movementSpeed * Time.fixedDeltaTime);

        // Calculate and apply player rotation toward mouse position
        lookDirection = mousePos - playerRb.position;   // Get look direction using vector maths

        angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90.0f;  // Get angle from x axis and convert to degrees and offset by 90 degrees

        playerRb.SetRotation(angle);
    }
}
