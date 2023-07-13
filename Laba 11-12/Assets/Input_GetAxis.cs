using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Input_GetAxis : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Скорость перемещения куба
    float moveSpeed = 15f;

    // Скорость вращения куба
    float rotationSpeed = 100f;

    // Ограничение вращения по вертикали
    float verticalRotationLimit = 90f;

    // Текущее значение вращения по горизонтали
    float xRotation = 0f;

    // Текущее значение вращения по вертикали
    float yRotation = 0f;


    // Update is called once per frame
    void Update()
    {
        // Получаем значения перемещения от клавиатуры
        float x = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float z = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        // Перемещаем куб по горизонтали и вглубь
        transform.Translate(x, 0, z);

        // Получаем значения вращения от мыши
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;

        // Изменяем значения вращения по горизонтали и вертикали
        yRotation += mouseX;
        xRotation -= mouseY;

        // Ограничиваем вращение по вертикали от -90 до 90 градусов
        xRotation = Mathf.Clamp(xRotation, -verticalRotationLimit, verticalRotationLimit);

        // Применяем вращение к кубу
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0f);
    }
}
