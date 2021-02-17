using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectSpawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    private placementIndicator indicator;

    private void Start()
    {
        indicator = FindObjectOfType<placementIndicator>();
    }
    private void Update()
    {
        if(Input.touchCount>0 && Input.touches[0].phase == TouchPhase.Began)
        {
            GameObject obj = Instantiate(objectToSpawn, indicator.transform.position, indicator.transform.rotation);
        }
    }
}
