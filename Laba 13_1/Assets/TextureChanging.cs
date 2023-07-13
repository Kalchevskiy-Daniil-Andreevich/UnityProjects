using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TextureChanging : MonoBehaviour
{
    public float speed = 5f;
    public Texture Texture1;
    public Texture Texture2;
    public Texture Texture3;
    public GameObject gameObject;
    void Update()
    {
        //Движение
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical);
        transform.Translate(direction * speed * Time.deltaTime);

        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.up, mouseX * speed * Time.deltaTime);

        //Изменение текстуры объекта по нажатию на клавиши
        if (Input.GetKey(KeyCode.Alpha1))
            gameObject.GetComponent<Renderer>().material.mainTexture = Texture1;
        if (Input.GetKey(KeyCode.Alpha2))
            gameObject.GetComponent<Renderer>().material.mainTexture = Texture2;
        if (Input.GetKey(KeyCode.Alpha3))
            gameObject.GetComponent<Renderer>().material.mainTexture = Texture3;
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (Random.Range(0, 3))
        {
            case 0:
                collision.gameObject.GetComponent<Renderer>().material.mainTexture = Texture1;
                break;
            case 1:
                collision.gameObject.GetComponent<Renderer>().material.mainTexture = Texture2;
                break;
            case 2:
                collision.gameObject.GetComponent<Renderer>().material.mainTexture = Texture3;
                break;
        }

    }
}
