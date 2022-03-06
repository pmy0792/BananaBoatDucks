using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightCollider : MonoBehaviour
{
    bool movingRight=true;
    //public Animator animator;
    bool mutated=false;
    public float speed2=3f;
    public int pushPower=100;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag=="Player"){
            if (!mutated){
                Debug.Log("mutated!");
                transform.parent.GetComponent<Animator>().SetTrigger("mutate");
                mutated=true;
            }

            else{
                if (movingRight){
                    other.GetComponent<Rigidbody2D>().AddForce(transform.right*pushPower,ForceMode2D.Impulse);
                }
                else{
                    other.GetComponent<Rigidbody2D>().AddForce(transform.right*pushPower,ForceMode2D.Impulse);
                }
            }

        }
        if (movingRight){
            if (other.tag=="Wall"){
                Debug.Log("**");
                transform.parent.GetComponent<Transform>().eulerAngles=new Vector3(0,180,0);
                
                movingRight=false;
            }
        }
        else{
            if (other.tag=="Wall"){
               transform.parent.GetComponent<Transform>().eulerAngles=new Vector3(0,0,0);
               movingRight=true;
            }
        }
    }
    private void OnTriggerStay2D(Collider2D other) {
        if (other.tag=="Player"){
            if (movingRight){
                other.GetComponent<Rigidbody2D>().AddForce(transform.right*pushPower,ForceMode2D.Impulse);
            }
            else{
                other.GetComponent<Rigidbody2D>().AddForce(transform.forward*pushPower,ForceMode2D.Impulse);
            }

        }
    }
}
