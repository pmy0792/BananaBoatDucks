using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalScript : MonoBehaviour
{
    public float speed=3.0f;
    public bool collided=false;
    public GameObject left;
    public GameObject right;
    float timer=0f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Debug.Log("speed:"+speed.ToString());
        transform.Translate(Vector2.left*speed*Time.deltaTime);
        
        if (speed!=3f){
            timer+=Time.deltaTime;
            if (timer>1){
                speed=3f;
                timer=0;
            }
        }

    }
    

}
