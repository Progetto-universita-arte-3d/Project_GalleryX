using UnityEngine;

public class AttivaDisattivaPopup : MonoBehaviour
{
    public GameObject[] popupButtons;  // Array dei bottoni nel Canvas World Space
    public GameObject[] menuButtons;   // Array dei bottoni nel Canvas Screen Space Overlay
    private bool canToggle = false;     // Flag che indica se possiamo togglare i popup


    void Update()
    {
        // Controlla se alcuni bottoni del menu sono stati premuti
        if (AreMenuButtonsPressed())
        {
            canToggle = true;
        }

        // Se il flag è attivo, toggla i bottoni popup quando premi H
        if (canToggle && Input.GetKeyDown(KeyCode.H))
        {
            TogglePopupButtonsVisibility();
        }
    }

    // Controlla se i bottoni del menu sono stati premuti (ad esempio, se sono abilitati)
    bool AreMenuButtonsPressed()
    {
        foreach (GameObject button in menuButtons)
        {
            // Puoi sostituire questo controllo con una logica diversa (es. verificare se i bottoni sono attivi)
            if (button.activeSelf)
            {
                return true; // Se almeno un bottone è attivo, permetti il toggle dei popup
            }
        }
        return false; // Nessun bottone premuto
    }

    // Funzione per togglare la visibilità dei bottoni popup
    void TogglePopupButtonsVisibility()
    {
        foreach (GameObject button in popupButtons)
        {
            button.SetActive(!button.activeSelf);  // Cambia lo stato di visibilità
        }
    }
}
