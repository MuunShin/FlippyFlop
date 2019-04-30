using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScrolling : MonoBehaviour
{

    public float speed;

    public Transform initPos;
    public Transform teleportPos;


    void Start()
    {
    }

    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);

        if (gameObject.transform.position.x <= teleportPos.position.x)
        {
            transform.position = initPos.position;
        }
    }
}
