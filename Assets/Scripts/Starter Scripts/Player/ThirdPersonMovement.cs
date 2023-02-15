using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Animations;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public float playerSpeed;

    public Rigidbody rb;

    public float jumpForce = 4;

    public Animator anim;

    public bool freezePlayer = false;

    public CapsuleCollider playerCollider;
    // Update is called once per frame
    void Update()
    {
        //Every update frame, get information about what is currently being pressed. (Axis buttons found in Unity->Edit->Project Settings->Input Manager)
        Movement();
        Jump();
    }

    private void Start()
    {
        playerCollider = gameObject.GetComponent<CapsuleCollider>();
        anim = anim == null ? gameObject.GetComponent<Animator>() : anim;
        rb = rb == null ? gameObject.GetComponent<Rigidbody>() : rb;
    }

    private void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 vec = new Vector3(horizontal, 0, vertical) * playerSpeed * Time.deltaTime;
        if (!freezePlayer)
        {
            transform.Translate(vec, Space.Self);
        }
       
        if (!freezePlayer && (horizontal != 0 || vertical != 0))
        {
            anim.SetBool("isMoving", true);
            if (TryGetComponent(out PlayerAudio audio))
            {
                audio.WalkSource.Play();
            }
        }
        else
        {
            anim.SetBool("isMoving", false);
            if (TryGetComponent(out PlayerAudio audio))
            {
                audio.WalkSource.Pause();
            }
        }
    }

    private void Jump()
    {
        bool jumpKeyPressed = Input.GetKeyDown(KeyCode.Space);
        if (jumpKeyPressed && isGrounded())
        {
            Vector3 jumpVector = Vector3.up * jumpForce;
            jumpVector.x = rb.velocity.x;
            jumpVector.z = rb.velocity.z;
            rb.velocity = jumpVector;
            if (TryGetComponent(out PlayerAudio audio))
            {
                audio.JumpSource.Play();
            }
        }
    }

    private bool isGrounded()
    {
        bool isGrounded = Physics.Raycast(transform.position, -gameObject.transform.up, playerCollider.bounds.extents.y + 0.1f);
        return isGrounded;
    }
}
