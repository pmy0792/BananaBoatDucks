using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal2Script : MonoBehaviour
{
    public float speed=0.2f;
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
        transform.Translate(Vector2.left*speed*Time.deltaTime);
    

    }
    

}
