using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMove : MonoBehaviour{
    public Collider swordCollider;
    private Rigidbody playerRB;
    Animator animator;

    public float speed = 6.0f;
    public float rotationSpeed;


    void Start(){
        swordCollider.enabled = false;
        playerRB = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Update(){
        if(!animator.GetBool("isAttacking")){
            walk();
        }
        
    }

    void walk(){
        if(Input.GetKey("space")){
            animator.SetBool("isAttacking", true);
            animator.SetBool("isWalking", false);
            swordCollider.enabled = true;
            //attacking = true;
            return;
        }

        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        //playerRB.AddForce(Vector3.forward * verticalInput * speed);
        Vector3 direction = new Vector3(horizontalInput, 0f, verticalInput).normalized;
        direction.Normalize();

        transform.Translate(direction * speed * Time.deltaTime, Space.World);
        
        if (direction != Vector3.zero)
        {
            animator.SetBool("isWalking",true);
            Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);            
        }
        /*
        if (direction.magnitude >= 0.1f)
        {
            animator.SetBool("isWalking",true);
            playerRB.AddForce(Vector3.forward * verticalInput * speed);
            playerRB.AddForce(Vector3.right * horizontalInput * speed);
            //playerRB.AddForce(direction * speed * Time.deltaTime);
        }
        */
        else{
            animator.SetBool("isWalking",false);
        }


    void endAttack(){
        animator.SetBool("isAttacking", false);
        swordCollider.enabled = false;
    }
    }
}

