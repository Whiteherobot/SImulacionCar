# Traffic Simulation in Unity 🚦

## Description

This project is a traffic simulation developed in Unity, aimed at experimenting with traffic cameras, automatic signals, and backend communication for image processing and traffic light control. The goal is to create a virtual environment to test computer vision algorithms and real-time traffic control logic.

## Main Features

- **Image capture from virtual cameras** using custom scripts.
- **Backend communication** via HTTP for sending images and receiving control signals.
- **Dynamic traffic light control** based on backend responses.
- **Modular structure** to facilitate integration of new models, materials, and AI systems.
- **Use of custom prefabs and assets** for urban scenarios.
- **Automated capture and send cycles** using Unity coroutines.
- **Professional version control** using Git and a Unity-adapted `.gitignore`.

## Project Structure

```
Assets/
  ├── Scripts/                # Main logic (cameras, traffic control, etc.)
  ├── Prefabs/                # Vehicle, traffic light prefabs, etc.
  ├── Materials/              # Materials and textures
  ├── Models/                 # 3D models
  ├── Fantasy Skybox FREE/    # Skybox for environment
  ├── ModularLowpolyStreetsFree/ # Urban streets and scenarios
  └── TutorialInfo/           # Documentation and sample scripts
Packages/
  └── manifest.json           # Project dependencies
.vscode/                      # Visual Studio Code configuration
.gitignore                    # Exclusion of unnecessary files
```

## Installation and Usage

1. **Clone the repository:**
   ```bash
   git clone https://github.com/Whiteherobot/SImulacionCar.git
   ```
2. **Open the folder in Unity Hub** and select the recommended version.
3. **Configure the backend** (see Backend section) if you want to test real-time communication.
4. **Run the main scene** and observe the behavior of the cameras and traffic lights.

## Backend

The project is prepared to communicate with a Python (Flask) backend that receives images and responds with the signal state.  
The backend URL can be configured in the `TrafficCamera.cs` script.

## Applied Best Practices

- Use of a Unity-specific `.gitignore`, avoiding temporary files and unnecessary third-party assets.
- Separation of logic into scripts and use of prefabs for easy reuse.
- Documentation in key scripts and clear error messages for easier maintenance.
- Professional and clean folder structure.
- Version control from the start of the project.

## Credits

- [Unity Asset Store](https://assetstore.unity.com/) for the free assets used.
- Development and documentation: **Michael Lata, Jorge Cueva, Michael Franco, Bryam Mejia**

## License

This project is for academic and experimental use. See the LICENSE