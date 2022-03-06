using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class CharacterMove : MonoBehaviour
{
    Rigidbody2D body;
    public float speed = 5f;
    [SerializeField]
    private float power=1f;
    float original_gravity;
    bool isGround;
    [SerializeField]
    Transform pos;
    [SerializeField]
    float checkRadius;
    [SerializeField]
    LayerMask islayer;

    float horizontal;
    public Animator animator;
    public SpriteRenderer rend;
    bool repairing=false;
    void Start(){
        body=GetComponent<Rigidbody2D>();
        original_gravity=body.gravityScale;
        animator=GetComponent<Animator>();
        rend=GetComponent<SpriteRenderer>();
    }
    
    private void Jump(){
        if (isGround==true&&Input.GetKey(KeyCode.UpArrow)){
            //transform.Translate(0, 0, speed * Time.deltaTime);
            animator.SetBool("isJumping",true);
            animator.SetTrigger("doJumping");
            body.velocity=Vector2.up*power;
        }
        
    }

    private void Walk(){
        if (!repairing){
            horizontal=Input.GetAxis("Horizontal");
            if (horizontal!=0){
                animator.SetBool("run",true);
                if (horizontal>0) rend.flipX=false;
                else rend.flipX=true;
                }

            else animator.SetBool("run",false);
            if (Input.GetKey(KeyCode.LeftArrow)){
                transform.Translate(-speed * Time.deltaTime, 0, 0);
            }
            else if (Input.GetKey(KeyCode.RightArrow)){
                transform.Translate(speed * Time.deltaTime, 0, 0);
            }
            
            else if (Input.GetKey(KeyCode.DownArrow)){ // not necessary
                transform.Translate(0, 0, -speed * Time.deltaTime);
            }
        }
    }
    void FixedUpdate(){
        isGround=Physics2D.OverlapCircle(pos.position,checkRadius,islayer);
        Walk();

        if (isLadder){
            float ver=Input.GetAxis("Vertical");
            body.gravityScale=0;
            body.velocity=new Vector2(body.velocity.x,ver*speed);
        }
        else{
            body.gravityScale=original_gravity;
            Jump();
        }

        if (Physics2D.OverlapCircle(pos.position,checkRadius,islayer) && body.velocity.y<0){
            animator.SetBool("isJumping",false);
        }
    }
    public bool isLadder;
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Ladder")){
            isLadder=true;
            }
        }
    
    private void OnTriggerStay2D(Collider2D other) {
        if (other.CompareTag("Ladder")){
             if (Input.GetKey(KeyCode.UpArrow)){
                animator.SetTrigger("doClimbing");
                animator.SetBool("isClimbing",true);}
        }

        if (other.CompareTag("Spill")){
            if (Input.GetKey(KeyCode.RightArrow)){
                animator.SetBool("hammering",true);
                repairing=true;
            }
        }

    }
    
    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Ladder")){
            isLadder=false;
            animator.SetBool("isClimbing",false);
        }
        if (other.CompareTag("Spill")){
            animator.SetBool("hammering",false);
            repairing=false;
        }
    }
    
}
 