# API Documentation - CalabozoVR

## 📋 Overview

This document provides comprehensive API documentation for all public classes, methods, and interfaces in the CalabozoVR project. The API is organized by functional areas and includes usage examples.

## 🏗️ Core Game Systems

### GameData

Manages game state and answer validation for the escape room.

```csharp
public class GameData : MonoBehaviour
```

#### Properties

| Property | Type | Access | Description |
|----------|------|--------|-------------|
| `CorrectAnswer` | `string` | `get/set` | The correct answer for the escape room puzzle. Default: "Baul" |

#### Methods

##### IsCorrectAnswer
```csharp
public static bool IsCorrectAnswer(string PlayAnswer)
```

**Description**: Validates if the provided answer matches the correct answer (case-insensitive).

**Parameters**:
- `PlayAnswer` (string): The player's submitted answer

**Returns**: `bool` - `true` if the answer is correct, `false` otherwise

**Example**:
```csharp
// Validate player answer
string playerInput = "baul";
bool isValid = GameData.IsCorrectAnswer(playerInput); // Returns true
```

---

### GameSettings

Static configuration class for global game settings.

```csharp
public static class GameSettings
```

#### Properties

| Property | Type | Access | Description |
|----------|------|--------|-------------|
| `PlayerSpeed` | `float` | `get/set` | Player movement speed. Values: 2.0f (Slow), 5.0f (Medium), 10.0f (Fast) |
| `PlayerTeleportationActivated` | `bool` | `get/set` | Whether teleportation mode is active. `false` = free movement, `true` = teleportation |

**Example**:
```csharp
// Configure player settings
GameSettings.PlayerSpeed = 10.0f; // Fast movement
GameSettings.PlayerTeleportationActivated = true; // Enable teleportation
```

---

## 🕹️ VR Interaction System

### CameraPointerManager

Singleton class managing VR pointer interactions and raycasting.

```csharp
public class CameraPointerManager : MonoBehaviour
```

#### Properties

| Property | Type | Access | Description |
|----------|------|--------|-------------|
| `Instance` | `CameraPointerManager` | `static get` | Singleton instance accessor |
| `hitPoint` | `Vector3` | `public` | Last raycast hit position in world space |

#### Fields

| Field | Type | Access | Description |
|-------|------|--------|-------------|
| `pointer` | `GameObject` | `[SerializeField] private` | Visual pointer object |
| `maxDistancePointer` | `float` | `[SerializeField] private` | Maximum pointer display distance (default: 4.5f) |
| `disPointerObject` | `float` | `[SerializeField] private` | Pointer distance ratio (0-1, default: 0.95f) |

#### Methods

##### Update
```csharp
public void Update()
```

**Description**: Performs raycast detection and manages object interactions every frame.

**Behavior**:
- Casts ray from camera forward direction
- Detects objects with "Interactable" or "Telepor" tags
- Triggers appropriate interaction events
- Updates pointer visual feedback

**Example**:
```csharp
// Access singleton instance
CameraPointerManager pointerManager = CameraPointerManager.Instance;

// Get current hit point
Vector3 currentHitPoint = pointerManager.hitPoint;
```

---

### UIElementXR

VR-adapted UI component for interactive elements.

```csharp
public class UIElementXR : MonoBehaviour
```

#### Events

| Event | Type | Description |
|-------|------|-------------|
| `OnXRPointerEnter` | `UnityEvent` | Triggered when pointer enters the element |
| `OnXRPointerExit` | `UnityEvent` | Triggered when pointer exits the element |

#### Properties

| Property | Type | Access | Description |
|----------|------|--------|-------------|
| `DestinationObject` | `GameObject` | `public` | Object to show/hide on interaction |
| `InactiveMaterial` | `Material` | `public` | Material when not being gazed at |
| `GazedAtMaterial` | `Material` | `public` | Material when being gazed at |
| `visibilityManager` | `VisibilityManager` | `public` | Reference to visibility manager |

#### Methods

##### OnPointerClickXR
```csharp
public void OnPointerClickXR()
```

**Description**: Handles VR pointer click interactions.

**Behavior**:
- Executes Unity's pointer click event
- Toggles destination object visibility
- Updates visibility manager
- Changes material state

**Example**:
```csharp
// Setup VR UI element
UIElementXR vrElement = GetComponent<UIElementXR>();
vrElement.DestinationObject = myTargetObject;
vrElement.visibilityManager = FindObjectOfType<VisibilityManager>();

// Events can be configured in Inspector or code
vrElement.OnXRPointerEnter.AddListener(() => Debug.Log("Pointer entered"));
```

---

## 🚶 Player Movement System

### VRLookWalk (PlayerMovementManager)

Handles VR-specific player movement using head tilt detection.

