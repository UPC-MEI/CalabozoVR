# CalabozoVR - Virtual Reality Escape Room

A immersive VR escape room experience built with Unity and Google Cardboard XR Plugin.

## 📱 Overview

CalabozoVR is a virtual reality escape room game where players must find hidden objects and solve puzzles to escape from a dungeon. The game features intuitive gaze-based interactions and supports both free movement and teleportation modes.

## ✨ Features

- **VR-Optimized Gameplay**: Designed specifically for Google Cardboard devices
- **Gaze-Based Interactions**: Natural pointing and selection using head movements
- **Dual Movement Systems**: Choose between free walking or teleportation
- **Configurable Settings**: Adjustable movement speed and interaction preferences
- **Immersive Experience**: 3D spatial audio and haptic feedback
- **Cross-Platform**: Compatible with Android devices supporting Google Cardboard

## 🎯 Gameplay

### Objective
Escape the dungeon by finding 3 hidden objects and solving the final puzzle.

### Controls
- **Look**: Direct your gaze toward objects to highlight them
- **Select**: Keep looking at an object for 1.5 seconds or tap the screen
- **Move**: Tilt your head down to move forward (free movement mode)
- **Teleport**: Look at blue teleport points and select them (teleport mode)

## 🛠️ System Requirements

### Development Environment
- **Unity**: 2022.3 LTS or newer
- **Visual Studio**: 2019 or newer (or Visual Studio Code)
- **Android SDK**: Latest version
- **Git**: For version control

### Runtime Requirements
- **Platform**: Android 7.0 (API level 24) or higher
- **RAM**: Minimum 3GB recommended
- **Storage**: 200MB available space
- **VR Device**: Google Cardboard compatible headset
- **Sensors**: Gyroscope and accelerometer required

### Unity Packages
- Google Cardboard XR Plugin 1.26.0
- TextMeshPro (included)
- XR Plugin Management
- Unity Input System (optional)

## 🚀 Installation & Setup

### For Development

1. **Clone the Repository**
   ```bash
   git clone https://github.com/UPC-MEI/CalabozoVR.git
   cd CalabozoVR
   ```

2. **Open in Unity**
   - Launch Unity Hub
   - Click "Open" and select the CalabozoVR folder
   - Unity will import packages automatically

3. **Configure Build Settings**
   - Go to File → Build Settings
   - Switch platform to Android
   - Set Texture Compression to ASTC
   - Configure Player Settings:
     - Company Name: Your company
     - Product Name: CalabozoVR
     - Bundle Identifier: com.yourcompany.calabozovr

4. **XR Settings**
   - Go to Edit → Project Settings → XR Plug-in Management
   - Enable "Google Cardboard" provider
   - Ensure "Initialize XR on Startup" is checked

5. **Android Configuration**
   - Set Minimum API Level to 24
   - Set Target API Level to latest
   - Enable "Internet Access" if needed
   - Configure signing keys for distribution

### For End Users

1. **Download & Install**
   - Download the APK from releases page
   - Enable "Unknown Sources" in Android settings
   - Install the APK file

2. **Setup VR Headset**
   - Insert your Android device into Google Cardboard
   - Ensure proper lens alignment
   - Adjust for comfortable viewing

3. **Launch Game**
   - Open CalabozoVR app
   - Follow on-screen calibration instructions
   - Begin your escape room adventure!

## 🏗️ Project Structure

```
CalabozoVR/
├── Assets/
│   ├── Scripts/
│   │   ├── Menu/                 # UI and menu logic
│   │   │   ├── GameData.cs       # Game state management
│   │   │   ├── GameSettings.cs   # Global settings
│   │   │   └── ...
│   │   ├── CameraPointerManager.cs  # VR interaction system
│   │   ├── PlayerMovementManager.cs # Player locomotion
│   │   ├── TeleportManager.cs       # Teleportation system
│   │   └── ...
│   ├── Scenes/
│   │   ├── MainMenu.unity        # Main menu scene
│   │   └── CardboardCalabozo.unity # Main game scene
│   ├── Prefabs/                  # Reusable game objects
│   ├── Materials/                # Textures and materials
│   └── Audio/                    # Sound effects and music
├── ProjectSettings/              # Unity project configuration
├── Packages/                     # Package dependencies
└── README.md
```

