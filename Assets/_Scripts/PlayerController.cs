using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Vector3 moveVector = Vector3.zero;

    [SerializeField] float moveSpeed = 10.0f;
    [SerializeField] float jumpForce = 5.0f;

    // components
    Animator animator;
    Rigidbody _rigidbody;
    CapsuleCollider capsuleCollider;
    CanvasUI canvasUI;

    [SerializeField] Text timerText = null;
    [SerializeField] float timer;


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
    bool isLose;

    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        skinnedMeshRenderer = GetComponentsInChildren<SkinnedMeshRenderer>();
        canvasUI = FindObjectOfType<CanvasUI>();

        canJump = true;
        canMove = true;
        isLose = false;


    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Timer();

        if (canJump)
        {
            Jump();
        }


    }

    private void Timer()
    {
        if (!isLose)
        {
            timer -= Time.deltaTime;
            timerText.text = "Time   " + timer.ToString("N0");
            if (timer <= 0)
            {
                isLose = true;
                timerText.text = "GAME OVER";
                canvasUI.LoseCondition();
            }
        }
        
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
