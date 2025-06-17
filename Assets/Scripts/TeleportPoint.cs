using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TeleportPoint : MonoBehaviour
{

    public UnityEvent OnTeleportEnter;
    public UnityEvent OnTeleport;
    public UnityEvent OnTeleportExit;

    // Start is called before the first frame update
    void Start()
    {
        //transform.GetChild(0).gameObject.SetActive(false);
    }

    public void OnPointerEnterXR() {
        OnTeleportEnter?.Invoke();
    }

    public void OnPointerClicXR() {
        OnTeleport?.Invoke();
        ExecuteTeleportation();        
        TeleportManager.Instance.DisableTeleportPoint(gameObject);
    }

    public void OnPointerExitXR() {
        OnTeleportExit?.Invoke();
    }

    private void ExecuteTeleportation() {
        GameObject player = TeleportManager.Instance.Player;

        if (player == null) {
            Debug.LogError("Player reference is missing in TeleportManager.");
            return;
        }

        CharacterController characterController = player.GetComponent<CharacterController>();
        if (characterController != null) characterController.enabled = false;

        player.transform.position = transform.position;
        player.transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);

        if (characterController != null) characterController.enabled = true;
    }

}
