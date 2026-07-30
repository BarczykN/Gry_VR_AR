using UnityEngine;

public class HeadCamera : MonoBehaviour
{
    private Camera cam;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.forward = cam.transform.forward;
    }
}
