using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopEffect : MonoBehaviour
{
    public static PopEffect obj;

    void Awake(){
        obj = this;
    }

    public void show(Vector3 pos){
        transform.position = pos;
        gameObject.SetActive(true);
    }

    public void dissapear(){
        gameObject.SetActive(false);
    }
    void OnDestroy(){
        obj = null;
    }
}
