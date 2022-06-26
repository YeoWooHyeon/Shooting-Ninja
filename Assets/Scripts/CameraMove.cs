using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform target;
    public float speed;

    void LateUpdate()
    {
        transform.position = new Vector3(target.position.x + 2.5f, target.position.y + 0.75f, -10f);
        // transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * speed);
        // transform.position = new Vector3(transform.position.x, transform.position.y, -10f);
    }
}
