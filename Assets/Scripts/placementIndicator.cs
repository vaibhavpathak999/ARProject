using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class placementIndicator : MonoBehaviour
{
    private ARRaycastManager rayManager;
    private GameObject visual;

    private void Start()
    { 
        //get the component
        rayManager = FindObjectOfType<ARRaycastManager>();
        visual = transform.GetChild(0).gameObject;

        // hide the placemnet visual 
        visual.SetActive(false);
    }

    private void Update()
    {
        //shoot a raycast form the centre of the screen
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        //hits a list of raycast gives the infomormation on hitting the surface

        rayManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2),  hits, TrackableType.Planes);

        //if we hit an AR plane, update the position and rototaion of visual

        if(hits.Count > 0)
        {
            transform.position = hits[0].pose.position;
            transform.rotation = hits[0].pose.rotation;

           

            if(!visual.activeInHierarchy)
            {
                visual.SetActive(true);
                Debug.Log(hits[0]);
            }
        }
    }

}
