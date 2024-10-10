using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetLocation : MonoBehaviour
{
    public float lat;
    public float lon;
    private bool isLocationReady = false;

    void Start()
    {
        // Check if location services are enabled by the user
        if (!Input.location.isEnabledByUser)
        {
            Debug.Log("Location not enabled");
            return;
        }
        Input.location.Start();
        Debug.Log("Starting location services...");

        // Start location services
        
    }

    void Update()
    {
        if (Input.location.status == LocationServiceStatus.Stopped){
            Input.location.Start();
            Debug.Log("Attempting to start location services...");
            return;
        }   
        // Wait for location services to initialize
        if (Input.location.status == LocationServiceStatus.Initializing)
        {
            Debug.Log("Location services initializing...");
            return;
        }

        // Check if location services failed
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            Debug.Log("Location Failed");
            return;
        }

        // Once location services are running, update GPS coordinates
        if (Input.location.status == LocationServiceStatus.Running && !isLocationReady)
        {
            // Get the current location
            lat = Input.location.lastData.latitude;
            lon = Input.location.lastData.longitude;
            isLocationReady = true;

            Debug.Log("Latitude: " + lat + " Longitude: " + lon);
        }
    }

    void OnDisable()
    {
        // Stop location services when no longer needed
        Input.location.Stop();
        Debug.Log("Stopping location services.");
    }
}
