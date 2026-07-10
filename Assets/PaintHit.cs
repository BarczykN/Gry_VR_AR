using UnityEngine;

public class PaintHit : MonoBehaviour
{
    public Texture2D texture;

    public int size = 1024;


    Renderer rend;


    void Start()
    {
        rend = GetComponent<Renderer>();

        texture = new Texture2D(
            size,
            size
        );

        Color[] pixels =
            new Color[size * size];


        for (int i = 0; i < pixels.Length; i++)
            pixels[i] = Color.white;


        texture.SetPixels(pixels);
        texture.Apply();


        rend.material.mainTexture = texture;
    }



    public void Paint(Vector3 worldPoint)
    {

        Vector3 local =
            transform.InverseTransformPoint(worldPoint);


        // Quad Unity ma rozmiar 1x1
        // od -0.5 do +0.5

        float u = local.x + 0.5f;
        float v = local.y + 0.5f;


        int x =
            Mathf.RoundToInt(u * size);

        int y =
            Mathf.RoundToInt(v * size);


        texture.SetPixel(
            x,
            y,
            Color.red
        );


        texture.Apply();
    }
}

