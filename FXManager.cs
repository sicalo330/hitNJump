using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXManager : MonoBehaviour
{
    public static FXManager obj;
    public GameObject pop;

    void Awake(){
        obj = this;
    }

    public void showPop(Vector3 pos){
        //No entendí del todo por qué debo poner el Script aí
        pop.gameObject.GetComponent<PopEffect>().show(pos);
    }

    private void OnDestroy(){
        obj = null;
    }

}