```csharp
public class VRLookWalk : MonoBehaviour
```

#### Fields

| Field | Type | Access | Description |
|-------|------|--------|-------------|
| `vrCamera` | `Transform` | `public` | Reference to the VR camera transform |
| `TeleportManager` | `GameObject` | `public` | Teleportation system GameObject |
| `toggleAngle` | `float` | `public` | Head tilt angle threshold for movement (default: 30°) |
| `speed` | `float` | `public` | Current movement speed |
| `moveForward` | `bool` | `public` | Whether player is currently moving forward |
| `teleportActivated` | `bool` | `public` | Current teleportation mode state |

#### Methods

##### EnablePlayerMovement
```csharp
private void EnablePlayerMovement()
```

**Description**: Handles free movement mode using head tilt detection.

**Algorithm**:
```csharp
if (vrCamera.eulerAngles.x >= toggleAngle && vrCamera.eulerAngles.x < 90.0f)
{
    moveForward = true;
    Vector3 forward = vrCamera.TransformDirection(Vector3.forward);
    characterController.SimpleMove(forward * speed);
}
```

**Example**:
```csharp
// Configure movement component
VRLookWalk movement = player.GetComponent<VRLookWalk>();
movement.vrCamera = Camera.main.transform;
movement.toggleAngle = 25f; // More sensitive tilt detection
```

---

### TeleportManager

Singleton managing teleportation system and teleport points.

```csharp
public class TeleportManager : MonoBehaviour
```

#### Properties

| Property | Type | Access | Description |
|----------|------|--------|-------------|
| `Instance` | `TeleportManager` | `static get` | Singleton instance accessor |
| `Player` | `GameObject` | `public` | Reference to player GameObject |

#### Methods

##### DisableTeleportPoint
```csharp
public void DisableTeleportPoint(GameObject teleportPoint)
```

**Description**: Disables a teleport point after use and re-enables the previous one.

**Parameters**:
- `teleportPoint` (GameObject): The teleport point to disable

**Behavior**:
- Reactivates the last used teleport point
- Deactivates the current teleport point
- Updates editor simulator position if in Unity editor

---

## 🎮 UI and Menu System

### VisibilityManager

Tracks object discovery progress and manages game progression.

```csharp
public class VisibilityManager : MonoBehaviour
```

#### Fields

| Field | Type | Access | Description |
|-------|------|--------|-------------|
| `scoreText` | `TMP_Text` | `public` | UI text displaying remaining objects |
| `option1` | `GameObject` | `public` | First answer option |
| `option2` | `GameObject` | `public` | Second answer option |
| `option3` | `GameObject` | `public` | Third answer option |
| `totalObjects` | `int` | `private` | Total objects to find (default: 3) |
| `hiddenObjectCount` | `int` | `private` | Number of objects found |

#### Methods

##### ChangeVisibility
```csharp
public void ChangeVisibility(GameObject obj)
```

**Description**: Processes object discovery and updates game state.

**Parameters**:
- `obj` (GameObject): The object that was found/interacted with

**Behavior**:
- Hides the discovered object
- Increments hidden object counter
- Updates score display
- Activates answer options when all objects found

---

## 🏷️ Tag System

### Required Tags

The system relies on specific tags for object detection:

| Tag | Purpose | Used By |
|-----|---------|---------|
| `"Interactable"` | Interactive objects that can be selected | CameraPointerManager |
| `"Telepor"` | Teleportation destination points | CameraPointerManager |

### Tag Usage Example

```csharp
// Setup interactive object
GameObject interactiveObj = new GameObject("Interactive Item");
interactiveObj.tag = "Interactable";
interactiveObj.AddComponent<UIElementXR>();
interactiveObj.AddComponent<Collider>();

// Setup teleport point
GameObject teleportPoint = new GameObject("Teleport Destination");
teleportPoint.tag = "Telepor";
teleportPoint.AddComponent<TeleportPoint>();
teleportPoint.AddComponent<Collider>();
```

---

## 🔧 Configuration and Constants

### Global Constants

```csharp
// Movement speeds
public const float SPEED_SLOW = 2.0f;
public const float SPEED_MEDIUM = 5.0f;
public const float SPEED_FAST = 10.0f;

// Interaction distances
public const float MAX_INTERACTION_DISTANCE = 10.0f;
public const float POINTER_DISPLAY_DISTANCE = 4.5f;

// Gaze timing
public const float GAZE_SELECTION_TIME = 1.5f;
public const float GAZE_EXIT_TIME = 2.5f;

// Movement detection
public const float HEAD_TILT_THRESHOLD = 30.0f;
```

This API documentation provides comprehensive coverage of all public interfaces in the CalabozoVR project, including usage examples and implementation details for VR development.