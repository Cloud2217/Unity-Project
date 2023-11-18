using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    //Animator animator = GetComponent<Animator>();
    public Transform cam;

    public CharacterController controller;
    public float speed = 6f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        applyGravity();

        Vector3 direction = new Vector3(horizontalInput, 0f, verticalInput).normalized;
        direction.Normalize();

        if (direction.magnitude >= 0.1f)
        {
            
            //gets angle player should face
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            //smooths roatation
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            //rotate player in the direction currently moving
            transform.rotation = Quaternion.Euler(0f, angle, 0);
            
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            
            controller.Move(moveDir.normalized * speed * Time.deltaTime);

        }
        
    }

//gravity function

    private void applyGravity()
    {
        Vector3 gravityVector = Vector3.zero;

        if(controller.isGrounded == false)
        {
            gravityVector += Physics.gravity;
        }
        controller.Move(gravityVector * Time.deltaTime);
    }

}