using UnityEngine;
using UnityEngine.UI;

public class SpeedToggleVisibilityController : MonoBehaviour
{
    public GameObject speedOptionsGroup;
    public Toggle targetToggle;

    void Start()
    {
        if (targetToggle != null)
        {
            targetToggle.onValueChanged.AddListener(OnToggleChanged);
            OnToggleChanged(targetToggle.isOn);
        }
        else
        {
            Debug.LogError("Target Toggle is not assigned.");
        }
    }

    private void OnToggleChanged(bool isOn)
    {
        speedOptionsGroup.SetActive(isOn);
    }

    private void OnDestroy()
    {
        if (targetToggle != null)
        {
            targetToggle.onValueChanged.RemoveListener(OnToggleChanged);
        }
    }
}