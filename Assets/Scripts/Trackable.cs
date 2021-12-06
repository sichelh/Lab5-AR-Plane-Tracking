using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class Trackable : MonoBehaviour
{
    // Start is called before the first frame update
    private ARSessionOrigin arSessionOrigin; 
    void Start() 
    { 
        arSessionOrigin = FindObjectOfType<ARSessionOrigin>(); 
        transform.parent = arSessionOrigin.trackablesParent; 
    }
}
