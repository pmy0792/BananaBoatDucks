using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopCollider : MonoBehaviour
{
    bool mutated=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {  
        if (mutated){
            
        }
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (!mutated){
            if (other.tag=="Player"){
                mutated=true;
            }
        }
    }
}
