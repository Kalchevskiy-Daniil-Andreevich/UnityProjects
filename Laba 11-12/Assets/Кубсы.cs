using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Кубсы : MonoBehaviour
{
    public MeshRenderer rend;
    public float minX;
    public float maxX;
    public float minZ;
    public float maxZ;
    public float nX;
    public float nY;
    public float nZ;
    public GameObject obj;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<MeshRenderer>();
        minX = rend.bounds.min.x;
        maxX = rend.bounds.max.x;
        minZ = rend.bounds.min.z;
        maxZ = rend.bounds.max.z;
        nY = transform.position.y + 5;
        obj = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        nX = Random.Range(minX, maxX);
        nZ = Random.Range(minZ, maxZ);
        if (Input.GetKeyDown(KeyCode.Q))
        {
            GameObject cub = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cub.transform.position = new Vector3(nX, nY, nZ);
            cub.AddComponent<Rigidbody>();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            Quaternion rotZ = Quaternion.AngleAxis(-1, new Vector3(0, 0, 1));
            transform.rotation *= rotZ;
        }
    }
}
