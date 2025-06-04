using UnityEngine;

public class Dead_Zone : MonoBehaviour
{
    public Vector3 origin = new Vector3(0, 0.5f, 0);

    private void OggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            other.transform.position = origin;
            var rb = other.GetComponent<Rigidbody>();
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }      
    }
} 
