using UnityEngine;

public class Pistol : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform shootPoint;
    public float bulletSpeed = 10f;
    public float bulletLifeTime = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        if(rb != null)
        {
            rb.linearVelocity = shootPoint.forward * bulletSpeed;
        }

        Destroy(bullet, bulletLifeTime);
    }
}
