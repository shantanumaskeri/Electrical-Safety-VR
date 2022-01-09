using UnityEngine;

public class ObjectRotation : MonoBehaviour
{

    public float maxSpeed = 30.0f;

    private float speed = 0.0f;

    private void Update()
    {
        if (speed < maxSpeed)
        {
            speed += Time.deltaTime;
        }
        
        transform.Rotate(0.0f, 0.0f, speed);
    }
}
