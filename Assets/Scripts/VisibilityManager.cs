using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VisibilityManager : MonoBehaviour
{
    public TMP_Text scoreText;

    public GameObject option1;
    public GameObject option2;
    public GameObject option3;

    private int totalObjects = 3;
    private int hiddenObjectCount = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void ChangeVisibility(GameObject obj)
    {
        obj.SetActive(false);
        
        hiddenObjectCount++;
        int difference = totalObjects - hiddenObjectCount;
        int remainingObjects =  (difference < 0) ? 0 : difference;
        scoreText.text = "Objetos Faltantes: " + remainingObjects;

        if (hiddenObjectCount == totalObjects)
        {
            option1?.gameObject?.SetActive(true);
            option2?.gameObject?.SetActive(true);
            option3?.gameObject?.SetActive(true);
        }
    }
}
