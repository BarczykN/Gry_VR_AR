using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject decalPrefab;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Spawn Decal");
        ContactPoint hit = collision.GetContact(0);
        GameObject hole = Instantiate(decalPrefab, 
            hit.point + hit.normal * 0.001f,
            Quaternion.LookRotation(-hit.normal)
            );

        
        Destroy(hole, 10f);
        Destroy(this.gameObject);
    }
}
