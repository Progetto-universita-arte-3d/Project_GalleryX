using UnityEngine;
using TMPro;
using System.Collections;

public class DescrizioneTecnica : MonoBehaviour
{
    public TextMeshProUGUI Tecnica; 
    public float durataTransizione = 0.5f;  // Durata della transizione

    // Metodo da chiamare quando viene premuto un bottone
    public void CambiaDescrizioneTecnica(string nuovoTesto)
    {
        StartCoroutine(TransizioneDescrizione(nuovoTesto));
    }

    // Coroutine per fare il fade del testo
    private IEnumerator TransizioneDescrizione(string nuovoTesto)
    {
        // Fai scomparire il testo
        float tempoTrascorso = 0f;
        Color coloreOriginale = Tecnica.color;

        while (tempoTrascorso < durataTransizione)
        {
            tempoTrascorso += Time.deltaTime;
            Tecnica.color = Color.Lerp(coloreOriginale, new Color(coloreOriginale.r, coloreOriginale.g, coloreOriginale.b, 0), tempoTrascorso / durataTransizione);  // Fading in uscita
            yield return null;
        }

        // Cambia il testo
        Tecnica.text =nuovoTesto;

        // Fai riapparire il testo
        tempoTrascorso = 0f;
        while (tempoTrascorso < durataTransizione)
        {
            tempoTrascorso += Time.deltaTime;
            Tecnica.color = Color.Lerp(new Color(coloreOriginale.r, coloreOriginale.g, coloreOriginale.b, 0), coloreOriginale, tempoTrascorso / durataTransizione);  // Fading in entrata
            yield return null;
        }
    }
}