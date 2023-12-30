using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float sensitivity;
    private float mouseInput;
    private Rigidbody rb;
    private Vector3 input;
    private Animator anim;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim= GetComponent<Animator>();
    }

    private void Update()
    {
        input.z = Input.GetAxis("Vertical");
        input.x = Input.GetAxis("Horizontal");
        if(input!= Vector3.zero )
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }

        if (Input.GetMouseButton(1))
        {
            mouseInput = Input.GetAxis("Mouse X");
            transform.Rotate(Vector3.up*mouseInput*sensitivity);
            Cursor.lockState = CursorLockMode.Locked;
        }
        else if (Input.GetMouseButtonUp(1))
        {
            Cursor.lockState = CursorLockMode.None;
        }

    }
    private void FixedUpdate()
    {
        rb.MovePosition(transform.position + transform.TransformDirection(input) * speed * Time.fixedDeltaTime);
    }
}
