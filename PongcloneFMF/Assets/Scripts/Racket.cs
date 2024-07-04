using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Racket : MonoBehaviour
{
    // Vari�vel booleana (recebe apenas um valor que pode ser verdadeiro ou falsa) para identificar o jogador a esquerda
    public bool isPlayerLeft;
    //Vari�vel que armazena o valor da velocidade das plataformas dos jogadores
    public float speed;
    // Vari�vel que acessa o componente Rigidbody 2D as plataformas
    public Rigidbody2D rb;
    // Vari�vel que armazena o valor referente aos movimentos das plataformas
    private float movement;
    // Obs: Vari�veis publicas podem ter seus valores alterados diretamente pela Unity
    public Vector3 startPosition;
    // A fun��o Update � chamado a cada atualiza��o de um frame

    void Start()
    {
        startPosition = transform.position;
    }

    public void Reset() {
        rb.velocity = Vector2.zero;
        transform.position = startPosition;       
    }
     void Update() { 
        // Verifica se a vari�vel boolena isPlayerLeft � verdadeira
        if(isPlayerLeft)
        // Caso a vari�vel seja verdadeira
        {
            // Armazena o valor da entrada Vertical1 na vari�vel movement
            movement = Input.GetAxisRaw("Vertical1");
        }
        // Caso a vari�vel seja falsa
        else
        {
            // Armazena o valor da entrada Vertical2 na vari�vel movement
            movement = Input.GetAxisRaw("Vertical2");
        }
        // Atribui � velocidade do componente Rigidbody um novo vetor x, y
        rb.velocity = new Vector2(rb.velocity.x, movement * speed);
    }
}