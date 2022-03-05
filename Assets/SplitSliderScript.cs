using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  



public class SplitSliderScript : MonoBehaviour
{
    Slider splitSlider;
    // Start is called before the first frame update
    void Start()
    {
        splitSlider = GetComponent<Slider>();
        splitSlider.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
