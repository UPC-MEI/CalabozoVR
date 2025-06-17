using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class CloseDoorController : MonoBehaviour{
    public TMP_Text scoreText;
    
    public void closeDoor(){
        if(scoreText.text.Equals("Objetos Faltantes: 0")){
            gameObject.SetActive(true);
        }
    }

}
