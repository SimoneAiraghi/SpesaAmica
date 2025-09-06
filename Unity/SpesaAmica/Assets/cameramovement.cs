using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CameraMovement : MonoBehaviour
{
    public GameObject oggettoDaDistruggere1;
    public GameObject oggettoDaDistruggere2;
    // Aggiungi altri oggetti se necessario

    // Metodo per ottenere la posizione corrente
    public Vector3 GetCurrentPosition()
    {
        return transform.position;
    }

    
    /*
    public void Start()
    {
        if(PersistentSound.Instance.audioSource != null)
            PersistentSound.Instance.audioSource.Stop();
    }*/

    public void MoveRight()
    {
        Vector3 currentPosition = GetCurrentPosition();
        if (currentPosition.x < 35)
        {
            Vector3 TargetPositon = new Vector3(currentPosition.x + 17.86f, currentPosition.y, currentPosition.z);
            SmoothMoveTo(TargetPositon);
        }
        else
        {
            // Distruggi solo gli oggetti specifici sul Canvas prima di passare alla nuova scena
            DestroySpecificUIObjects();

            // Carica la nuova scena
            SceneManager.LoadScene("cassa");
        }
    }

    public void MoveLeft()
    {
        Vector3 currentPosition = GetCurrentPosition();
        if (currentPosition.x > 0)
        {
            Vector3 TargetPositon = new Vector3(currentPosition.x - 17.86f, currentPosition.y, currentPosition.z);
            SmoothMoveTo(TargetPositon);
        }
    }

    private void SmoothMoveTo(Vector3 targetPosition)
    {
        StartCoroutine(SmoothMovement(targetPosition));
    }

    private IEnumerator SmoothMovement(Vector3 targetPosition)
    {
        float elapsedTime = 0f;
        float smoothTime = 0.5f; // Puoi regolare questo valore per controllare la velocità di smoothing

        Vector3 startingPosition = GetCurrentPosition();

        while (elapsedTime < smoothTime)
        {
            transform.position = Vector3.Lerp(startingPosition, targetPosition, (elapsedTime / smoothTime));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Assicurati di posizionare esattamente alla posizione finale per evitare errori di arrotondamento
        transform.position = targetPosition;
    }

    private void DestroySpecificUIObjects()
    {
        // Distruggi solo gli oggetti specifici che hai assegnato
        if (oggettoDaDistruggere1 != null)
        {
            Destroy(oggettoDaDistruggere1);
        }

        if (oggettoDaDistruggere2 != null)
        {
            Destroy(oggettoDaDistruggere2);
        }

        // Aggiungi altre distruzioni se necessario
    }
}
