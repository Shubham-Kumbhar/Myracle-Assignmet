using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballonFloat : MonoBehaviour
{
    [SerializeField] float speed;
    
    void Update()
    {
        floatUp();
    }

    void floatUp()
    {
        float delta = speed * Time.deltaTime;
        transform.position += new Vector3(0f, delta, 0f);

    }
}
