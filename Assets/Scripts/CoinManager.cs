using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public GameObject coin;
    public Transform[] positions;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (positions.Length == 0)
        {
            return;
        }
        foreach (var trans in positions)
        {
            GameObject.Instantiate<GameObject>(coin, trans.position, trans.rotation);
        }
    }
}
