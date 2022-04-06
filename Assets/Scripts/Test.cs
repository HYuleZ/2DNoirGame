using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] float speed, gravity, jumpForce;

    public LayerMask groundLayer;

    CharacterController characterController;
    Vector3 direction;
    [SerializeField] bool isGrounded;
    
    void Start()
    {
        characterController = GetComponent<CharacterController>();    
    }

    void Update()
    {
        Move();
        Jump();
    }

    void Move(){
        float hInput = Input.GetAxis("Horizontal");
        direction.x = hInput * speed;

        characterController.Move(direction * Time.deltaTime);
    }

    void Jump(){
        if(isGrounded){
            direction.y = -1;
            if(Input.GetButtonDown("Jump")){
                direction.y = jumpForce;
            }
        }else{
            direction.y += gravity * Time.deltaTime;
        }
    }

    public void SetGroundedState(bool _grounded){
        isGrounded = _grounded;
    }
}
