using UnityEngine;

public class ButtonZoom : MonoBehaviour
{
    public Camera mainCamera;                // La telecamera principale
    public float zoomAmount = 2f;            // La distanza di zoom relativa al bottone
    public float zoomSpeed = 5f;             // Velocità di zoom

    private Vector3 savedPosition;           // Posizione salvata quando si preme Z
    private Quaternion savedRotation;        // Rotazione salvata quando si preme Z
    private bool canZoom = false;            // Controlla se è possibile zoomare
    private Vector3 targetPosition;          // Posizione di destinazione per lo zoom

    void Update()
    {
        // Se si preme Z e si può zoomare, salva la posizione e la rotazione attuali della telecamera
        if (Input.GetKeyDown(KeyCode.Z) && canZoom)
        {
            savedPosition = mainCamera.transform.position;
            savedRotation = mainCamera.transform.rotation;
        }

        // Se si tiene premuto Z, esegui lo zoom verso la posizione target
        if (Input.GetKey(KeyCode.Z) && canZoom)
        {
            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, targetPosition, Time.deltaTime * zoomSpeed);
        }

        // Se si rilascia Z, ripristina immediatamente la posizione salvata
        if (Input.GetKeyUp(KeyCode.Z) && canZoom)
        {
            ResetCameraPosition();
        }
    }

    // Funzione chiamata quando viene premuto un bottone
    public void OnButtonClicked(Transform buttonTransform)
    {
        // Calcola una nuova posizione spostando la telecamera verso il bottone
        Vector3 directionToButton = (buttonTransform.position - mainCamera.transform.position).normalized;
        targetPosition = mainCamera.transform.position + directionToButton * zoomAmount;

        canZoom = true;
    }

    // Funzione per resettare immediatamente la posizione della telecamera
    void ResetCameraPosition()
    {
        mainCamera.transform.position = savedPosition;
        mainCamera.transform.rotation = savedRotation;
    }
}
