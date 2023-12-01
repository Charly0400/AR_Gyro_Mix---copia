using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acelerometro : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 tilt = Input.gyro.rotationRate;
        //tilt = Quaternion.Euler(90, 0, 0) * tilt;
        Debug.Log(tilt);

        rb.AddForce(tilt * speed);

        float movH = Input.acceleration.x;
        float movV = Input.acceleration.y;
        Vector3 dir = new Vector3(movH, 0.0f, movV).normalized;
        transform.Translate(dir * speed * Time.deltaTime);
    }
}
