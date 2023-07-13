using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation_Quaternion : MonoBehaviour
{
    private Quaternion initialRotation;

    // Угол поворота объекта
    private float rotationAngle = 0f;

    void Start()
    {
        // Фиксируем начальный поворот объекта
        initialRotation = transform.rotation;
    }

    void Update()
    {
        // Задаем приращение угла поворота
        float deltaAngle = Time.deltaTime * 50f;

        // Определяем угол поворота вокруг оси X
        Quaternion rotationX = Quaternion.AngleAxis(rotationAngle, Vector3.right);

        // Определяем угол поворота вокруг оси Z
        Quaternion rotationZ = Quaternion.AngleAxis(rotationAngle, Vector3.forward);

        // Задаем общий угол поворота объекта вокруг двух осей
        transform.rotation = initialRotation * rotationX * rotationZ;

        // Увеличиваем угол поворота
        rotationAngle += deltaAngle;
    }
}
