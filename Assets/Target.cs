using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] TargetManager manager;
    public int score = 10;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            manager.AddScore(score);
        }
        
    }
}
