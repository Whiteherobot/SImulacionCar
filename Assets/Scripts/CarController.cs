using UnityEngine;

public class CarController : MonoBehaviour
{
    [Header("Ruta")]
    public Transform[] waypoints;

    [Header("Velocidad")]
    public float speed = 5f;

    [Header("Detección de autos")]
    public float detectionDistance = 5f;
    public LayerMask carLayer;

    [Header("ID de Carril (A o B)")]
    public string laneID = "A"; // O "B"

    [Header("Referencias")]
    public TrafficCamera myTrafficCamera;  // <--- Asigna en el Inspector

    private int currentWaypoint = 0;
    private bool isStopped = false;

    void Update()
    {
        if (waypoints == null || waypoints.Length == 0) return;
        if (currentWaypoint >= waypoints.Length) return;

        // 🔍 Detección de carro al frente
        CheckForCarInFront();

        // 🚦 Señal de semáforo
        bool redLight = !CanMoveBySignal();

        if (isStopped || redLight) return;

        MoveToWaypoint();
    }

    void MoveToWaypoint()
    {
        Transform target = waypoints[currentWaypoint];
        Vector3 dir = target.position - transform.position;

        transform.position += dir.normalized * speed * Time.deltaTime;
        transform.LookAt(target);

        if (dir.magnitude < 0.5f)
        {
            if (currentWaypoint < waypoints.Length - 1)
            {
                currentWaypoint++;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    void CheckForCarInFront()
    {
        Vector3 sphereOrigin = transform.position + transform.forward * detectionDistance * 0.5f + Vector3.up * 0.5f;
        float sphereRadius = 1.5f;

        Collider[] hits = Physics.OverlapSphere(sphereOrigin, sphereRadius, carLayer);

        if (hits.Length > 0)
        {
            isStopped = true;
            Debug.DrawLine(transform.position, sphereOrigin, Color.red);
        }
        else
        {
            isStopped = false;
            Debug.DrawLine(transform.position, sphereOrigin, Color.green);
        }
    }

    bool CanMoveBySignal()
{
    int signal = TrafficCamera.signalValue;

    if (signal == 12) return false; // Ambos amarillos
    if (laneID == "A" && signal == 23) return false; // B tiene verde
    if (laneID == "B" && signal == 13) return false; // A tiene verde

    return true; // Pasa si es verde para este carril
}
}