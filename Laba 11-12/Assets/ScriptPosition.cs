using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptPosition : MonoBehaviour
{
    // Скорость перемещения по осям X, Y и Z
    public float speedX = 2f;
    public float speedY = 3f;
    public float speedZ = 4f;

    void Start()
    {

    }

    void Update()
    {
        transform.position += new Vector3(0.1f, 0.0f, 0.0f);



        // Перемещение объекта по оси X со скоростью speedX
        transform.Translate(speedX * Time.deltaTime, 0f, 0f);

        // Перемещение объекта по оси Y со скоростью speedY
        //transform.Translate(0f, speedY * Time.deltaTime, 0f);

        // Перемещение объекта по оси Z со скоростью speedZ
        //transform.Translate(0f, 0f, speedZ * Time.deltaTime);




    }
}



