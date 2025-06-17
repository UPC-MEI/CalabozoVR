# Developer Guide - CalabozoVR

## 🛠️ Development Environment Setup

### Prerequisites

Before starting development on CalabozoVR, ensure you have the following tools installed:

#### Required Software
- **Unity Hub**: Latest version
- **Unity Editor**: 2022.3 LTS (recommended)
- **Visual Studio**: 2022 Community or Professional
  - Alternative: Visual Studio Code with C# extension
- **Android Studio**: Latest version (for SDK and device debugging)
- **Git**: For version control
- **ADB (Android Debug Bridge)**: For device testing

#### Unity Packages Required
```json
{
  "com.google.xr.cardboard": "1.26.0",
  "com.unity.textmeshpro": "3.0.6",
  "com.unity.xr.management": "4.3.3",
  "com.unity.xr.legacyinputhelpers": "2.1.10"
}
```

### Initial Setup

#### 1. Clone and Setup Repository
```bash
# Clone the repository
git clone https://github.com/yourusername/CalabozoVR.git
cd CalabozoVR

# Create development branch
git checkout -b feature/your-feature-name
```

#### 2. Unity Configuration
```csharp
// Unity Version: 2022.3.x LTS
// Platform: Android
// Rendering Pipeline: Built-in Render Pipeline
// Color Space: Linear (recommended for VR)
```

#### 3. Android SDK Setup
```bash
# Set ANDROID_HOME environment variable
export ANDROID_HOME=/path/to/android-sdk

# Verify ADB installation
adb version

# Enable Developer Options on test device
# Settings > About > Build Number (tap 7 times)
# Settings > Developer Options > USB Debugging (enable)
```

## 📁 Project Structure Deep Dive

### Directory Organization

```
CalabozoVR/
├── Assets/
│   ├── Scripts/                    # All C# scripts
│   │   ├── Menu/                   # Menu-related scripts
│   │   ├── VR/                     # VR-specific components
│   │   ├── Player/                 # Player mechanics
│   │   └── Utilities/              # Helper scripts
│   ├── Scenes/                     # Unity scenes
│   ├── Prefabs/                    # Reusable objects
│   ├── Materials/                  # Shaders and materials
│   ├── Textures/                   # Image assets
│   ├── Audio/                      # Sound effects and music
│   ├── Models/                     # 3D models
│   └── Resources/                  # Runtime loadable assets
├── ProjectSettings/                # Unity project settings
├── Packages/                       # Package dependencies
├── Logs/                          # Unity logs
└── Documentation/                  # Project documentation
```

## 🧱 Core Systems Development

### VR Interaction System

#### Creating Interactive Objects

```csharp
[RequireComponent(typeof(Collider))]
public class InteractableObject : MonoBehaviour
{
    [Header("Interaction Settings")]
    public Material defaultMaterial;
    public Material hoveredMaterial;
    public UnityEvent onInteract;
    
    private Renderer objectRenderer;
    private bool isInteractable = true;
    
    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        gameObject.tag = "Interactable";
        
        Collider col = GetComponent<Collider>();
        col.isTrigger = false; // Use solid colliders for raycast
    }
    
    public void OnPointerEnterXR()
    {
        if (isInteractable)
        {
            objectRenderer.material = hoveredMaterial;
            GazeManager.Instance.SetUpGaze(1.5f);
        }
    }
    
    public void OnPointerExitXR()
    {
        objectRenderer.material = defaultMaterial;
        GazeManager.Instance.SetUpGaze(2.5f);
    }
    
    public void OnPointerClickXR()
    {
        if (isInteractable)
        {
            onInteract?.Invoke();
            SetInteractable(false);
        }
    }
}
```

## 🧪 Testing and Debugging

### Editor Testing with Cardboard Simulator

```csharp
public class AdvancedCardboardSimulator : MonoBehaviour
{
    [Header("Simulator Settings")]
    public bool enableInEditor = true;
    public float mouseSensitivity = 2f;
    public KeyCode resetViewKey = KeyCode.R;
    
    #if UNITY_EDITOR
    void Update()
    {
        if (!enableInEditor) return;
        
        HandleMouseLook();
        HandleKeyboardInput();
    }
    
    private void HandleMouseLook()
    {
        if (Input.GetMouseButton(1))
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;
            transform.Rotate(-mouseY, mouseX, 0);
        }
    }
    #endif
}
```

## 🔧 Build and Deployment

### Build Configuration

```csharp
using UnityEditor;
using UnityEngine;

public class BuildScript
{
    [MenuItem("Build/Build Android")]
    public static void BuildAndroid()
    {
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.scenes = new[] { 
            "Assets/Scenes/MainMenu.unity", 
            "Assets/Scenes/CardboardCalabozo.unity" 
        };
        buildPlayerOptions.locationPathName = "Builds/CalabozoVR.apk";
        buildPlayerOptions.target = BuildTarget.Android;
        buildPlayerOptions.options = BuildOptions.None;
        
        PlayerSettings.Android.minSdkVersion = AndroidSdkVersions.AndroidApiLevel24;
        PlayerSettings.Android.targetSdkVersion = AndroidSdkVersions.AndroidApiLevel31;
        
        BuildPipeline.BuildPlayer(buildPlayerOptions);
    }
}
```

## 📊 Code Quality and Standards

### Performance Checklist
- [ ] No Update() methods with heavy operations
- [ ] Raycast operations are optimized
- [ ] Object pooling used where appropriate
- [ ] Materials are shared, not instanced
- [ ] Textures use appropriate compression (ASTC for Android)

### VR-Specific Checklist
- [ ] Frame rate maintains 60 FPS on target devices
- [ ] No sudden camera movements that cause motion sickness
- [ ] UI elements are appropriately sized for VR viewing
- [ ] Interaction feedback is immediate and clear
- [ ] Audio is spatially positioned correctly

This comprehensive developer guide provides the essential information needed to develop and extend the CalabozoVR project.