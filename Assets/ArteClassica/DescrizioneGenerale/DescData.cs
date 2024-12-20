using UnityEngine;
using TMPro;
using System.Collections;

public class DescrizioneData : MonoBehaviour
{
    public TextMeshProUGUI Data; 
    public float durataTransizione = 0.5f;  // Durata della transizione

    // Metodo da chiamare quando viene premuto un bottone
    public void CambiaDescrizioneData(string nuovoTesto)
    {
        StartCoroutine(TransizioneDescrizione(nuovoTesto));
    }

    // Coroutine per fare il fade del testo
    private IEnumerator TransizioneDescrizione(string nuovoTesto)
    {
        // Fai scomparire il testo
        float tempoTrascorso = 0f;
        Color coloreOriginale = Data.color;

        while (tempoTrascorso < durataTransizione)
        {
            tempoTrascorso += Time.deltaTime;
            Data.color = Color.Lerp(coloreOriginale, new Color(coloreOriginale.r, coloreOriginale.g, coloreOriginale.b, 0), tempoTrascorso / durataTransizione);  // Fading in uscita
            yield return null;
        }

        // Cambia il testo
       Data.text = nuovoTesto ; 

        // Fai riapparire il testo
        tempoTrascorso = 0f;
        while (tempoTrascorso < durataTransizione)
        {
            tempoTrascorso += Time.deltaTime;
            Data.color = Color.Lerp(new Color(coloreOriginale.r, coloreOriginale.g, coloreOriginale.b, 0), coloreOriginale, tempoTrascorso / durataTransizione);  // Fading in entrata
            yield return null;
        }
    }
}