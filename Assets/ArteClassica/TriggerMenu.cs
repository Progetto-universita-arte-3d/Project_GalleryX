using System;
using UnityEngine;
using UnityEngine.UI;

public class TriggerMenu : MonoBehaviour
{
    public GameObject menu; // Riferimento al menu (Canvas)
    public GameObject form ; //Riferimento a form feedback  
    public GameObject SchermataChiediQuiz ; //Riferimento a schermata di richiesta quiz
    public GameObject SchermataQuiz ; //riferimento alla schermata effettiva dei quiz
    public Button entrataButton; // Bottone "Entrata"
    public Button uscitaButton; // Bottone "Uscita"
    public GameObject playerController; // Riferimento al controller della prima persona
    public Camera firstPersonCamera; // Riferimento alla telecamera della prima persona
    public Camera secondaryCamera; // Riferimento alla telecamera secondaria
    public Transform TargetUscita ; //Riferimento al blocco per uscire
    public Animator menuAnimator; // Riferimento all'animator per l'effetto visivo (opzionale)

    private void Start()
    {
        // Assicurati che la telecamera della prima persona sia attiva all'inizio
        firstPersonCamera.enabled = true;
        secondaryCamera.enabled = false;

        // Assicurati che il controller della prima persona sia attivo all'inizio
        playerController.SetActive(true);

        // Disattiva il menu all'inizio
        menu.SetActive(false);
        //disattivo form 
        form.SetActive(false) ; 
        //disattivo Schermata cheidi quiz
        SchermataChiediQuiz.SetActive(false) ;
        //disattivo schermata quiz
        SchermataQuiz.SetActive(false) ;
        // Disabilita il cursore all'inizio
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Blocca il controllo della prima persona
            playerController.SetActive(false);

            // Disattiva la telecamera della prima persona
            firstPersonCamera.enabled = false;

            // Attiva la telecamera secondaria
            secondaryCamera.enabled = true;

            // Mostra il menu
            menu.SetActive(true);

            // Effetto visivo per il menu (opzionale)
            if (menuAnimator != null)
            {
                menuAnimator.SetTrigger("ShowMenu");
            }

            // Attiva il cursore
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            // Simula la pressione del bottone "Entrata"
            entrataButton.onClick.Invoke();
        }
    }

    public void Uscita()
    {


        // Disattiva il menu
        menu.SetActive(false);
        //Disattiva Schermata chiedi quiz
        SchermataChiediQuiz.SetActive(false) ; 

        // Disattiva la telecamera secondaria
        secondaryCamera.enabled = false;

        //Sposto prima persona per non far ripartire il menu

        playerController.transform.position = TargetUscita.position;
        
        // Riattiva la telecamera della prima persona
        firstPersonCamera.enabled = true;

        // Ripristina il controllo della prima persona
        playerController.SetActive(true);

        // Disabilita il cursore quando si esce dal menu
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
