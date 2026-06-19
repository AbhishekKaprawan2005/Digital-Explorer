# Digital Explorer - Unity Project

## Setup Instructions

1. Clone or download the repository.
2. Open Unity Hub.
3. Click **Open Project** and select the project folder.
4. Wait for Unity to import all assets and packages.
5. Open the main scene from the `Assets/Scenes` folder.
6. Press **Play** to run the project in the Unity Editor.

---

## Unity Version

**Unity 6000.3.9f1 LTS**

Recommended version:

* Unity 6000.3.9f1 LTS
* Android Build Support Module (for APK builds)

---

## Controls

 
### Mobile Controls

* **Left Joystick** – Movement
* **Right Side Touch** – Camera Look
* **UI Buttons** – Interact with Game Elements

---

## Build Instructions

### Android APK

1. Open **File → Build Settings**.
2. Select **Android** platform.
3. Click **Switch Platform**.
4. Configure Player Settings if required.
5. Click **Build**.
6. Choose an output location and generate the APK.

 
## Architecture Overview

### Core Systems

#### Player Controller

* CharacterController-based movement system.
* Supports joystick movement and camera control.
* Handles gravity and terrain interaction.

#### Camera System

* Third-person/first-person camera controller.
* Mobile touch-based camera rotation.

#### Globe System

* Procedurally loaded Earth globe.
* Countries generated at runtime from serialized mesh data.
* LOD (Level of Detail) support for performance optimization.

#### Mesh Loading System

* `MeshLoader` loads Earth mesh data from serialized files.
* `LodMeshLoader` manages high-resolution and low-resolution country meshes.
* Runtime mesh generation and collider assignment.

#### UI System

* Mobile joystick controls.
* Interactive UI elements and buttons.
* Animation-driven feedback.

#### Build Targets

* Android APK
 

---

## Project Structure

Assets/
├── Scripts/
├── Scenes/
├── Materials/
├── Prefabs/
├── UI/
├── Textures/
└── Resources/

---

## Features

* Realistic Earth Globe
* Runtime Country Loading
* Mobile Controls
* LOD Optimization
* Android & WebGL Support
* CharacterController-based Navigation
