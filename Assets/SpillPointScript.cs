using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SpillPointScript : MonoBehaviour
{
    public Slider SplitSlider;
    public Slider TimerSlider;
    public float TimerRecover=3f;
    bool repaired=false;
    public float speed=3f;
    public int ScoreUp=30;
    Sprite SpillPointImage;

    public Animator animator;
    public SpriteRenderer rend;
    // Start is called before the first frame update
    void Start()
    {
        SpillPointImage=gameObject.GetComponent<SpriteRenderer>().sprite;
        //animator=GetComponent<Animator>();
        //rend=GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (SplitSlider.value==10 && repaired==false) { // split point repair completed
            this.gameObject.GetComponent<SpriteRenderer>().sprite=Resources.Load<Sprite>("repaired_5");
            SplitSlider.gameObject.SetActive(false);
            ScoreScript.score+=ScoreUp;
            SplitSlider.value=0;
            repaired=true;
            transform.GetComponent<Collider2D>().isTrigger=false;
            transform.GetComponent<Collider2D>().enabled=false;

            TimerSlider.value+=1000*Time.deltaTime;

        }
    }

        private void OnTriggerStay2D(Collider2D other) {
        if (other.tag=="Player"){
            if (SplitSlider.gameObject.activeSelf==false){
                SplitSlider.gameObject.SetActive(true);
                }

            SplitSlider.value += Time.deltaTime * speed;

            //animation trigger
            
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag=="Player"){
            if (SplitSlider.value==10){
                // spill go away
            }
            else{
                SplitSlider.value=0;
            }
            SplitSlider.gameObject.SetActive(false);
        }
    }
}
