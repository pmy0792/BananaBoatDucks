using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float rotSpeed=3.0f;
    int random;
    // Start is called before the first frame update
    void Start()
    {
        random=Random.Range(0,180);
        transform.rotation=Quaternion.Euler(new Vector3(random,random,0));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, rotSpeed * Time.deltaTime, rotSpeed * Time.deltaTime));
    }
}
