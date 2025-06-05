using UnityEngine;

public class Jump : MonoBehaviour
{
    private float power = 1000;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            var rb = collision.gameObject.GetComponent<Rigidbody>();
            rb.AddForce(Vector3.up * power);
        }
    }
    // private void CollisionStay(Collision collision)
    // {
    //     if (collision.gameObject.name == "Player")
    //     {

    //     }
    // }
    //     private void CollisionExit(Collision collision)
    // {
    //     if (collision.gameObject.name == "Player")
    //     {

    //     }
    // }
}
