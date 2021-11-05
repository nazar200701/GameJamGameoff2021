using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class ThertMovementScript : MonoBehaviour
{
    
    public Transform cam;

    public float jumpPower = 500f;
    public float speed = 10f;
    float turnSmoothVelocity;
    public bool ground;
    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        MovementLogic();
        JumpLogic();
    }
    private void MovementLogic()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical).normalized;

        transform.Translate(movement * speed * Time.fixedDeltaTime);

        //Vector3 direction = new Vector3(moveHorizontal, 0f, moveVertical).normalized;

        if (movement.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(movement.x, movement.y) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothVelocity);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            //controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
    }

    //void Update()
    //{
    //    float horizontal = Input.GetAxisRaw("Horizontal");
    //    float vertical = Input.GetAxisRaw("Vertical");
    //    Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

    //    if (direction.magnitude >= 0.1f)
    //    {
    //        float targetAngle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg + cam.eulerAngles.y;
    //        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothVelocity);
    //        transform.rotation = Quaternion.Euler(0f, angle, 0f);

    //        Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
    //        controller.Move(moveDir.normalized * speed * Time.deltaTime);
    //    }


    //}
    private void JumpLogic()
    {
        if (Input.GetAxis("Jump") > 0)
        {
            if (ground)
            {
                rb.AddForce(Vector3.up * jumpPower);
            }
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        IsGroundedUpate(collision, true);
    }

    void OnCollisionExit(Collision collision)
    {
        IsGroundedUpate(collision, false);
    }

    private void IsGroundedUpate(Collision collision, bool value)
    {
        if (collision.gameObject.tag == ("Ground"))
        {
            ground = value;
        }
    }
}
