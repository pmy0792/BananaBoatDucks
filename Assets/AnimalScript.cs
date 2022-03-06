using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalScript : MonoBehaviour
{
    public float speed=3.0f;
    public bool collided=false;
    public GameObject left;
    public GameObject right;
    bool mutated=false;
    public Animator animator;
    
    float timer=0f;
    // Start is called before the first frame update
    void Start()
    {
        animator=GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Debug.Log("speed:"+speed.ToString());
        transform.Translate(Vector2.right*speed*Time.deltaTime);
        
        if (speed!=3f){
            timer+=Time.deltaTime;
            if (timer>1){
                speed=3f;
                timer=0;
            }
        }

    }

/*
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag=="Player"){
            
        }
    }
    */

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag=="Player"){
            if (!mutated){
                animator.SetTrigger("mutate");
                Debug.Log("Mutated");
            }
        }
    }

}
