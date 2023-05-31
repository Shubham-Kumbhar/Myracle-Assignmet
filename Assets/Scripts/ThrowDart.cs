using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowDart : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    public float maxPower=500f;
    public float powerMultiplir = 0;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void Shoot()
    {
        float power = maxPower * powerMultiplir;
        rb.AddForce(transform.forward*power);
        Destroy(gameObject, 5f);
    }
}
