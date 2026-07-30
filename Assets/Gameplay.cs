using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class Gameplay : MonoBehaviour
{
    [SerializeField] GameObject player;
    Vector3 previousPosition;
    public float currentDistance = 0;
    float distanceMin = 5f;
    float distanceMax = 15f;
    float distanceToTravel = 0;

    [SerializeField] TextMeshProUGUI distanceText;

    [SerializeField] GameObject[] animals;
    [SerializeField] private float spawnRadius = 250f;
    [SerializeField] private ARRaycastManager raycastManager;
    private List<ARRaycastHit> hits = new();

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        distanceToTravel = UnityEngine.Random.Range(distanceMin, distanceMax);
    }

    // Update is called once per frame
    void Update()
    {
        currentDistance = currentDistance + (player.transform.position - previousPosition).magnitude;
        previousPosition = player.transform.position;

        distanceText.text = "Distance: " + currentDistance + " / " + distanceToTravel;

        if(currentDistance > distanceToTravel)
        {
            
            SpawnAnimal();
            currentDistance = 0;
            distanceToTravel = UnityEngine.Random.Range(distanceMin, distanceMax);
        }
    }

    private void SpawnAnimal()
    {
        GameObject prefab = animals[UnityEngine.Random.Range(0, animals.Length)];

        Vector2 screenPoint = new Vector2(
            Screen.width / 2 + UnityEngine.Random.Range(-spawnRadius, spawnRadius),
            Screen.height / 2 + UnityEngine.Random.Range(-spawnRadius, spawnRadius));


        if (raycastManager.Raycast(screenPoint, hits, TrackableType.PlaneWithinPolygon))
        {
            Pose pose = hits[0].pose;

            Instantiate(prefab, pose.position, Quaternion.identity);
        }
    }
}
