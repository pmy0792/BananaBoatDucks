using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftColliderScript : MonoBehaviour
{
    bool movingLeft=true;
    public float speed2=3f;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (movingLeft){
            if (other.tag=="Player" || other.tag=="Wall"){
                transform.parent.GetComponent<Transform>().eulerAngles=new Vector3(0,180,0);
                movingLeft=false;
            }
        }
        else{
            if (other.tag=="Player" || other.tag=="Wall"){
               transform.parent.GetComponent<Transform>().eulerAngles=new Vector3(0,0,0);
               movingLeft=true;
            }
        }
    }
}
