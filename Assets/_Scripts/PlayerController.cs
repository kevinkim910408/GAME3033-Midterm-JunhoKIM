using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Vector3 moveVector = Vector3.zero;

    [SerializeField] float moveSpeed = 10.0f;

    // components
    Animator animator;

    readonly int MovementXHash = Animator.StringToHash("MoveX");
    readonly int MovementZHash = Animator.StringToHash("MoveZ");

    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        if(moveVector.magnitude > 0)
        {
            moveVector.Normalize();
            moveVector = moveVector * moveSpeed * Time.deltaTime;
            transform.Translate(moveVector);
        }
    }

    public void OnMove(InputValue value)
    {
        Vector2 getMoveValue = value.Get<Vector2>();

        moveVector.x = getMoveValue.x;
        moveVector.z = getMoveValue.y;

        animator.SetFloat(MovementXHash, getMoveValue.x);
        animator.SetFloat(MovementZHash, getMoveValue.y);
    }

}
