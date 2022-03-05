using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SpillPointScript : MonoBehaviour
{
    public Slider SplitSlider;
    public Slider TimerSlider;
    public int TimerRecover=3;
    bool repaired=false;
    public int ScoreUp=30;
    Sprite SpillPointImage;
    // Start is called before the first frame update
    void Start()
    {
        SpillPointImage=gameObject.GetComponent<SpriteRenderer>().sprite;

    }

    // Update is called once per frame
    void Update()
    {
        if (SplitSlider.value==10 && repaired==false) { // split point repair completed
            this.gameObject.GetComponent<SpriteRenderer>().sprite=Resources.Load<Sprite>("Square");
            SplitSlider.gameObject.SetActive(false);
            ScoreScript.score+=ScoreUp;
            SplitSlider.value=0;
            repaired=true;
            transform.parent.GetComponent<Collider2D>().isTrigger=false;
            transform.parent.GetComponent<Collider2D>().enabled=false;

            TimerSlider.value-=TimerRecover;
            Debug.Log(TimerSlider.value);

        }
    }
}
