using UnityEngine;
using UnityEngine.UI;

public class RotazioneOpere : MonoBehaviour
{
    public Transform sculpture; // La scultura da esaminare
    public Button rotateButton; // Bottone nel Canvas Screen Space
    public float rotationSpeed = 50f; // Velocità di rotazione
    public Transform[] popups; // Popup numerati vicini alla scultura

    private bool isRotating = false;

    void Start()
    {
        // Assicurati che il bottone abbia una funzione associata
        if (rotateButton != null)
        {
            rotateButton.onClick.AddListener(ToggleRotation);
        }
        else
        {
            Debug.LogError("Il bottone di rotazione non è assegnato.");
        }
    }

    void Update()
    {
        // Controlla se la rotazione è attivata
        if (isRotating && sculpture != null)
        {
            float horizontalInput = Input.GetAxis("Horizontal"); // Input da tasti freccia o A/D
            float rotationAmount = -horizontalInput * rotationSpeed * Time.deltaTime;

            // Ruota la scultura
            sculpture.Rotate(Vector3.up * rotationAmount, Space.World);

            // Ruota i popup per mantenere la posizione
            foreach (Transform popup in popups)
            {
                popup.RotateAround(sculpture.position, Vector3.up, rotationAmount);
            }
        }
    }

    // Attiva o disattiva la rotazione
    void ToggleRotation()
    {
        isRotating = !isRotating;
    }
}
