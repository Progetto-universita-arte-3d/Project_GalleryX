using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PannelloTrascinabile : MonoBehaviour, IDragHandler
{
    [SerializeField] private RectTransform trascinaPopup;
    [SerializeField] private Canvas canvas;

    // Offset personalizzato per il limite sinistro
    [SerializeField] private float offsetLimiteSinistra = 100f;

    public void OnDrag(PointerEventData eventData)
    {
        // Calcola la nuova posizione proposta
        Vector2 nuovaPosizione = trascinaPopup.anchoredPosition + eventData.delta / canvas.scaleFactor;

        // Ottieni i limiti del canvas
        RectTransform canvasRect = canvas.GetComponent<RectTransform>();

        // Calcola le dimensioni del pannello
        Vector2 pannelloSize = trascinaPopup.rect.size;

        // Calcola i limiti basati sul pivot del pannello con l'offset per il limite sinistro
        float leftLimit = -canvasRect.rect.width / 2 + pannelloSize.x / 2 + offsetLimiteSinistra;
        float rightLimit = canvasRect.rect.width / 2 - pannelloSize.x / 2;
        float bottomLimit = -canvasRect.rect.height / 2 + pannelloSize.y / 2;
        float topLimit = canvasRect.rect.height / 2 - pannelloSize.y / 2;

        // Applica i limiti alla nuova posizione
        nuovaPosizione.x = Mathf.Clamp(nuovaPosizione.x, leftLimit, rightLimit);
        nuovaPosizione.y = Mathf.Clamp(nuovaPosizione.y, bottomLimit, topLimit);

        // Imposta la posizione limitata
        trascinaPopup.anchoredPosition = nuovaPosizione;
    }
}
