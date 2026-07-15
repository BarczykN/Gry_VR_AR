using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    public List<Transform> targets;
    private List<Vector3> originalPostitions;
    private List<Quaternion> originalRotation;
    public int currentScore = 0;
    public TextMeshProUGUI scoreTextValue;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        originalPostitions = new List<Vector3>();
        originalRotation = new List<Quaternion>();
        foreach (Transform t in targets)
        {
            originalPostitions.Add(t.position);
            originalRotation.Add(t.rotation);
        }
    }

    public void AddScore(int score)
    {
        currentScore = currentScore + score;
        scoreTextValue.text = currentScore.ToString();
    }

    public void RestartTargets()
    {
        currentScore = 0;
        scoreTextValue.text = currentScore.ToString();
        int index = 0;
        foreach (Transform t in targets)
        {
            Rigidbody rb = t.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.linearVelocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                rb.Sleep();
            }

            t.position = originalPostitions[index];
            t.rotation = originalRotation[index];
            index++;
        }

    }
}
