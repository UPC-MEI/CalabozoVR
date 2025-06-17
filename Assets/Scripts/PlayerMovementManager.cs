using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRLookWalk : MonoBehaviour
{

    public Transform vrCamera;
    public GameObject TeleportManager;
    public float toggleAngle = 30.0f;
    public float speed;
    public bool moveForward;
    public bool teleportActivated;

    private CharacterController cc;

    void Start(){
        cc = GetComponent<CharacterController>();
        speed = GameSettings.PlayerSpeed;
        teleportActivated = GameSettings.PlayerTeleportationActivated;
        TeleportManager.SetActive(teleportActivated);
    }

    void Update(){
        teleportActivated = GameSettings.PlayerTeleportationActivated;
        TeleportManager.SetActive(teleportActivated);

        if (teleportActivated){
            StopPlayerMovement();
        }
        else{
            EnablePlayerMovement();
        }

    }

    private void EnablePlayerMovement(){
        if (vrCamera.eulerAngles.x >= toggleAngle && vrCamera.eulerAngles.x < 90.0f){
            moveForward = true;
        }
        else{
            moveForward = false;
        }

        if (moveForward ){
            Vector3 forward = vrCamera.TransformDirection(Vector3.forward);
            cc.SimpleMove(forward * speed);
        }
    }

    private void StopPlayerMovement(){
        moveForward = false;
        cc.SimpleMove(Vector3.zero);
    }



}