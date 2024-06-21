using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public int scoreGive = 100;

    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Player")){
            Game.obj.addScore(scoreGive);
            gameObject.SetActive(false);
        }
    }
}
