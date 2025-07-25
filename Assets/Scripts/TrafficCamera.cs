using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class TrafficCamera : MonoBehaviour
{
    public static int signalValue = 1; // Empieza en ROJO
    public string backendURL = "http://192.168.38.190:5000/api/send1"; // O send2 para la otra cámara
    public Camera trafficCam;

    private RenderTexture renderTexture;

    void Start()
    {
        if (trafficCam == null)
        {
            Debug.LogError("❌ TrafficCam no está asignada en el Inspector.");
            return;
        }

        // 👉 Crear RenderTexture dinámico y asignar
        renderTexture = new RenderTexture(256, 256, 24);
        trafficCam.targetTexture = renderTexture;

        // Iniciar ciclo de captura/envío
        InvokeRepeating(nameof(SendImageToBackend), 1f, 3f);
    }

    void SendImageToBackend()
    {
        StartCoroutine(CaptureAndSend());
    }

    IEnumerator CaptureAndSend()
    {
        yield return new WaitForEndOfFrame();

        // Capturar la imagen de la cámara a la RenderTexture
        RenderTexture.active = renderTexture;

        Texture2D screenshot = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.RGB24, false);
        trafficCam.Render();
        screenshot.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
        screenshot.Apply();

        RenderTexture.active = null;

        // Codificar a JPG
        byte[] bytes = screenshot.EncodeToJPG();
        Destroy(screenshot);

        // Preparar envío
        WWWForm form = new WWWForm();
        form.AddBinaryData("image", bytes, "screenshot.jpg", "image/jpeg");

        UnityWebRequest www = UnityWebRequest.Post(backendURL, form);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("❌ Error al enviar imagen: " + www.error);
        }
        else
        {
            Debug.Log("✅ Imagen enviada: " + backendURL);

            // Leer signalValue del backend después de enviar imagen
            UnityWebRequest getSignal = UnityWebRequest.Get("http://192.168.38.190:5000/api/");
            yield return getSignal.SendWebRequest();

            if (getSignal.result == UnityWebRequest.Result.Success)
            {
                string[] lines = getSignal.downloadHandler.text.Split('\n');
                if (lines.Length > 0 && int.TryParse(lines[0], out int result))
                {
                    signalValue = result;
                    Debug.Log("🚦 Señal recibida: " + signalValue);
                }
            }
            else
            {
                Debug.LogError("❌ Error al leer señal: " + getSignal.error);
            }
        }
    }
}