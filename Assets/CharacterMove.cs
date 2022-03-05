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
    void Start(){
        body=GetComponent<Rigidbody2D>();
        original_gravity=body.gravityScale;
    }
    
    private void Jump(){
        if (isGround==true&&Input.GetKey(KeyCode.UpArrow)){
            //transform.Translate(0, 0, speed * Time.deltaTime);
            body.velocity=Vector2.up*power;
        }
    }

    private void Walk(){
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
    }
    public bool isLadder;
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Ladder")){
            isLadder=true;
        }

    }
    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Ladder")){
            isLadder=false;
        }
    }
}
 