using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneSpawner : MonoBehaviour
{
    public GameObject phone1;
    public GameObject phone2;
    public GameObject phone1Spawner;
    public GameObject phone2Spawner;

    public float startRateTime;
    private float rateTime;
    void Start()
    {
        rateTime = startRateTime;
        InvokeRepeating("InstantiatePhone", 0f, rateTime);
    }


    private void InstantiatePhone() {
        Instantiate(phone1, phone1Spawner.transform.position, Quaternion.identity);
        Instantiate(phone2, phone2Spawner.transform.position, Quaternion.identity);
    }

}
