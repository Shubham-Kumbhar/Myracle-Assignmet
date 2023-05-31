using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DartSpawner : MonoBehaviour
{
    
    public GameObject Dart;
    bool isSpawned= true;
    public float dartPower = 0f;
    bool isPowerUp = false;
    bool isDirectionUp = true;
    [SerializeField] private float powerSpeed= 100f;
    float perDartPower;
    GameManager manager;

    private void Start()
    {
        manager = FindObjectOfType<GameManager>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            manager.powerBar.value = 0;
            startPoweUp();
        }
        if (Input.GetMouseButtonUp(0))
        {
            enddPowerUp();
            shoot();
            manager.powerBar.value = 0;
        }
    }
    private void LateUpdate()
    {
        if (transform.childCount <= 0 && isSpawned)
        {
            StartCoroutine(spawnDart());
        }
        if(isPowerUp)
        {
            powerActivate();
        }
    }
    public void startPoweUp()
    {
        isPowerUp = true;
        isDirectionUp = true;
        dartPower = 0f;
    }
    public void powerActivate()
    {
        if (isDirectionUp)
        {
            dartPower += Time.deltaTime * powerSpeed;
            if (dartPower > 100f)
            {
                isDirectionUp = false;
                dartPower = 100;
            }
        }
        else
        {
            dartPower -= Time.deltaTime * powerSpeed;
            if (dartPower < 100f)
            {
                isDirectionUp = true;
                dartPower = 100f;
            }
        }
        perDartPower= dartPower / 100;
        manager.powerBar.value = perDartPower;

    }

    public void enddPowerUp()
    {
        isPowerUp = false;
    }

    void shoot()
    {
        GameObject go = transform.GetChild(0).gameObject;
        go.GetComponent<ThrowDart>().powerMultiplir = perDartPower;
        go.GetComponent<Rigidbody>().isKinematic = false;
        go.GetComponent<ThrowDart>().Shoot();
        go.transform.SetParent(null);
    }
    IEnumerator spawnDart()
    {
        isSpawned = false;
        manager.DartDec();
        yield return new WaitForSeconds(0.7f);
        Instantiate(Dart, this.transform);
        isSpawned = true;
    }
}
