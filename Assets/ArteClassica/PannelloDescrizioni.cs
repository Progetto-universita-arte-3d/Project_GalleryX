using UnityEngine;
using TMPro;

public class PannelloDescrizioni : MonoBehaviour
{
    [SerializeField] private GameObject descriptionPanel; // Il pannello nel Canvas Screen Space
    [SerializeField] private TextMeshProUGUI descriptionText; // Il componente TMP per mostrare il testo della descrizione
    [TextArea(5, 10)] // Da 5 a 10 righe visibili
    [SerializeField] private string[] descriptions; // Array di descrizioni, una per bottone
    [SerializeField] private AudioSource audioSource; // Componente AudioSource per riprodurre l'audio
    [SerializeField] private AudioClip[] descriptionAudioClips; // Array di clip audio, uno per ogni descrizione

    private void Start()
    {
        if (descriptionPanel != null)
        {
            descriptionPanel.SetActive(false); // Assicura che il pannello sia disattivato all'inizio
        }

        if (audioSource == null)
        {
            Debug.LogWarning("AudioSource non assegnato. Non verrà riprodotto nessun audio.");
        }
    }

    public void ShowDescription(int index)
    {
        if (descriptionPanel != null)
        {
            descriptionPanel.SetActive(false); // Nascondi eventuale pannello già attivo
        }

        if (descriptionText != null && index >= 0 && index < descriptions.Length)
        {
            descriptionPanel.SetActive(true); // Attiva il pannello
            descriptionText.text = descriptions[index]; // Aggiorna il testo

            // Riproduci il clip audio associato, se esiste
            if (audioSource != null && descriptionAudioClips != null && index < descriptionAudioClips.Length)
            {
                audioSource.clip = descriptionAudioClips[index];
                audioSource.Play();
            }
        }
    }

    public void HideDescription()
    {
        if (descriptionPanel != null)
        {
            descriptionPanel.SetActive(false); // Nascondi il pannello
        }

        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop(); // Ferma l'audio in riproduzione
        }
    }
}
