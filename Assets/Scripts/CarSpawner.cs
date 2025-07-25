using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    [Header("Carpeta de Prefabs (Resources)")]
    public string prefabFolder = "Prefabs/Cars"; // Por ejemplo: Assets/Resources/Prefabs/Cars/

    [Header("Punto de Spawn")]
    public Transform spawnPoint;

    [Header("Waypoints")]
    public Transform[] waypoints;

    [Header("Config")]
    public float spawnInterval = 5f;

    [Header("Semáforo & Carril")]
    public string laneID = "A";                // 👈 A o B, define la fila de este Spawner
    public TrafficCamera myTrafficCamera;      // 👈 Cámara de este carril

    private float timer = 0f;
    private GameObject[] carPrefabs;

    void Start()
    {
        // 🔄 Carga todos los prefabs de la carpeta
        carPrefabs = Resources.LoadAll<GameObject>(prefabFolder);

        if (carPrefabs.Length == 0)
        {
            Debug.LogWarning("⚠ No se encontraron prefabs en Resources/" + prefabFolder);
        }
        else
        {
            Debug.Log("✅ Prefabs cargados: " + carPrefabs.Length);
        }
    }

    void Update()
    {
        if (carPrefabs.Length == 0) return;

        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            timer = 0f;
            SpawnRandomCar();
        }
    }

    void SpawnRandomCar()
    {
        int index = Random.Range(0, carPrefabs.Length);
        GameObject prefab = carPrefabs[index];

        if (prefab == null)
        {
            Debug.LogWarning("⚠ Prefab vacío en índice: " + index);
            return;
        }

        if (spawnPoint == null)
        {
            Debug.LogError("❌ No se asignó SpawnPoint.");
            return;
        }

        GameObject newCar = Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);

        CarController carController = newCar.GetComponent<CarController>();
        if (carController != null)
        {
            carController.waypoints = waypoints;
            carController.laneID = laneID;                // ✅ Asigna A o B dinámico
            carController.myTrafficCamera = myTrafficCamera; // ✅ Conecta la cámara de este carril
        }
        else
        {
            Debug.LogError("❌ El prefab " + prefab.name + " NO tiene CarController.");
        }
    }
}