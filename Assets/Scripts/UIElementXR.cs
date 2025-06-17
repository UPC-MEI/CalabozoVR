using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class UIElementXR : MonoBehaviour
{

    public UnityEvent OnXRPointerEnter;
    public UnityEvent OnXRPointerExit;
    private Camera xRCamera;

    //AGREGADO PARA FUNCIONALIDAD DE ESTRELLA
    public GameObject DestinationObject;
    private bool ShowDestinationObject = false;
    public Material InactiveMaterial;
    private Renderer _myRenderer;
    public Material GazedAtMaterial;
    public VisibilityManager visibilityManager; 

    

    void Start()
    {
        xRCamera = CameraPointerManager.Instance.gameObject.GetComponent<Camera>();

        if (visibilityManager == null)
        {
            visibilityManager = FindObjectOfType<VisibilityManager>();
        }

    }

    public void OnPointerClickXR()
    {

        PointerEventData pointerEvent = PlacePointer();
        ExecuteEvents.Execute(this.gameObject, pointerEvent, ExecuteEvents.pointerClickHandler);

        DisplayContent();
    }

    public void OnPointerEnterXR() 
    {
        GazeManager.Instance.SetUpGaze(1.5f);
        OnXRPointerEnter?.Invoke();
        PointerEventData pointerEvent = PlacePointer();
        ExecuteEvents.Execute(this.gameObject, pointerEvent, ExecuteEvents.pointerDownHandler);
    }

    public void OnXRPointerExitXR()
    {
        GazeManager.Instance.SetUpGaze(2.5f);
        OnXRPointerExit?.Invoke();
        PointerEventData pointerEvent = PlacePointer();
        ExecuteEvents.Execute(this.gameObject, pointerEvent, ExecuteEvents.pointerUpHandler);

    }

    private PointerEventData PlacePointer()
    {
        Vector3 screenPos = xRCamera.WorldToScreenPoint(CameraPointerManager.Instance.hitPoint);
        var pointer = new PointerEventData(EventSystem.current);
        pointer.position = new Vector2(screenPos.x, screenPos.y);
        return pointer;
    }


    public void DisplayContent()
    {
        if(!ShowDestinationObject){
             DestinationObject.SetActive(true);
             ShowDestinationObject = true;

            if (visibilityManager != null)
            {
                visibilityManager.ChangeVisibility(gameObject);
            }
            else
            {
                Debug.LogWarning("VisibilityManager no está asignado.");
            }


        }else{
            DestinationObject.SetActive(false);
             ShowDestinationObject = false;
        }
        SetMaterial(false);
    }

    private void SetMaterial(bool gazedAt)
    {
        if (InactiveMaterial != null && GazedAtMaterial != null)
        {
            _myRenderer.material = gazedAt ? GazedAtMaterial : InactiveMaterial;
        }
    }


}
