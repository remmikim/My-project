using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    // 인스턴스 이후 단 한번만 호출
    void Start()
    {
        Debug.Log("나 시작함");
    }

    //활성화 되어있는 동안 매 프레임동안 호출
    void Update()
    {
        Debug.Log($"{Time.frameCount} : Update!");
    }
    //활성화 되어 있는 동안 물리 업데이트 할 때마다 호출
    private void FixedUpdate()
    {
        
    }
}
