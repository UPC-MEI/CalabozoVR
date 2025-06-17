# Contributing to CalabozoVR

We welcome contributions to the CalabozoVR project! This document provides guidelines for contributing to the codebase, documentation, and overall project improvement.

## 🚀 Getting Started

### Prerequisites
1. Read the [README.md](README.md) for project overview
2. Follow the [Developer Guide](Documentation/Developer/DeveloperGuide.md) for environment setup
3. Review the [Architecture Documentation](Documentation/Technical/Architecture.md)
4. Familiarize yourself with [API Documentation](Documentation/API/APIDocumentation.md)

### Development Environment
- **Unity**: 2022.3 LTS or newer
- **IDE**: Visual Studio 2022 or Visual Studio Code
- **Platform**: Android development setup
- **VR**: Google Cardboard compatible device for testing

## 📋 How to Contribute

### 1. Reporting Issues
Before creating an issue, please:
- Check existing issues to avoid duplicates
- Use the issue template if available
- Provide clear reproduction steps
- Include Unity version, device information, and logs

#### Bug Report Template
```markdown
**Bug Description**
A clear description of the bug.

**Steps to Reproduce**
1. Go to '...'
2. Click on '...'
3. See error

**Expected Behavior**
What should happen.

**Actual Behavior**
What actually happens.

**Environment**
- Unity Version: [e.g., 2022.3.0f1]
- Device: [e.g., Samsung Galaxy S21]
- Android Version: [e.g., 12]
- CalabozoVR Version: [e.g., 1.0.0]

**Additional Context**
Screenshots, logs, or other relevant information.
```

### 2. Feature Requests
When suggesting new features:
- Explain the use case and benefits
- Consider VR-specific implications
- Discuss potential implementation approaches
- Ensure compatibility with existing architecture

### 3. Code Contributions

#### Workflow
1. **Fork** the repository
2. **Create** a feature branch: `git checkout -b feature/amazing-feature`
3. **Make** your changes following coding standards
4. **Test** thoroughly on actual VR devices
5. **Commit** with descriptive messages
6. **Push** to your fork: `git push origin feature/amazing-feature`
7. **Submit** a Pull Request

#### Branch Naming Conventions
- `feature/description` - New features
- `bugfix/description` - Bug fixes
- `hotfix/description` - Critical fixes
- `docs/description` - Documentation updates
- `refactor/description` - Code refactoring

#### Commit Message Format
```
type(scope): short description

Longer description if needed.

- Bullet points for key changes
- Reference issues: Fixes #123
```

**Types:**
- `feat`: New feature
- `fix`: Bug fix
- `docs`: Documentation
- `style`: Code formatting
- `refactor`: Code restructuring
- `test`: Adding tests
- `perf`: Performance improvements

**Example:**
```
feat(movement): add comfort settings for VR locomotion

Add vignetting and snap turning options to reduce motion sickness.
Configurable through GameSettings with UI controls.

- Add VRComfortSettings class
- Implement vignette shader
- Add snap turning with 30° increments
- Update UI with comfort options

Fixes #45
```

## 🎨 Coding Standards

### C# Style Guidelines
```csharp
// Classes: PascalCase
public class VRInteractionManager : MonoBehaviour

// Methods: PascalCase
public void OnPointerClickXR()

// Private fields: camelCase with underscore
private GameObject _currentTarget;

// Properties: PascalCase
public static float PlayerSpeed { get; set; }

// Constants: ALL_CAPS
private const float MAX_INTERACTION_DISTANCE = 10f;

// Events: PascalCase with "On" prefix
public UnityEvent OnInteractionStarted;
```

### File Organization
```csharp
// File header with purpose
using System;
using UnityEngine;
using UnityEngine.Events;

namespace CalabozoVR.Interaction
{
    /// <summary>
    /// Manages VR-specific interaction behaviors.
    /// Handles gaze detection and object selection.
    /// </summary>
    public class VRInteractionManager : MonoBehaviour
    {
        #region Serialized Fields
        [Header("Interaction Settings")]
        [SerializeField] private float interactionDistance = 5f;
        #endregion

        #region Private Fields  
        private Camera _vrCamera;
        private GameObject _currentTarget;
        #endregion

        #region Properties
        public bool IsInteracting { get; private set; }
        #endregion

        #region Unity Lifecycle
        void Start()
        {
            InitializeComponents();
        }

        void Update()
        {
            ProcessInteractions();
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Begins interaction with the specified target.
        /// </summary>
        /// <param name="target">The GameObject to interact with</param>
        public void StartInteraction(GameObject target)
        {
            // Implementation
        }
        #endregion

        #region Private Methods
        private void InitializeComponents()
        {
            // Implementation
        }
        #endregion
    }
}
```

