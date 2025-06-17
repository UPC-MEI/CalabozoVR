# Changelog - CalabozoVR

All notable changes to the CalabozoVR project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

### Added
- Documentation structure with comprehensive guides
- README.md with project overview and setup instructions
- Architecture documentation with system design details
- Developer guide with environment setup and best practices
- Complete API documentation with usage examples

### Changed
- Organized project structure following Unity best practices

### Fixed
- Initial documentation setup

## [1.0.0] - 2024-XX-XX

### Added
- Initial release of CalabozoVR escape room game
- VR support using Google Cardboard XR Plugin
- Gaze-based interaction system
- Dual movement modes (free walking and teleportation)
- Object discovery gameplay mechanics
- Menu system with configurable settings
- 3D spatial audio support
- Performance optimization for mobile VR

### Core Features
- **VR Interaction System**: Complete gaze-based pointing and selection
- **Player Movement**: Head-tilt walking and teleportation modes
- **Game Logic**: Three-object discovery with puzzle solving
- **UI System**: VR-adapted menus and feedback
- **Settings**: Configurable speed and movement options

### Technical Implementation
- **Architecture**: Singleton pattern for core managers
- **Performance**: 60 FPS target with mobile optimization
- **Compatibility**: Android 7.0+ with Google Cardboard support
- **Build System**: Unity 2022.3 LTS with optimized settings

### Known Issues
- Performance may be reduced on devices with less than 3GB RAM
- Some older Android devices may experience compatibility issues

---

## Version History Guidelines

### Version Number Format
- **MAJOR.MINOR.PATCH** (e.g., 1.0.0)
- **MAJOR**: Breaking changes or significant new features
- **MINOR**: New features that are backward compatible
- **PATCH**: Bug fixes and small improvements

### Change Categories
- **Added**: New features
- **Changed**: Changes in existing functionality
- **Deprecated**: Soon-to-be removed features
- **Removed**: Now removed features
- **Fixed**: Bug fixes
- **Security**: Security improvements

### How to Update This Changelog
1. Add new entries under [Unreleased] section
2. When releasing, move unreleased changes to a new version section
3. Include date in YYYY-MM-DD format
4. Link to GitHub releases or relevant documentation
5. Keep the most recent versions at the top