using UnityEngine;

public class Rotater : MonoBehaviour
{
    public Vector3 direction;
    public float speed;


    void Update()
    {
        transform.Rotate(direction * speed * Time.deltaTime);
    }
}
