using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitComponent : MonoBehaviour
{
    public void OnPointerClickXR(){
        Debug.Log("Quit App");
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
