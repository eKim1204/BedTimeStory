using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 3f;
    [HideInInspector] public Vector3 dir;
    float hInput, vInput;
    CharacterController controller;

    [SerializeField] float groundYOffset;
    [SerializeField] LayerMask groundMask;
    Vector3 spherePos;

    [SerializeField] float gravity = -9.81f;
    Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();    
    }
    private void GetDirectionAndMove()
    {
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");
        
        dir = transform.forward * vInput + transform.right * hInput;
        
        if(hInput == 0 && vInput == 0)
            PlayerStats.Instance.playerStatus = PlayerStats.Status.Idle;
        else if(IsRun())
        {
            PlayerStats.Instance.playerStatus = PlayerStats.Status.Walk;
            controller.Move(dir * (moveSpeed * 5f) * Time.deltaTime);
        }
        else
        {
            PlayerStats.Instance.playerStatus = PlayerStats.Status.Run;
            controller.Move(dir * moveSpeed * Time.deltaTime);
        }
    }
    // Update is called once per frame
    void Update()
    {
        GetDirectionAndMove();
        Gravity();
    }
    private bool IsGrounded()
    {
        spherePos = new Vector3(transform.position.x, transform.position.y - groundYOffset, transform.position.z);
        if (Physics.CheckSphere(spherePos, controller.radius - 0.05f, groundMask))
            return true;
        return false;
    }
    private bool IsRun() => Input.GetKey(KeyCode.LeftShift);
    private void Gravity()
    {
        if (!IsGrounded())
            velocity.y += gravity * Time.deltaTime;
        else if (velocity.y < 0)
            velocity.y = -2;

        controller.Move(velocity * Time.deltaTime);
    }
}
