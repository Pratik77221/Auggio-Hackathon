# ARChive

<div align="center">

**🏆 3rd Place Winner - Augg.io Hackathon**

An immersive AR historical experience that brings history to life through augmented reality.

</div>

## 📖 About

ARChive is an award-winning augmented reality application developed for the Augg.io Hackathon, where it secured 3rd place. This project leverages cutting-edge AR technology to create an immersive historical experience that simulates a World War II bombing scenario. Users can witness a church under aerial bombardment, complete with realistic explosions, smoke effects, and an interactive guide character to provide historical context.

## ✨ Features

- **Geospatial AR Anchoring**: Precise real-world placement using ARCore Extensions and AR Foundation
- **Dynamic Bombing Simulation**: Realistic aerial bombardment with WWII aircraft (Messerschmitt Bf-109)
- **Interactive Environment**: 
  - Physics-based bomb drops with impact detection
  - Multiple explosion effects with particle systems
  - Persistent smoke effects
  - Dynamic church transformation (intact to destroyed state)
- **AI-Powered Guide**: Interactive NPC using Convai SDK for natural conversations about historical events
- **Realistic Audio**: Immersive sound effects for explosions and ambient audio
- **3D Mapping Integration**: Cesium integration for accurate geospatial visualization

## 🛠️ Technology Stack

### AR Foundation & Support
- **Unity**: 6000.0.38f1
- **AR Foundation**: 6.0.5 - Core AR functionality
- **ARCore**: 6.0.5 - Android AR support
- **ARKit**: 6.0.5 - iOS AR support
- **ARCore Extensions**: arf5 branch - Geospatial anchoring and advanced AR features

### SDKs & Integrations
- **Augg.io SDK**: v0.0.3-b1 - Core AR platform integration
- **Convai SDK**: AI-powered conversational NPCs
- **Cesium for Unity**: 1.16.1 - 3D geospatial mapping

### Rendering & Graphics
- **Universal Render Pipeline (URP)**: 17.0.3
- **Animation Rigging**: 1.3.0
- **Particle Systems**: Custom explosion and smoke effects
- **Visual Effects Graph**: Advanced VFX rendering

### Additional Dependencies
- **Unity Input System**: 1.13.0
- **TextMesh Pro**: Advanced text rendering
- **Burst Compiler**: 1.8.19 - Performance optimization
- **Unity Collections**: 2.5.1

## 🎮 How It Works

1. **AR Session Initialization**: The app uses AR Foundation to initialize the AR session and detect surfaces in the real world
2. **Geospatial Anchoring**: ARCore Extensions enable precise placement of 3D content at specific GPS coordinates
3. **Historical Simulation**: 
   - Aircraft spawn at random intervals and fly across the scene
   - Bombs are dropped with realistic physics
   - Upon collision with the church, explosions trigger with particle effects and sound
   - After 20 hits, the bombing stops and the church transforms from intact to destroyed
4. **Interactive Guide**: A Convai-powered NPC appears to discuss the historical context with users

## 🎯 Key Components

### Scripts
- `Bombing.cs` - Manages aircraft spawning and flight patterns
- `BombManager.cs` - Controls bomb spawning intervals and randomization
- `Bomb.cs` - Handles bomb physics, collision detection, and explosion effects
- `Church.cs` - Manages church state transitions and damage tracking
- Additional AR and UI management scripts

### Prefabs
- Messerschmitt Bf-109 aircraft model
- Bomb with physics components
- Multiple explosion effect variants (A, B, C)
- Thick black smoke particle system
- Church models (intact and destroyed states)

## 📋 Requirements

### Hardware
- Android device with ARCore support OR iOS device with ARKit support
- Device with GPS and gyroscope sensors
- Minimum 2GB RAM recommended

### Software
- Unity 6000.0.38f1 or later
- Android SDK 24+ (for Android builds)
- Xcode 14+ (for iOS builds)
- Git LFS (for large asset files)

## 🚀 Setup & Installation

### Clone the Repository
```bash
git clone https://github.com/Pratik77221/Auggio-Hackathon.git
cd Auggio-Hackathon
```

### Open in Unity
1. Open Unity Hub
2. Click "Add" and select the cloned repository folder
3. Ensure Unity version 6000.0.38f1 is installed
4. Open the project

### Configure AR Settings
1. Navigate to `Assets/XR/Settings`
2. Verify ARCore/ARKit XR Plugin settings are enabled
3. Configure ARCore Extensions settings with your Google Cloud API key (for geospatial features)

### Build & Deploy

#### For Android:
```bash
1. File → Build Settings
2. Select Android platform
3. Switch Platform (if needed)
4. Configure Player Settings:
   - Package Name: com.ARchive.ARChive
   - Minimum API Level: Android 7.0 (API level 24)
5. Build and Run
```

#### For iOS:
```bash
1. File → Build Settings
2. Select iOS platform
3. Switch Platform (if needed)
4. Configure Player Settings:
   - Bundle Identifier: cz.augg.io.example
   - Target Minimum iOS Version: 12.0
5. Build and open in Xcode
6. Configure signing and deploy
```

## 🎬 Usage

1. Launch the app on your AR-capable device
2. Allow camera and location permissions
3. Point your device at a suitable outdoor location
4. Wait for AR initialization and surface detection
5. The church will be anchored at the specified geospatial location
6. Watch the historical bombing simulation unfold
7. After the simulation, interact with the AI guide to learn more

## 📁 Project Structure

```
Assets/
├── Scenes/              # Unity scenes (ARScene, GPS, UI)
├── Scripts/             # C# gameplay scripts
├── Prefabs/             # Reusable game objects
├── augg.io/             # Augg.io SDK integration
├── Convai/              # Convai NPC system
├── XR/                  # AR Foundation settings
├── ExtensionsAssets/    # ARCore Extensions resources
├── Settings/            # URP and rendering settings
└── Resources/           # Runtime loaded assets
```

## 🏆 Achievements

**🥉 3rd Place - Augg.io Hackathon**

This project demonstrated innovative use of the Augg.io SDK combined with advanced AR features, realistic physics simulation, and AI-powered interactions to create an educational and immersive historical experience.

## 🤝 Contributing

While this is a hackathon project, contributions and improvements are welcome:

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## 📄 License

This project is part of the Augg.io Hackathon submission. Please respect the intellectual property and usage rights associated with the included SDKs and assets.

## 👥 Credits

### Development Team
- Developed by Pratik77221

### Technologies & SDKs
- [Augg.io](https://augg.io) - AR platform and SDK
- [Unity Technologies](https://unity.com) - Game engine
- [Google ARCore](https://developers.google.com/ar) - AR foundation for Android
- [Convai](https://convai.com) - AI-powered conversational characters
- [Cesium](https://cesium.com) - 3D geospatial platform

### Assets
- WWII aircraft models and historical references
- Sound effects and audio
- Character models and animations

## 📞 Contact

For questions, feedback, or collaboration opportunities:

- GitHub: [@Pratik77221](https://github.com/Pratik77221)
- Project Link: [https://github.com/Pratik77221/Auggio-Hackathon](https://github.com/Pratik77221/Auggio-Hackathon)

## 🙏 Acknowledgments

- Augg.io team for organizing the hackathon and providing the excellent SDK
- The AR Foundation and ARCore Extensions teams for robust AR capabilities
- Convai for the natural language processing capabilities
- The Unity community for continuous support and resources

---

<div align="center">

**Built with ❤️ for the Augg.io Hackathon**

</div>
