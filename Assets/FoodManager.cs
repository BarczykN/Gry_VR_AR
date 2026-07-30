using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class FoodManager : MonoBehaviour
{
    GameObject foodGameObjectTracked;
    Vector3 velocity;
    Vector3 previousPosition;

    [SerializeField] GameObject foodGameObject;
    bool showFood = false;

    [SerializeField] GameObject cameraObject;
    [SerializeField] GameObject foodPrefab;

    [SerializeField] ObjectSpawner objectSpawner;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovementAndThrow();

    }

    private void SpawnFood()
    {
        foodGameObject = Instantiate(foodPrefab, cameraObject.transform);
    }

    public void ShowFood()
    {
        showFood = true;
        foodGameObject.SetActive(showFood);
        objectSpawner.foodInteraction = true;
    }

    public void HideFood()
    {
        showFood = false;
        foodGameObject.SetActive(showFood);
        objectSpawner.foodInteraction = false;
    }


    private void HandleMovementAndThrow()
    {

        Vector2 pointerPosition = new Vector2();
        bool pressed = false;
        bool released = false;


        if (Touchscreen.current != null)
        {
            pointerPosition = Touchscreen.current.primaryTouch.position.ReadValue();
            pressed = Touchscreen.current.primaryTouch.press.wasPressedThisFrame;
            released = Touchscreen.current.primaryTouch.press.wasReleasedThisFrame;
        }

#if UNITY_EDITOR
        pointerPosition = Mouse.current.position.ReadValue();
        pressed = Mouse.current.leftButton.wasPressedThisFrame;
        released = Mouse.current.leftButton.wasReleasedThisFrame;
#endif


        Ray ray = Camera.main.ScreenPointToRay(pointerPosition);
        RaycastHit hit;


        if (pressed)
        {
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("Hit item: " + hit.collider.name);

                if (hit.collider.CompareTag("Food"))
                {
                    foodGameObjectTracked = hit.collider.gameObject;

                    Rigidbody rb = foodGameObjectTracked.GetComponent<Rigidbody>();
                    rb.isKinematic = true;
                    rb.useGravity = false;
                }
            }
        }


        if (foodGameObjectTracked != null)
        {
            if (released)
            {
                Rigidbody rb = foodGameObjectTracked.GetComponent<Rigidbody>();

                rb.isKinematic = false;
                rb.useGravity = true;
                rb.linearVelocity = velocity;

                Destroy(foodGameObjectTracked, 2);
                foodGameObjectTracked = null;
                SpawnFood();
            }
            else
            {
                StartCoroutine(DelayedMovement(ray));
            }
        }
    }

    IEnumerator DelayedMovement(Ray ray)
    {
        yield return new WaitForSeconds(0.05f);
        if(foodGameObjectTracked != null)
        {
            foodGameObjectTracked.transform.position = ray.GetPoint(0.4f);
            Vector3 newPosition = ray.GetPoint(0.4f);
            velocity = (newPosition - previousPosition) / Time.deltaTime;
            previousPosition = newPosition;
        }  
    }
}
