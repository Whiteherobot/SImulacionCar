# Simulación de Tráfico en Unity 🚦

## Descripción

Este proyecto es una simulación de tráfico desarrollada en Unity, orientada a la experimentación con cámaras de tráfico, señales automáticas y comunicación con un backend para el procesamiento de imágenes y control de semáforos. El objetivo es crear un entorno virtual que permita probar algoritmos de visión computacional y lógica de control de tráfico en tiempo real.

## Características principales

- **Captura de imágenes desde cámaras virtuales** usando scripts personalizados.
- **Comunicación con backend** vía HTTP para el envío de imágenes y recepción de señales de control.
- **Control dinámico de semáforos** basado en la respuesta del backend.
- **Estructura modular** para facilitar la integración de nuevos modelos, materiales y sistemas de IA.
- **Uso de prefabs y assets personalizados** para escenarios urbanos.
- **Automatización de ciclos de captura y envío** mediante corutinas en Unity.
- **Gestión profesional de versiones** usando Git y un `.gitignore` adaptado a proyectos Unity.

## Estructura del proyecto

```
Assets/
  ├── Scripts/                # Lógica principal (cámaras, control de tráfico, etc.)
  ├── Prefabs/                # Prefabs de vehículos, semáforos, etc.
  ├── Materials/              # Materiales y texturas
  ├── Models/                 # Modelos 3D
  ├── Fantasy Skybox FREE/    # Skybox para ambientación
  ├── ModularLowpolyStreetsFree/ # Calles y escenarios urbanos
  └── TutorialInfo/           # Documentación y scripts de ejemplo
Packages/
  └── manifest.json           # Dependencias del proyecto
.vscode/                      # Configuración para Visual Studio Code
.gitignore                    # Exclusión de archivos innecesarios
```

## Instalación y uso

1. **Clona el repositorio:**
   ```bash
   git clone https://github.com/Whiteherobot/SImulacionCar.git
   ```
2. **Abre la carpeta en Unity Hub** y selecciona la versión recomendada.
3. **Configura el backend** (ver sección Backend) si deseas probar la comunicación en tiempo real.
4. **Ejecuta la escena principal** y observa el comportamiento de las cámaras y semáforos.

## Backend

El proyecto está preparado para comunicarse con un backend en Python (Flask) que recibe imágenes y responde con el estado de la señal.  
La URL del backend se puede configurar en el script `TrafficCamera.cs`.

## Buenas prácticas aplicadas

- Uso de `.gitignore` específico para Unity, evitando archivos temporales y assets de terceros innecesarios.
- Separación de lógica en scripts y uso de prefabs para facilitar la reutilización.
- Documentación en los scripts clave y mensajes de error claros para facilitar el mantenimiento.
- Estructura de carpetas profesional y limpia.
- Control de versiones desde el inicio del proyecto.

## Créditos

- [Unity Asset Store](https://assetstore.unity.com/) por los assets gratuitos utilizados.
- Desarrollo y documentación: **[Tu Nombre o Equipo]**

## Licencia

Este proyecto es de uso académico y experimental. Consulta el archivo LICENSE para más detalles.

