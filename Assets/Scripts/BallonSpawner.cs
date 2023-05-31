using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallonSpawner : MonoBehaviour
{
    public GameObject[] Ballon;
    [SerializeField] int x1,x2,y1,y2,z1,z2;
    [SerializeField] float spawnTime;



    private void Start()
    {
        StartCoroutine(spwn());
    }
    IEnumerator spwn()
    {
        yield return new WaitForSeconds(spawnTime);
        ballonSpawner();
        StartCoroutine(spwn());
    }
    void ballonSpawner()
    {
        Vector3 randomPos = new Vector3(Random.Range(x1,x2), Random.Range(y1, y2), Random.Range(z1, z2));
        int a = Random.Range(0, Ballon.Length);
        Instantiate(Ballon[a], randomPos, Quaternion.identity);
    }
}
