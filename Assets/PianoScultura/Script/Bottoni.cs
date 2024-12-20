using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Bottoni : MonoBehaviour
{  
    public TriggerMenu ScriptPerUscire ; 
    public Button Bottone0;//riferimento al bottone 0
    public Button Bottone1;//riferimento al bottone 1
    public Button Bottone2;//riferimento al bottone 2
    public Button Bottone3;//riferimento al bottone 3
    public GameObject PosizioneCentrale; //riferimento al centro
    public TextMeshProUGUI BottoneRisposta0; //riferiemento a bottone contenente la risposta 1 
    public TextMeshProUGUI BottoneRisposta1; //riferiemento a bottone contenente la risposta 2
    public TextMeshProUGUI BottoneRisposta2; //riferiemento a bottone contenente la risposta 3 
    public TextMeshProUGUI BottoneRisposta3; //riferiemento a bottone contenente la risposta 4
    public TextMeshProUGUI TestoDomanda; //riferiemento al testo contenente la domanda nell'interfaccia
    public TextMeshProUGUI TestoRispostaEsatta; //riferiemento al testo contenente la risposta esatta nell'interfaccia
    
    public TextMeshProUGUI TestoCounterPunteggio; //riferiemento a testo contenente il counter del punteggio nell'interfaccia
    public TextMeshProUGUI TestoPunteggio; //riferiemento a testo contenente il punteggio nell'interfaccia
    public int CounterPunteggio; //variabile che tiene conto dei punti 
    public int IndiceRispostaData; //variabile che contiene la risposta data dall'utente
    
    public TextMeshProUGUI counter ; //contatore di quante domande sono state fatte 

    //Vettore che contiene tutte le domande da fare
    string[] Domande = { "Dove si trova attualmente la Nike di Samotracia?", "La Nike di Samotracia rappresenta", "Chi ha scolpito il Discobolo?", "L'originale del Discobolo era realizzato in:" };

    //Vettore che contiene tutte le risposte anche sbagliate
    string[][] risposte = {
        new string[] { "Museo del Prado, Madrid", "Louvre, Parigi", "British Museum, Londra", "Museo Archeologico di Atene" },
        new string[] { "Una dea della caccia", "Una divinità della guerra", "La dea della vittoria", "Un personaggio mitologico sconosciuto" },
        new string[] { "Fidia", "Mirone", "Policleto", "Prassitele" },
        new string[] { "Marmo", "Bronzo", "Terracotta", "Ferro" },
    };

    //Vettore che contiene gli indici di tutte le risposte corrette
    int[] indiceRispostaEsatta = { 1, 2, 1, 1 };

    // Dichiarazione del vettore di domande, inizializzazione avverrà in Start()
    Domanda[] vettoreDomande;

    // Definizione della classe Domanda
    public class Domanda
    {
        public string Testo { get; set; } // La domanda
        public string[] Risposte { get; set; } // Array delle risposte possibili
        public int IndiceRispostaEsatta { get; set; } // Indice della risposta corretta nell'array
        
        // Costruttore per inizializzare l'oggetto Domanda
        public Domanda(string testo, string[] risposte, int indiceRispostaEsatta)
        {
            Testo = testo;
            Risposte = risposte;
            IndiceRispostaEsatta = indiceRispostaEsatta;
        }

        // Verifica se la risposta data è corretta
        public bool VerificaRisposta(int IndiceRisposta)
        {
            return IndiceRisposta == IndiceRispostaEsatta;
        }

        // Restituisce il testo della domanda
        public string RestituisciDomanda()
        {
            return Testo;
        }

        // Restituisce il vettore delle possibili risposte alla domanda
        public string[] RestituisciRisposte()
        {
            return Risposte;
        }

        // Restituisce la risposta esatta
        public string RestituisciRispotaEsatta()
        {
            return Risposte[IndiceRispostaEsatta];
        }
    }

    // Metodo Start per inizializzare il vettore delle domande
    void Start()
    {
        CreaDomande(); // Chiamata al metodo per creare le domande
    }

    // Funzione che crea il vettore di domande
    public void CreaDomande()
    {
        // Inizializzazione del vettoreDomande con il numero di domande
        vettoreDomande = new Domanda[Domande.Length];

        // Creazione del vettore di domande
        for (int j = 0; j < Domande.Length; j++) // Modifica per partire da j = 0
        {
            vettoreDomande[j] = new Domanda(Domande[j], risposte[j], indiceRispostaEsatta[j]);
        }
    }

    // Funzione che viene chiamata quando viene cliccato il bottone 0
    public void B_0_premuto()
    {
        IndiceRispostaData = 0;
        CorreggiRisposte();
    }

    // Funzione che viene chiamata quando viene cliccato il bottone 1
    public void B_1_premuto()
    {
        IndiceRispostaData = 1;
        CorreggiRisposte();
    }

    // Funzione che viene chiamata quando viene cliccato il bottone 2
    public void B_2_premuto ()
    {
        IndiceRispostaData = 2;
        CorreggiRisposte();
    }

    // Funzione che viene chiamata quando viene cliccato il bottone 3
    public void B_3_premuto()
    {
        IndiceRispostaData = 3;
        CorreggiRisposte();
    }

    // Funzione per correggere le risposte
    public async void CorreggiRisposte()
    {
        // SE LA DOAMANDA è lA prima
        if(int.Parse(counter.text) == 0){
            //Verifico se la rispota è corretta
             if (vettoreDomande[int.Parse(counter.text)].VerificaRisposta(IndiceRispostaData))
                {
                // Se la risposta è corretta, incremento il punteggio e aggiorno il display
                CounterPunteggio = int.Parse(TestoCounterPunteggio.text) ; 
                TestoCounterPunteggio.text =(CounterPunteggio+1).ToString();
                //coloro il testo di verde
                TestoRispostaEsatta.color= new Color32(0,100,0,255);
                //Comunico che la risposta è corretta 
                TestoRispostaEsatta.text = "RISPOSTA CORRETTA!";
                //Aspetto un secondo  
                await Task.Delay(1000);
                //Svuoto il testo della casella risposta esatta
                TestoRispostaEsatta.text = "" ;
                TestoRispostaEsatta.color = Color.white;
                counter.text=(int.Parse(counter.text)+1).ToString();
                CambiaRisposte();
                }
                else{
                    TestoRispostaEsatta.color = Color.red;
                    TestoRispostaEsatta.text = "RISPOSTA SBAGLIATA!";
                    //Aspetto un secondo  
                    await Task.Delay(1000);
                    //Svuoto il testo della casella risposta esatta
                    TestoRispostaEsatta.color = Color.white;
                    TestoRispostaEsatta.text = "RISPOSTA ESATTA : " + vettoreDomande[int.Parse(counter.text)].RestituisciRispotaEsatta();
                    //Aspetto un secondo  
                    await Task.Delay(1000);
                    //Svuoto il testo della casella risposta esatta
                     TestoRispostaEsatta.text = "" ;
                    counter.text=(int.Parse(counter.text)+1).ToString();
                    CambiaRisposte();
                }
            }
        else if (int.Parse(counter.text) <vettoreDomande.Length-1){
            //dalla seconda domanda fino alla penultima
            //se la risposta data è corretta
            if(vettoreDomande[int.Parse(counter.text)].VerificaRisposta(IndiceRispostaData)){
                //aggiorno il counter del punteggio e lo stampo a schermo 
                CounterPunteggio = int.Parse(TestoCounterPunteggio.text) ; 
                TestoCounterPunteggio.text =(CounterPunteggio+1).ToString();
                TestoRispostaEsatta.text = "RISPOSTA CORRETTA!" ;
                //imposto il colore verde 
                TestoRispostaEsatta.color= new Color32(0,100,0,255);
                //aspetto 1 secondo 
                await Task.Delay(1000) ; 
                //resetto la scritta della risposta corretta
                TestoRispostaEsatta.text = "";
                TestoRispostaEsatta.color = Color.white;
                //aggiorno il counter delle domande 
                counter.text=(int.Parse(counter.text)+1).ToString();
                //cambio la domanda e i testi delle rispsote
                CambiaRisposte();
            }else{
                //Se la risposta non è corretta
                //comnuico che risposta non è corretta
                TestoRispostaEsatta.text = "RISPOSTA SBAGLIATA" ; 
                TestoRispostaEsatta.color= Color.red;
                //aspetto un secondo
                await Task.Delay(1000) ;
                //comunico la risposta esatta
                TestoRispostaEsatta.color = Color.white;
                TestoRispostaEsatta.text = "RISPOSTA ESATTA: " + vettoreDomande[int.Parse(counter.text)].RestituisciRispotaEsatta() ;
                //aspetto un secondo 
                await Task.Delay(1000) ;
                //svuoto il testo contente la risposta corretta
                TestoRispostaEsatta.text = "" ; 
                //aggiorno il counter domande 
                counter.text=(int.Parse(counter.text)+1).ToString();
                //passo alla domanda successiva
                CambiaRisposte();
            }

        }
        else if (int.Parse(counter.text)==vettoreDomande.Length-1){
            if(vettoreDomande[int.Parse(counter.text)].VerificaRisposta(IndiceRispostaData)){
                //aggiorno il counter del punteggio e lo stampo a schermo 
                CounterPunteggio = int.Parse(TestoCounterPunteggio.text) ; 
                TestoCounterPunteggio.text =(CounterPunteggio+1).ToString();
                TestoRispostaEsatta.text = "RISPOSTA CORRETTA!" ;
                //imposto il colore verde 
                TestoRispostaEsatta.color= new Color32(0,100,0,255);
                //aspetto 1 secondo 
                await Task.Delay(1000) ; 
                //resetto la scritta della risposta corretta
                TestoRispostaEsatta.text = "";
                TestoRispostaEsatta.color = Color.white;
                //aggiorno il counter delle domande 
                counter.text=(int.Parse(counter.text)+1).ToString();
                //chiamo la schermta di fine quiz
                FineQuiz();
            }else{
                //Se la risposta non è corretta
                //comnuico che risposta non è corretta
                TestoRispostaEsatta.text = "RISPOSTA SBAGLIATA" ; 
                TestoRispostaEsatta.color= Color.red;
                //aspetto un secondo
                await Task.Delay(1000) ;
                //comunico la risposta esatta
                TestoRispostaEsatta.color = Color.white;
                TestoRispostaEsatta.text = "RISPOSTA ESATTA: " + vettoreDomande[int.Parse(counter.text)].RestituisciRispotaEsatta() ;
                //aspetto un secondo 
                await Task.Delay(1000) ;
                //svuoto il testo contente la risposta corretta
                TestoRispostaEsatta.text = "" ; 
                //aggiorno il counter domande 
                counter.text=(int.Parse(counter.text)+1).ToString();
                //passo alla domanda successiva
                FineQuiz();
        }
    } 
    }

    // Funzione che aggiorna le risposte sui bottoni
    public void CambiaRisposte()
    {
        // Cambia il testo dei bottoni e delle risposte in base alla domanda corrente
        BottoneRisposta0.text = vettoreDomande[int.Parse(counter.text)].RestituisciRisposte()[0];
        BottoneRisposta1.text = vettoreDomande[int.Parse(counter.text)].RestituisciRisposte()[1];
        BottoneRisposta2.text = vettoreDomande[int.Parse(counter.text)].RestituisciRisposte()[2];
        BottoneRisposta3.text = vettoreDomande[int.Parse(counter.text)].RestituisciRisposte()[3];
        TestoDomanda.text = vettoreDomande[int.Parse(counter.text)].RestituisciDomanda();
    }

public async void FineQuiz(){
    //Se le domande sono terminate 
            //Comunico che il quiz è terminato
            TestoDomanda.text = "QUIZ COMPLEATO" ;
            //disabilito i bottoni 
            Bottone0.GetComponent<Image>().enabled  =false ; 
            Bottone0.interactable =false;
            Bottone1.GetComponent<Image>().enabled  =false ; 
            Bottone1.interactable =false; 
            Bottone2.GetComponent<Image>().enabled  =false ; 
            Bottone2.interactable =false;
            Bottone3.GetComponent<Image>().enabled  =false ; 
            Bottone3.interactable =false;
            //disabilito i testi dei bottoni    
            BottoneRisposta0.gameObject.SetActive(false);
            BottoneRisposta1.gameObject.SetActive(false);
            BottoneRisposta2.gameObject.SetActive(false);
            BottoneRisposta3.gameObject.SetActive(false);
            //assegno una variabile alla nuova posizione 
            TestoPunteggio.transform.position = PosizioneCentrale.transform.position ;
            //Rendo il testo molto più grande
            TestoPunteggio.fontSize=100;
            TestoCounterPunteggio.fontSize=100;
            await Task.Delay(4000);
            ScriptPerUscire.Uscita();
}
}
    


