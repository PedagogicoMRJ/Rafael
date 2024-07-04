using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Racket : MonoBehaviour
{
    // Variável booleana (recebe apenas um valor que pode ser verdadeiro ou falsa) para identificar o jogador a esquerda
    public bool isPlayerLeft;
    //Variável que armazena o valor da velocidade das plataformas dos jogadores
    public float speed;
    // Variável que acessa o componente Rigidbody 2D as plataformas
    public Rigidbody2D rb;
    // Variável que armazena o valor referente aos movimentos das plataformas
    private float movement;
    // Obs: Variáveis publicas podem ter seus valores alterados diretamente pela Unity
    public Vector3 startPosition;
    // A função Update é chamado a cada atualização de um frame

    void Start()
    {
        startPosition = transform.position;
    }

    public void Reset() {
        rb.velocity = Vector2.zero;
        transform.position = startPosition;       
    }
     void Update() { 
        // Verifica se a variável boolena isPlayerLeft é verdadeira
        if(isPlayerLeft)
        // Caso a variável seja verdadeira
        {
            // Armazena o valor da entrada Vertical1 na variável movement
            movement = Input.GetAxisRaw("Vertical1");
        }
        // Caso a variável seja falsa
        else
        {
            // Armazena o valor da entrada Vertical2 na variável movement
            movement = Input.GetAxisRaw("Vertical2");
        }
        // Atribui à velocidade do componente Rigidbody um novo vetor x, y
        rb.velocity = new Vector2(rb.velocity.x, movement * speed);
    }
}