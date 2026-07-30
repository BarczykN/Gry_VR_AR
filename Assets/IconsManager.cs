using UnityEngine;
using UnityEngine.UI;

public class IconsManager : MonoBehaviour
{
    [SerializeField] Material lockedMaterial;
    [SerializeField] Material unlockedMaterial;

    [SerializeField] Renderer[] renderers;

    [SerializeField] Button[] buttons;

    private void Start()
    {
        foreach (var renderer in renderers)
        {
            renderer.material = lockedMaterial;
        }

        foreach (var button in buttons)
        {
            button.interactable = false;
        }
    }

    public void Unlock(int i)
    {
        renderers[i].material = unlockedMaterial;
        buttons[i].interactable = true;
    }
}
