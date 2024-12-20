using UnityEngine;
using UnityEngine.UI;
using System.Collections;
 
public class Animazioniscroll : MonoBehaviour
{
   public ScrollRect scrollRect;
   public float scrollSpeed = 0.1f;  // Velocità di scorrimento
   public float scrollDuration = 0.3f;  // Durata dell'animazione di transizione
 
   private Coroutine currentScrollCoroutine;
 
   void Update()
   {
       float scrollInput = Input.GetAxis("Mouse ScrollWheel");
       if (scrollInput != 0)
       {
           // Calcola la nuova posizione
           float targetPosition = Mathf.Clamp(scrollRect.verticalNormalizedPosition + scrollInput * scrollSpeed, 0f, 1f);
 
           // Avvia l'animazione verso la nuova posizione
           if (currentScrollCoroutine != null)
               StopCoroutine(currentScrollCoroutine);
           currentScrollCoroutine = StartCoroutine(SmoothScrollToPosition(targetPosition));
       }
   }
 
   IEnumerator SmoothScrollToPosition(float targetPosition)
   {
       float startPosition = scrollRect.verticalNormalizedPosition;
       float elapsedTime = 0f;
 
       while (elapsedTime < scrollDuration)
       {
           scrollRect.verticalNormalizedPosition = Mathf.Lerp(startPosition, targetPosition, elapsedTime / scrollDuration);
           elapsedTime += Time.deltaTime;
           yield return null;
       }
 
       scrollRect.verticalNormalizedPosition = targetPosition;
   }
}