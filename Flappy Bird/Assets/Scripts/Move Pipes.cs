using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePipes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public float speed;
    // Update is called once per frame
    void Update()
    {
    transform.position += Vector3.left * speed * Time.deltaTime;
     }
}
