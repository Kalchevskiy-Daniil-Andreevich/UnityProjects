using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Key : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //Time.deltaTime для сглаживания движения объекта.
    // Update is called once per frame
    void Update()
    {
        // Перемещение по оси X
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * Time.deltaTime;
        }

        // Перемещение по оси Y
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.up * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.down * Time.deltaTime;
        }

        // Перемещение по оси Z
        if (Input.GetKey(KeyCode.Q))
        {
            transform.position += Vector3.forward * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.E))
        {
            transform.position += Vector3.back * Time.deltaTime;
        }
    }
}
