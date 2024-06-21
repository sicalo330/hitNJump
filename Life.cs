using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    public int scoreGive = 30;

    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Player")){
            Game.obj.addScore(scoreGive);
            Player.obj.addLive();
            gameObject.SetActive(false);
        }
    }
}
