using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]

public class TapSpawnDestroy : MonoBehaviour
{
    public GameObject objectToInstantiate;

    private ARRaycastManager raycastManager;

    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private GameObject spawned;


    // Start is called before the first frame update
    void Start()
    {
        raycastManager = GetComponent<ARRaycastManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out hit);

            if (raycastManager.Raycast(ray, hits))
            {
                Pose hitPose = hits[0].pose;
 
                if (hit.collider.gameObject.CompareTag("ball"))
                {
                    Destroy(hit.collider.gameObject);
                }
                else
                {
                    spawned = Instantiate(objectToInstantiate, new Vector3(hitPose.position.x, hitPose.position.y+1, hitPose.position.z), hitPose.rotation);
                }

            }
        }
    }
}
