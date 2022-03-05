using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderScript : MonoBehaviour
{
    public Collider2D platformCollider;
    private void OnTriggerStay2D(Collider2D other) {
        if (other.CompareTag("Player")){
            Physics2D.IgnoreCollision(other.GetComponent<Collider2D>(),platformCollider,true);
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player")){
            Physics2D.IgnoreCollision(other.GetComponent<Collider2D>(),platformCollider,false);
        }
    }
}
