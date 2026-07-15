using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class TeleportActivator : MonoBehaviour
{
    public XRRayInteractor teleportInteractor;
    public XRRayInteractor rayInteractor;
    public InputActionProperty actionProperty;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        teleportInteractor.gameObject.SetActive(false);
        actionProperty.action.performed += Teleportation;
        rayInteractor.uiHoverEntered.AddListener(obj => DisableTeleport());
    }

    private void Teleportation(InputAction.CallbackContext context)
    {
        if (rayInteractor && rayInteractor.IsOverUIGameObject()) { return; }

        teleportInteractor.gameObject.SetActive(true);
    }

    public void DisableTeleport()
    {
        teleportInteractor.gameObject.SetActive(false);
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
