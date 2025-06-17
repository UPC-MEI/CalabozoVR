using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;

public class StartButtonController : MonoBehaviour
{
    [SerializeField] private ToggleGroup movementOptionsGroup;
    [SerializeField] private ToggleGroup speedOptionsGroup;

    public void OnPointerClickXR()
    {
        Toggle selectedToggle = movementOptionsGroup.ActiveToggles().FirstOrDefault();

        if (selectedToggle != null){
            switch (selectedToggle.name)
            {
                case "Free":
                    GameSettings.PlayerTeleportationActivated = false;
                    break;
                case "Teleport":
                    GameSettings.PlayerTeleportationActivated = true;
                    break;
                default:
                    Debug.LogWarning("No matching movement found for the selected toggle.");
                    break;
            }
            SceneManager.LoadScene("CardboardCalabozo");
        }

        Toggle selectedSpeedToggle = speedOptionsGroup.ActiveToggles().FirstOrDefault();

        if (selectedSpeedToggle != null){
            switch (selectedSpeedToggle.name)
            {
                case "Slow":
                    GameSettings.PlayerSpeed = 2.0f;
                    Debug.Log("Player speed set to Slow");
                    break;
                case "Medium":
                    GameSettings.PlayerSpeed = 5.0f;
                    Debug.Log("Player speed set to Medium");
                    break;
                case "Fast":
                    GameSettings.PlayerSpeed = 10.0f;
                    Debug.Log("Player speed set to Fast");
                    break;
                default:
                    Debug.LogWarning("No matching speed option found.");
                    break;
            }
        }

    }
}