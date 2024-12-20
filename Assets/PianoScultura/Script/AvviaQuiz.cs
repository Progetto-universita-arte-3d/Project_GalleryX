using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvviaQuiz : MonoBehaviour
{
   public GameObject ChiediQuiz ; 
   public GameObject Quiz;
   public GameObject BottoneFeedback ; 



   public void AvviaDomande(){
    ChiediQuiz.SetActive(false); 
    BottoneFeedback.SetActive(false) ; 
    Quiz.SetActive(true) ; 
   }
}
