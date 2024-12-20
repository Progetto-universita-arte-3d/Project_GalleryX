using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.PlayerLoop;
using UnityEngine.UIElements;

public class GoogleSheetFeedbackForm : MonoBehaviour
{
    [SerializeField] private TMP_InputField nomeInputField ; 
    [SerializeField] private TMP_InputField emailInputField ; 
    [SerializeField] private TMP_InputField feedbackInputField ;
    [SerializeField] private GameObject Form  ;
    [SerializeField] private Button BottoneChiusura;
    [SerializeField] private Sprite IconaFeedback ;      




    private string _nome ;   
    private string _email ;   
    private string _feedback ;

    private static string base_url = "https://docs.google.com/forms/u/0/d/e/1FAIpQLScp-QXNWPu1KH-ItN0jsv6paSHyMmTTjYg_87nDjVcOlif7Mg/formResponse" ;
    private static string nome_fiel = "entry.262152733";
    private static string email_fiel = "entry.1710341651";
    private static string feedback_fiel = "entry.1987210584";
    public void Send()
    {
        _nome = nomeInputField.text;
        _email= emailInputField.text;
        _feedback = feedbackInputField.text;
        //Invio i dati allo sheet Google
        StartCoroutine(Post());
        //Disattivo la visione del Form
        Form.SetActive(false) ; 
        nomeInputField.text="";
        emailInputField.text="";
        feedbackInputField.text="";

    }

   
    private IEnumerator Post()
    {
     WWWForm form = new WWWForm() ;
     form.AddField(nome_fiel, _nome);
     form.AddField(email_fiel, _email);
     form.AddField(feedback_fiel, _feedback);

     using UnityWebRequest www = UnityWebRequest.Post(base_url,form);
     yield return www.SendWebRequest();

     if (www.result == UnityWebRequest.Result.ConnectionError)
     {
        Debug.Log(www.error);
     }
     else Debug.Log("Success"); 
    }  

}
