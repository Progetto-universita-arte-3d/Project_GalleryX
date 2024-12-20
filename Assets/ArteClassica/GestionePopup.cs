using UnityEngine;

public class GestionePopup : MonoBehaviour
{
    [SerializeField] private GameObject[] buttonGroups; // Array di GameObject che contengono i bottoni

    private void Start()
    {
        // Assicurati che tutti i gruppi siano nascosti all'avvio
        HideAllButtons();
    }

    public void ShowWorldButtons(int index)
    {
        // Nascondi tutti i gruppi di bottoni
        HideAllButtons();

        // Attiva solo il gruppo selezionato
        if (index >= 0 && index < buttonGroups.Length)
        {
            buttonGroups[index].SetActive(true);
        }
    }

    private void HideAllButtons()
    {
        // Disattiva tutti i gruppi di bottoni
        foreach (GameObject group in buttonGroups)
        {
            if (group != null)
            {
                group.SetActive(false);
            }
        }
    }
}
