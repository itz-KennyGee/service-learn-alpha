using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Move Variables")]
    [SerializeField] private float MOVESPEED;
    [SerializeField] private float WALKSPEED;
    [SerializeField] private float RUNSPEED;
    [SerializeField] private float JUMPFORCE;
    private Vector3 DIRECTION = Vector3.zero;

    private CharacterController controller;
    private bool canQuit = false;

    [Header("Gravity Variables")]
    [SerializeField] private float gravity;
    [SerializeField] private float groundDistance;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private bool isCharGrounded = false;
    private Vector3 velocity = Vector3.zero;


    private void Start()
    {
        GetReferences();
        VariablesInit();
    }

    private void Update()
    {
        GroundedHandler();

        JumpHandler();

        GravityHandler();

        RunHandler();
        MoveHandler();

        QuitHandler();
    }

    private void GetReferences()
    {
        controller = GetComponent<CharacterController>();
    }

    private void VariablesInit()
    {
        MOVESPEED = WALKSPEED;
    }

    private void GroundedHandler()
    {
        isCharGrounded = Physics.CheckSphere(transform.position, groundDistance, groundMask);
    }
    private void GravityHandler()
    {
        if (isCharGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void JumpHandler()
    {
        if (Input.GetKeyDown(KeyCode.Space)  && isCharGrounded)
        {
            velocity.y += Mathf.Sqrt(JUMPFORCE * -2f * gravity);
        }
    }
    private void MoveHandler()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        DIRECTION = new Vector3(moveX, 0, moveZ);
        DIRECTION = DIRECTION.normalized;
        DIRECTION = transform.TransformDirection(DIRECTION);

        controller.Move(MOVESPEED * Time.deltaTime * DIRECTION);
    }
    private void RunHandler()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            MOVESPEED = RUNSPEED;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            MOVESPEED = WALKSPEED;
        }
    }

    private void QuitHandler()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && canQuit)
        {
            Debug.Log("Quitting Training");
            Application.Quit();
        }
    }

    public void CompletedTraining()
    {
        canQuit = true;
    }
}
