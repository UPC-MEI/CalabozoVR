using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public float bounceHeight = 0.2f;          
    public float bounceSpeed = 3f;            
    public Color shineColor = Color.yellow;    
    public float maxGlowIntensity = 1.5f;      
    public float glowSpeed = 2f;            
    public float rotationSpeedZ = 15f;       
    public float pulseScaleAmount = 0.1f;     
    public float pulseSpeed = 2f;             
    public bool isShining = true;            
    public bool isFocused = false;            

    private Vector3 originalPosition;       
    private Vector3 originalScale;           
    private Renderer objectRenderer;           

    void Start()
    {
        originalPosition = transform.position;
        originalScale = transform.localScale;

        objectRenderer = GetComponent<Renderer>();
        objectRenderer.material.EnableKeyword("_EMISSION");
    }

    void Update()
    {
        if (isFocused && isShining)
        {
            Shine();
            //RotateOnZ();
            PulseSize();
        }
        else
        {
            transform.position = originalPosition;
            transform.localScale = originalScale;
            Bounce();
            StopShining();
        }
    }

    private void Bounce()
    {
        float newY = originalPosition.y + Mathf.Sin(Time.time * bounceSpeed) * bounceHeight;
        transform.position = new Vector3(originalPosition.x, newY, originalPosition.z);
    }

    private void Shine()
    {
        float glowIntensity = (Mathf.Sin(Time.time * glowSpeed) * 0.5f + 0.5f) * maxGlowIntensity;
        objectRenderer.material.SetColor("_EmissionColor", shineColor * glowIntensity);
    }

    private void StopShining()
    {
        objectRenderer.material.SetColor("_EmissionColor", Color.black);
    }

    private void RotateOnZ()
    {
        float rotationZ = rotationSpeedZ * Time.deltaTime;
        transform.Rotate(0, 0, rotationZ, Space.Self);
    }

    private void PulseSize()
    {
        float scalePulse = 1 + Mathf.Sin(Time.time * pulseSpeed) * pulseScaleAmount;
        transform.localScale = originalScale * scalePulse;
    }

    public void OnPointerEnterXR()
    {
        isFocused = true;
    }

    public void OnPointerExitXR()
    {
        isFocused = false;
    }
}