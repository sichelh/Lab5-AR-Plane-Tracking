using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlacementIndicator : MonoBehaviour
{
    private ARRaycastManager rayManager;

    private GameObject indicator;

    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    public GameObject objectToSpawn;
    private GameObject spawned;

    // Start is called before the first frame update
    void Start()
    {
        rayManager = FindObjectOfType<ARRaycastManager>();

        indicator = transform.GetChild(0).gameObject; //plane
        indicator.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       rayManager.Raycast(new Vector2(Screen.width/2, Screen.height/2), hits, TrackableType.PlaneWithinPolygon);

        if (hits.Count > 0)
        {

            if (!indicator.activeInHierarchy)
            {
                indicator.SetActive(true);
            }
            else
            {
                if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
                {
                    if (spawned == null)
                    {
                        spawned = Instantiate(objectToSpawn, transform.position, transform.rotation);
                    }
                    else //move prefabs position
                    {
                        spawned.transform.position = transform.position;
                    }
                }
                if (Input.touchCount > 0)
                {
                    spawned.transform.position = transform.position;
                }
            }

            // move the PlacementIndicator
            transform.position = hits[0].pose.position;
            transform.rotation = hits[0].pose.rotation;
        }
        else
        {
            indicator.SetActive(false); //plane위에서만 가능하도록!
        }
    }
}
