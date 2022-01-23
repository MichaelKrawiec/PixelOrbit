using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Camera cam;

    private PlayerControls playerInput;


    private CharacterController controller;
    private Vector3 playerVelocity;

    public float playerSpeed = 2.0f;


    void Start()
    {
        cam = Camera.main;
    }

    private void Awake()
    {
        playerInput = new PlayerControls();
        controller = GetComponent<CharacterController>();
    }

    private void OnEnable()
    {
        playerInput.Enable();
    }
    private void OnDisable()
    {
        playerInput.Disable();
    }
    void Update()
    {
        Vector2 movementInput = playerInput.player.move.ReadValue<Vector2>();
        Vector3 move = new Vector3(movementInput.x,movementInput.y);
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.up = move;
        }

        controller.Move(playerVelocity * Time.deltaTime);

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, -44f, 44f),
            Mathf.Clamp(transform.position.y, -25.25f, 25.25f),
            transform.position.z);
    }

}
