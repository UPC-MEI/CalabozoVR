using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndGameController : MonoBehaviour
{
    public AnimationController animationController;
    public GameObject finalScreen;
    public GameObject menuCanvas;
    public Transform player;
    public string optionAnswerText;
    public TMP_Text statusText;

    private const float fixedDistance = 5f;

    void Start()
    {
        menuCanvas.SetActive(false);
        statusText.text = "";  // Ensure the status text starts empty
    }
    
    void Update()
    {
        if (animationController.isFocused && animationController.isShining)
        {
            menuCanvas.SetActive(false);
        }
    }

    public void OnPointerClickXR()
    {
        if (animationController == null)
        {
            Debug.LogError("AnimationController reference not set in EndGameController.");
            return;
        }

        animationController.isShining = !animationController.isShining;

        if (animationController.isShining)
        {
            menuCanvas.SetActive(false); 
            EnablePlayerMovement();
        }
        else
        {
            StopPlayerMovement();
            PositionPlayerInFrontOfMenu();
            menuCanvas.SetActive(true);
            finalScreen.SetActive(false);

            // Display correct answer and status
            DisplayGameStatus();
        }
    }

    private void PositionPlayerInFrontOfMenu()
    {
        Vector3 directionToMenu = (menuCanvas.transform.position - player.position).normalized;
        player.position = menuCanvas.transform.position - directionToMenu * fixedDistance;
        Quaternion lookRotation = Quaternion.LookRotation(directionToMenu);
        player.rotation = lookRotation * Quaternion.Euler(0, 180, 0);
    }

    private void StopPlayerMovement()
    {
        VRLookWalk playerMovementScript = player.GetComponent<VRLookWalk>();
        if (playerMovementScript != null)
        {
            playerMovementScript.enabled = false;
        }

        CharacterController characterController = player.GetComponent<CharacterController>();
        if (characterController != null)
        {
            characterController.enabled = false;
        }
    }

    private void EnablePlayerMovement()
    {
        VRLookWalk playerMovementScript = player.GetComponent<VRLookWalk>();
        if (playerMovementScript != null)
        {
            playerMovementScript.enabled = true;
        }

        CharacterController characterController = player.GetComponent<CharacterController>();
        if (characterController != null)
        {
            characterController.enabled = true;
        }
    }

    private void DisplayGameStatus()
    {
        if (statusText != null)
        {
            // Check and display if the answer was correct or not
            if (GameData.IsCorrectAnswer(optionAnswerText))
            {
                statusText.text = "Has ganado! La respuesta era: " + optionAnswerText;
            }
            else
            {
                statusText.text = "Sigue intentando!";
            }
        }
    }
}