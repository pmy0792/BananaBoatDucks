using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  

public class SpillScript : MonoBehaviour
{
    public Slider splitSlider;
    public float speed=2f;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D other) {
        if (other.tag=="Player"){
            if (splitSlider.gameObject.activeSelf==false){
                splitSlider.gameObject.SetActive(true);
                }

            splitSlider.value += Time.deltaTime * speed;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag=="Player"){
            if (splitSlider.value==10){
                // spill go away
            }
            else{
                splitSlider.value=0;
            }
            splitSlider.gameObject.SetActive(false);
        }
    }
}
