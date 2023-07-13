using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingMuzzle : MonoBehaviour
{
public GameObject Bullet; // Объявляем публичную переменную типа GameObject для хранения префаба пули

    void Update()
    {
        if (Input.GetMouseButtonDown(0))// Проверяем, была ли нажата левая кнопка мыши
        {

            float spawnPoint = gameObject.GetComponent<Renderer>().bounds.size.x; // Получаем размер объекта, на котором расположен скрипт
            Vector3 muzzleForward = transform.position + transform.TransformDirection(Vector3.forward * spawnPoint); // Вычисляем точку спавна пули
            GameObject newBullet = Instantiate(Bullet,muzzleForward,transform.rotation);  // Создаем новый экземпляр префаба пули в точке спавна
            var MuzzleEulerAngles = transform.rotation;     // Получаем угол поворота объекта, на котором расположен скрипт
            newBullet.transform.rotation = MuzzleEulerAngles;  // Устанавливаем угол поворота для новой пули
            newBullet.transform.Rotate(new Vector3(0, 90 ,180));     // Поворачиваем пулю на 90 градусов по оси Y и на 180 градусов по оси Z

            //var audioSource = newBullet.gameObject.GetComponent<AudioSource>();
            //audioSource.PlayOneShot(audioSource.clip);
        }
    }
}
