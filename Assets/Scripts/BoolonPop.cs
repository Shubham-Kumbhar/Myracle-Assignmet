using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoolonPop : MonoBehaviour
{
    [SerializeField] GameObject poper;
    GameManager manager;
    AudioSource audio;
    [SerializeField] AudioClip popSound;
    private void Start()
    {
        manager= FindObjectOfType<GameManager>();
        audio = GameObject.Find("audiosource").GetComponent<AudioSource>();

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Dart"))
        {
            Destroy(other.gameObject);
            audio.PlayOneShot(popSound);
            GameObject go= Instantiate(poper, transform);
            go.transform.SetParent(null);
            go.transform.position = transform.position;
            manager.ScoreInc();
            Destroy(gameObject);
        }
        else if(other.CompareTag("Wall"))
        {
            FindObjectOfType<GameManager>();
            Destroy(gameObject);
        }
    }

   
}
