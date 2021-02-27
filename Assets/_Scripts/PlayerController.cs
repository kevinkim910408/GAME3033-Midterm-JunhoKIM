using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Vector3 moveVector = Vector3.zero;

    [SerializeField] float moveSpeed = 10.0f;
    [SerializeField] float jumpForce = 5.0f;

    // components
    Animator animator;
    Rigidbody _rigidbody;
    CapsuleCollider capsuleCollider;

    // material
    [SerializeField] Material mat;
    SkinnedMeshRenderer[] skinnedMeshRenderer;

    readonly int MovementXHash = Animator.StringToHash("MoveX");
    readonly int MovementZHash = Animator.StringToHash("MoveZ");
    readonly int IsJumpingHash = Animator.StringToHash("isJumping");
    readonly int IsDeadHash = Animator.StringToHash("isDead");


    // boolean
    bool isJump;
    bool canJump;
    bool canMove;

    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        skinnedMeshRenderer = GetComponentsInChildren<SkinnedMeshRenderer>();

        canJump = true;
        canMove = true;


    }

    // Update is called once per frame
    void Update()
    {
        Move();

        if (canJump)
        {
            Jump();
        }
    }

     void FixedUpdate()
    {
        // CapsuleCast to check ground
        //float distanceToPoints = capsuleCollider.height / 2 - capsuleCollider.radius;
        //Vector3 point1 = transform.position + capsuleCollider.center + Vector3.up * distanceToPoints;
        //Vector3 point2 = transform.position + capsuleCollider.center - Vector3.up * distanceToPoints;
        //Vector3 dir = Vector3.down;
        //float castDistance = 0.1f;
        //float radius = capsuleCollider.radius;

        //// 0.1f - distance between capsule and ground
        //RaycastHit[] hit = Physics.CapsuleCastAll(point1, point2, radius, dir, castDistance, groundLayer);

        //foreach(RaycastHit arr in hit)
        //{
        //    Debug.Log(arr.collider.name);
        //}

        //// hit ground
        //if (hit.Length != 0)
        //{
        //    Jump();
        //}

    }

    private void Move()
    {
        if(moveVector.magnitude > 0 && canMove)
        {
            moveVector.Normalize();
            moveVector = moveVector * moveSpeed * Time.deltaTime;
            transform.Translate(moveVector);
        }
    }
    public void Jump()
    {
        if (!isJump)
            return;

        _rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isJump = false;

        // prevent double jump
        canJump = false;

    }
    public void OnMove(InputValue value)
    {
        Vector2 getMoveValue = value.Get<Vector2>();

        moveVector.x = getMoveValue.x;
        moveVector.z = getMoveValue.y;

        animator.SetFloat(MovementXHash, getMoveValue.x);
        animator.SetFloat(MovementZHash, getMoveValue.y);
    }

    public void OnJump(InputValue value)
    {
        isJump = value.isPressed; // button press => isjump = true

 
        animator.SetBool(IsJumpingHash, value.isPressed); // jump anim

        //Debug.Log(value.Get());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            canJump = true;
            animator.SetBool(IsJumpingHash, false);
        }

        if (collision.gameObject.CompareTag("Death"))
        {
            for(int i = 0; i < skinnedMeshRenderer.Length; ++i)
            {
                skinnedMeshRenderer[i].material = mat;
            }
            capsuleCollider.height = 0.5f;
            animator.SetBool(IsDeadHash, true);
            canJump = false;
            canMove = false;
        }
        
    }

}
