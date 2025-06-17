using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHideInfo : MonoBehaviour
{

    public GameObject InfoObject;
    private bool Show = false;

    public void hideAndShowInfo(){
        if(!Show){
             InfoObject.SetActive(true);
             Show = true;
        }else{
            InfoObject.SetActive(false);
             Show = false;
        }
    }
}
