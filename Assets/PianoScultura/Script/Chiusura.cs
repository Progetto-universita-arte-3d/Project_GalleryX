using UnityEngine;
using UnityEngine.UI;

public class ChangeCloseButtonIcon : MonoBehaviour
{
    // Riferimento al bottone di chiusura
    public Button BottoneChisura;

    // Nuova icona per il bottone di chiusura
    public Sprite IconaFeedback;

    // Metodo per cambiare l'icona del bottone di chiusura
    public void ChangeCloseButtonIconOnSubmit()
    {
        if (BottoneChisura != null && IconaFeedback != null)
        {
            BottoneChisura.image.sprite = IconaFeedback;
        }
        else
        {
            Debug.LogWarning("Assicurati di aver assegnato il bottone di chiusura e l'icona nello script.");
        }
    }
}