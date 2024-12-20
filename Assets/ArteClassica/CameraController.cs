using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform[] cameraTargets; // Array di posizioni target (uno per ogni opera e per entrata/uscita)
    public float moveSpeed = 2f;      // Velocità di spostamento
    public float rotateSpeed = 2f;    // Velocità di rotazione

    private Transform currentTarget;  // Target corrente della telecamera
    private bool isMoving = false;    // Indica se la telecamera è in movimento

    void Update()
    {
        if (isMoving && currentTarget != null)
        {
            // Movimento fluido verso il target
            transform.position = Vector3.Lerp(transform.position, currentTarget.position, Time.deltaTime * moveSpeed);

            // Rotazione fluida verso il target
            Quaternion targetRotation = Quaternion.LookRotation(currentTarget.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotateSpeed);

            // Controlla se la telecamera ha raggiunto il target
            if (Vector3.Distance(transform.position, currentTarget.position) < 0.1f &&
                Quaternion.Angle(transform.rotation, targetRotation) < 1f)
            {
                isMoving = false;
            }
        }
    }

    public void MoveToTarget(int targetIndex)
    {
        if (targetIndex >= 0 && targetIndex < cameraTargets.Length)
        {
            currentTarget = cameraTargets[targetIndex];
            isMoving = true;
        }
    }
}