### VR-Specific Guidelines
1. **Performance**: Always target 60 FPS
2. **Comfort**: Avoid rapid camera movements
3. **Accessibility**: Provide multiple interaction methods
4. **Testing**: Test on actual VR devices, not just simulator
5. **Optimization**: Use object pooling for frequent instantiation

### Unity Best Practices
- Use `[SerializeField]` instead of public fields
- Implement proper component lifecycle
- Cache component references in Start()
- Use object pooling for performance-critical objects
- Follow Unity's naming conventions for assets

## 🧪 Testing Requirements

### Before Submitting
- [ ] Code compiles without warnings
- [ ] Tested in Unity Editor with Cardboard Simulator
- [ ] Tested on actual Android device with Google Cardboard
- [ ] Performance maintains 60 FPS target
- [ ] No VR comfort issues (motion sickness potential)
- [ ] All existing tests pass
- [ ] New functionality includes appropriate tests

### Testing Checklist for VR Features
- [ ] Gaze interaction works correctly
- [ ] Teleportation functions properly
- [ ] No stuttering or frame drops
- [ ] UI elements are readable in VR
- [ ] Audio positioning is accurate
- [ ] No comfort issues during extended use

## 📚 Documentation Requirements

### Code Documentation
- Public APIs must have XML documentation
- Complex algorithms should have inline comments
- VR-specific considerations should be documented
- Performance implications should be noted

### Update Documentation When
- Adding new public APIs
- Changing existing behavior
- Adding new VR features
- Modifying build process
- Changing system requirements

## 🎯 Pull Request Guidelines

### PR Description Template
```markdown
## Description
Brief description of changes and motivation.

## Type of Change
- [ ] Bug fix (non-breaking change that fixes an issue)
- [ ] New feature (non-breaking change that adds functionality)
- [ ] Breaking change (fix or feature that changes existing functionality)
- [ ] Documentation update

## Testing
- [ ] Tested in Unity Editor
- [ ] Tested on Android device
- [ ] Performance tested (60 FPS maintained)
- [ ] VR comfort verified

## Checklist
- [ ] Code follows project style guidelines
- [ ] Self-review completed
- [ ] Documentation updated
- [ ] Tests added/updated
- [ ] No merge conflicts

## Screenshots (if applicable)
Add screenshots or GIFs demonstrating the changes.

## Related Issues
Fixes #(issue number)
```

### Review Process
1. **Automated Checks**: All CI/CD checks must pass
2. **Code Review**: At least one team member review required
3. **VR Testing**: Changes affecting VR must be tested on device
4. **Documentation**: Relevant docs must be updated
5. **Performance**: No significant performance regression

## 🚨 Security Guidelines

### Sensitive Information
- Never commit API keys, passwords, or tokens
- Use environment variables for sensitive configuration
- Be cautious with user data handling
- Follow Android security best practices

### Code Security
- Validate all inputs
- Use secure communication protocols
- Implement proper error handling
- Avoid hardcoded secrets

## 🏆 Recognition

Contributors will be:
- Added to the Contributors section in README.md
- Credited in release notes for significant contributions
- Mentioned in project documentation where appropriate

## 📞 Getting Help

If you need help:
1. Check existing documentation
2. Search through existing issues
3. Ask questions in discussions
4. Contact maintainers directly

### Contact
- **Project Lead**: [Your Name] - [email]
- **Technical Lead**: [Name] - [email]
- **Documentation**: [Name] - [email]

## 📄 License

By contributing to CalabozoVR, you agree that your contributions will be licensed under the same license as the project (MIT License).

---

Thank you for contributing to CalabozoVR! Your efforts help make VR development more accessible and enjoyable for everyone. 🥽✨