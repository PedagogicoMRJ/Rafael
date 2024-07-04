using System.Collections;
using System.Collections.Generic;
// Usa a biblioteca da Unity
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Vari�vel que armazena a velocidade da bola
    public float speed;
    public Rigidbody2D rb;
    public Vector3 startPosition;
    // A fun��o Start � chamado antes do primeiro frame do jogo
    void Start()
    {

        startPosition = transform.position;
        // Chama a fun��o Launch
        Launch();
    }

    // A fun��o Launch gera o movimento da bola
    private void Launch()
    {
        // Atribiu um valor aleat�rio de -1 ou 1 a vari�vel x
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        // Atribiu um valor aleat�rio de -1 ou 1 a vari�vel y
        float y = Random.Range(0, 2) == 0 ? -1 : 1;
        // Atribiu � velocidade do componente Rigidbody um novo vetor x, y
        rb.velocity = new Vector2(speed * x, speed * y);
        }
    public void Reset ()
    {
        rb.velocity = Vector2.zero;
        transform.position = startPosition;
        Launch();
    }
}
