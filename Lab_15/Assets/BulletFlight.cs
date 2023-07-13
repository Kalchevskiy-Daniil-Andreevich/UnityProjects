using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;

public class BulletFlight : MonoBehaviour
{
    // Определяем скорость пули
    public float bulletSpeed = 5f;
    // Объект взрыва
    public GameObject explosion;

    void Start()
    {
        // Уничтожаем объект через 5 секунд после создания
        Destroy(gameObject, 5f);   
    }

    void Update()
    {
        // Двигаем пулю вперед
        transform.position += transform.TransformDirection(Vector3.up * bulletSpeed);
    }
    // Обработка столкновения пули с другим объектом
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Goal")// Если пуля столкнулась с объектом с тегом "Goal"
        {
            other.gameObject.GetComponent<Renderer>().material.color = new Color(Random.Range(.0f, 1.0f),Random.Range(.0f, 1.0f), Random.Range(.0f, 1.0f)); // Изменяем цвет объекта на случайный
            gameObject.GetComponent<Renderer>().enabled = false;    // Скрываем пулю
            Instantiate(explosion, other.transform.position, Quaternion.identity);     // Создаем взрыв в месте столкновения

            var audioSource = other.gameObject.GetComponent<AudioSource>();    // Воспроизводим звук взрыва
            audioSource.PlayOneShot(audioSource.clip);
        }
    }
}