## 🎮 Game Configuration

### Movement Settings
```csharp
// Available in GameSettings.cs
public static float PlayerSpeed { get; set; } = 5.0f;           // 2.0f (Slow), 5.0f (Medium), 10.0f (Fast)
public static bool PlayerTeleportationActivated { get; set; }   // true for teleport, false for free movement
```

### Interaction Settings
```csharp
// Configurable in CameraPointerManager.cs
private float maxDistancePointer = 4.5f;    // Maximum interaction distance
private const float _maxDistance = 10;      // Raycast maximum distance
```

## 🔧 Development

### Building for Android

1. **Prepare Build**
   ```bash
   # Ensure all scenes are added to build settings
   # Verify XR settings are properly configured
   ```

2. **Build APK**
   - File → Build Settings → Build
   - Choose output directory
   - Wait for build completion

3. **Install & Test**
   ```bash
   adb install CalabozoVR.apk
   adb logcat -s Unity  # For debugging
   ```

### Testing in Editor

1. **Enable Cardboard Simulator**
   - The project includes CardboardSimulator for editor testing
   - Use mouse to simulate head movement
   - Hold Alt + mouse to simulate device tilt

2. **Debug Controls**
   - Mouse movement: Head rotation
   - WASD: Position movement (debug only)
   - Space: Trigger simulation

### Performance Optimization

- **Target 60 FPS** on mid-range Android devices
- **Occlusion Culling**: Enabled for all scenes
- **Texture Compression**: ASTC format for Android
- **Audio Compression**: Compressed audio files
- **LOD Groups**: Implemented for complex models

## 🐛 Troubleshooting

### Common Issues

**Issue**: Game doesn't start in VR mode
```
Solution: Verify Google Cardboard XR is enabled in XR Management settings
```

**Issue**: Poor performance/low FPS
```
Solution: 
1. Lower graphics quality in Player Settings
2. Reduce texture quality
3. Disable unnecessary visual effects
```

**Issue**: Interactions not working
```
Solution: 
1. Check that objects have correct tags ("Interactable", "Telepor")
2. Verify colliders are properly configured
3. Ensure camera raycast is not blocked
```

**Issue**: Movement not responding
```
Solution:
1. Check device sensors are working
2. Calibrate device orientation
3. Verify movement mode settings
```

## 📊 Performance Metrics

### Target Performance
- **FPS**: 60 FPS sustained
- **Frame Time**: <16.67ms
- **Memory**: <1.5GB RAM usage
- **Battery**: 45+ minutes gameplay

### Optimization Features
- Dynamic batching enabled
- Frustum culling active
- Compressed textures (ASTC)
- Optimized shader usage
- Efficient object pooling

## 🤝 Contributing

1. **Fork the Repository**
2. **Create Feature Branch**
   ```bash
   git checkout -b feature/new-feature
   ```
3. **Make Changes**
4. **Test Thoroughly**
   - Test in Unity editor
   - Test on actual Android device
   - Verify VR functionality
5. **Submit Pull Request**

### Code Style Guidelines
- Use PascalCase for public methods and properties
- Use camelCase for private fields
- Include XML documentation for public APIs
- Follow Unity's coding conventions
- Keep Update() methods optimized

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 🙏 Acknowledgments

- **Google Cardboard Team** for the excellent XR plugin
- **Unity Technologies** for the development platform
- **TextMeshPro** for enhanced text rendering
- **Community Contributors** for testing and feedback

## 📞 Support

For technical support or questions:
- **Issues**: Create an issue on GitHub
- **Documentation**: Check the [Documentation](Documentation/) folder
- **Email**: support@yourcompany.com

## 🗺️ Roadmap

### Version 1.1 (Planned)
- [ ] Multiple escape rooms
- [ ] Multiplayer support
- [ ] Improved graphics
- [ ] Custom level editor

### Version 1.2 (Future)
- [ ] Hand tracking support
- [ ] Voice interactions
- [ ] Procedural room generation
- [ ] Achievement system

---

**Made with ❤️ for the VR community**