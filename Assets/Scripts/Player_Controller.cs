using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Controller : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed = 10f;
    public Vector2 direction = Vector2.zero;
    // 인스턴스 이후 단 한번만 호출
    void Start()
    {
        //Debug.Log("나 시작함");
        rb = GetComponent<Rigidbody>();
    }

    public void OnMove(InputValue value)
    {
        direction = value.Get <Vector2>();
    }

    //활성화 되어있는 동안 매 프레임동안 호출
    void Update()
    {
        Debug.Log($"{Time.frameCount} : Update!");
    }
    //활성화 되어 있는 동안 물리 업데이트 할 때마다 호출
    private void FixedUpdate()
    {
        rb.AddForce(new Vector3(direction.x, 0, direction.y) * speed);
    }
}
