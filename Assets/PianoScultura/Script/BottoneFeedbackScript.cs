using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class BottoneFeedbackScript : MonoBehaviour
{
    [SerializeField] private Button BottoneFeedback; // Bottone iniziale
    [SerializeField] private GameObject FormFeedback;     // Schermata per lasciare i feedback
    [SerializeField] private Sprite IconaX  ;
    [SerializeField] private Sprite IconaFeedback ; 
    private int counter = 0 ; 

    public void AperturaFeedback(){
        counter++;
        Debug.Log(counter) ;
        if (counter % 2 !=0){
        BottoneFeedback.image.sprite = IconaX ; //cambia l'icona trasformandola in x
        FormFeedback.SetActive(true) ;  //faccio comparire la schermata del form 
        }
        else{
            BottoneFeedback.image.sprite = IconaFeedback ;//cambia l'icona a quella del feedback
            FormFeedback.SetActive(false) ;  //faccio sparire la schermata del form 
        }
    }
    
}
