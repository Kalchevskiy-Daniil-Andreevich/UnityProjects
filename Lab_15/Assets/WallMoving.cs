using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMoving : MonoBehaviour
{
    public GameObject item; // Объект, который будет двигаться
    private float direction = 1f; // Направление движения объекта

    public float movingSpeed = 1f; // Скорость движения объекта

    private void Start()
    {
        movingSpeed /= 10; // Уменьшаем скорость движения объекта в 10 раз
    }
    // Обработка столкновения объекта с другим коллайдером
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "tankgg") // Если столкнулись с объектом с именем "tankgg"
        {
            var itemPos = item.gameObject.GetComponent<Transform>().position; // Получаем позицию объекта
            if (itemPos.y >= 70)// Если объект находится выше или на уровне 70 по оси Y, меняем направление движения на противоположное
                direction = -1f;
            else if(itemPos.y <= 14)// Если объект находится выше или на уровне 70 по оси Y, меняем направление движения на противоположное
                direction = 1f;
            // Изменяем позицию объекта на новую, учитывая направление движения и скорость
            item.gameObject.GetComponent<Transform>().position =
                new Vector3(itemPos.x, itemPos.y + movingSpeed * direction, itemPos.z);
            
        }
    }
}
