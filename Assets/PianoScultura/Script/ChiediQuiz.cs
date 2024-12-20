using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChiediQuiz : MonoBehaviour
{
   [SerializeField] private  GameObject SchermataQuiz;

   [SerializeField] private GameObject BottoneFeedback; 

   public void ApriShermataScelta(){
    SchermataQuiz.SetActive(true) ; 
    BottoneFeedback.SetActive(false); 

   }

   
}
