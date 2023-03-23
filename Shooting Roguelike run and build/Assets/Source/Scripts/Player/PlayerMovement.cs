using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    [HideInInspector] public Vector2 movementInput;
    [HideInInspector] public float lastHorizontalVector;
    [SerializeField]private GameObject player;
    [SerializeField]private Animator animator;
    public float speed = 2f;
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        rigidbody.velocity = movementInput * speed;
        movementInput.x = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", movementInput.sqrMagnitude);

        if (movementInput.x != 0)
            lastHorizontalVector = movementInput.x;
        if (movementInput.x < 0)
            player.transform.localScale = new Vector3(-1, 1, 1);

        else if (movementInput.x > 0)
            player.transform.localScale = new Vector3(1, 1, 1);


    }
    private void OnMove(InputValue inputValue)
    {
        movementInput = inputValue.Get<Vector2>();

    }
}
