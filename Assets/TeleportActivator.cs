using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class TeleportActivator : MonoBehaviour
{
    public XRRayInteractor teleportInteractor;
    public InputActionProperty actionProperty;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        teleportInteractor.gameObject.SetActive(false);
        actionProperty.action.performed += Teleportation;
    }

    private void Teleportation(InputAction.CallbackContext context)
    {
        teleportInteractor.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (actionProperty.action.WasReleasedThisFrame())
        {
            teleportInteractor.gameObject.SetActive(false);
        }
    }
}
