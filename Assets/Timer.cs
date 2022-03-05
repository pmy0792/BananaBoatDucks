using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   // Silder class 사용하기 위해 추가합니다.
using UnityEngine.SceneManagement;
public class Timer : MonoBehaviour
{
    public static Slider slTimer;
    float fSliderBarTime;
    public float speed=2f;
    void Start()
    {
        slTimer = GetComponent<Slider>();
    }
 
    void Update()
    {
        if (slTimer.value > 0.0f)
        {
            // 시간이 변경한 만큼 slider Value 변경을 합니다.
            slTimer.value -= speed * Time.deltaTime;
        }
        else
        {
            Debug.Log("Time is Zero.");
        }

        if (slTimer.value==0.0f){
            SceneManager.LoadScene("GameOverScene");
        }
    }
}
