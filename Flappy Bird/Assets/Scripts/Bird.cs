using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public float speed = 4f;
    private Rigidbody2D rig;
    public GameObject gameover;   // Start is called before the first frame update
    public AudioSource audiofly;
    public AudioSource audiogameover;
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()

    {
        if (Input.GetMouseButtonDown(0))
        {
            audiofly.Play();
            rig.velocity = Vector2.up * speed; }

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameover.SetActive(true);
        audiogameover.Play();

        Time.timeScale = 0;
    }
}