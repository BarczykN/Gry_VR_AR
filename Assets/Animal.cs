using System.Collections;
using TMPro;
using UnityEngine;

public class Animal : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI foodAddText;
    [SerializeField] IconsManager iconsManager;
    public int index = 0;

    private void Start()
    {
        foodAddText.text = string.Empty;
        iconsManager = FindFirstObjectByType<IconsManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Food")
        {
            Destroy(collision.gameObject);
            GetFood();
        }
    }

    private void GetFood()
    {
        
        foodAddText.text = "+1";
        iconsManager.Unlock(index);
        StartCoroutine(ClearText());
    }


    IEnumerator ClearText()
    {
        float initialFontSize = foodAddText.fontSize;
        for (int i = 0; i < 5; i++)
        {
            foodAddText.fontSize = foodAddText.fontSize + 40;

            yield return new WaitForSeconds(0.1f);
        }
        foodAddText.text = "";
        foodAddText.fontSize = initialFontSize;

    }
}
