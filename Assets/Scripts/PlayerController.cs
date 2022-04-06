using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed, jumpForce, gravity;
    public Animator animator;

    CharacterController cc;
    // Rigidbody rb;
    Vector3 direction;
    bool faceRight = true;

    [SerializeField] bool grounded;

    void Start()
    {
        // rb = GetComponent<Rigidbody>();
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        Move();
        Jump();
    }

    void Move(){
        float hInput = Input.GetAxis("Horizontal");
        direction.x = hInput * speed;
        animator.SetFloat("Run", hInput);
        cc.Move(direction * Time.deltaTime);

        if(hInput > 0 && !faceRight){
            Flip();
        }else if(hInput < 0 && faceRight){
            Flip();
        }
    }

    void Jump(){
        if(grounded){
            if(Input.GetKeyDown(KeyCode.Space)){
                // rb.AddForce(new Vector3(0,jumpForce,0));
                direction.y = jumpForce;
            }
        }if(!grounded){
            direction.y += gravity * Time.deltaTime;
        }
    }

    void Flip(){
        faceRight = !faceRight;

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    public void SetGroundedState(bool _grounded){
        grounded = _grounded;
        if(_grounded){
            animator.SetInteger("Jump", 0);
        }else{
            animator.SetInteger("Jump", 1);
        }
    }
}
