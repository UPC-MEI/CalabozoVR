using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuComponent : MonoBehaviour
{
    public void OnPointerClickXR(){
        Debug.Log("MainMenu");
        SceneManager.LoadScene(0); 
    }
}
