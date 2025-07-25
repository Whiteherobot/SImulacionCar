using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class TrafficSignalController : MonoBehaviour
{
    public static TrafficSignalController Instance;

    public int signalValue = 1; // 1: rojo, 2: amarillo, 3: verde

    public string backendURL = "http://192.168.38.190:5000/api/"; // Ajusta tu IP o dominio

    void Awake()
    {
        if (Instance == null) Instance = this;
    }

    void Start()
    {
        InvokeRepeating(nameof(GetTrafficSignal), 1f, 3f);
    }

    void GetTrafficSignal()
    {
        StartCoroutine(FetchSignal());
    }

    IEnumerator FetchSignal()
    {
        UnityWebRequest www = UnityWebRequest.Get(backendURL);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("❌ Error al leer señal: " + www.error);
        }
        else
        {
            string json = www.downloadHandler.text;
            string[] lines = JsonUtility.FromJson<string[]>(json);

            if (lines.Length > 0)
            {
                int.TryParse(lines[0], out signalValue);
                Debug.Log("✅ Señal recibida: " + signalValue);
            }
        }
    }
}
