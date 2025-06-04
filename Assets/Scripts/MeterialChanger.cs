using UnityEngine;
using UnityEngine.EventSystems;
// System.Diagnostics와 Unity.VisualScripting은 현재 코드에서 사용되지 않으므로 주석 처리하거나 삭제해도 됩니다.
// using System.Diagnostics;
// using Unity.VisualScripting;

public class MaterialChanger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public Material baseMaterial;
    public Material selectedMaterial;
    public AudioClip clip;

    public GameObject particle;
    public Mesh[] shapes = new Mesh[2]; // 인스펙터에서 2개의 메쉬를 할당해야 합니다.
    // public OnMove moce; // OnMove 타입이 정의되어 있지 않고 사용되지 않으므로 주석 처리합니다. 필요하다면 정의를 추가하세요.

    [SerializeField]
    private Renderer objRenderer; // 변수 이름을 renderer에서 objRenderer로 변경 (UnityEngine.Renderer와 혼동 방지)
    private AudioSource source;
    private MeshFilter filter;
    private int index = 0;

    void Start()
    {
        // Renderer 컴포넌트 가져오기
        objRenderer = GetComponent<Renderer>();
        if (objRenderer == null)
        {
            Debug.LogError("Renderer 컴포넌트를 찾을 수 없습니다!");
        }
        else
        {
            objRenderer.material = baseMaterial;
        }

        // AudioSource 컴포넌트 가져오기
        source = GetComponent<AudioSource>();
        if (source == null)
        {
            Debug.LogError("AudioSource 컴포넌트를 찾을 수 없습니다!");
        }

        // MeshFilter 컴포넌트 가져오기 및 초기 메쉬 설정
        filter = GetComponent<MeshFilter>();
        if (filter == null)
        {
            Debug.LogError("MeshFilter 컴포넌트를 찾을 수 없습니다!");
        }
        else
        {
            // shapes 배열과 초기 메쉬가 할당되어 있는지 확인
            if (shapes != null && shapes.Length > index && shapes[index] != null)
            {
                filter.mesh = shapes[index];
            }
            else
            {
                Debug.LogError("Shapes 배열이 제대로 설정되지 않았거나 초기 메쉬가 없습니다. 인스펙터에서 확인해주세요.");
            }
        }

        // 파티클이 할당되어 있다면 초기에는 비활성화
        if (particle != null)
        {
            particle.SetActive(false);
        }
        else
        {
            Debug.LogWarning("Particle GameObject가 할당되지 않았습니다.");
        }
    }

    // Update 함수는 Start 함수 바깥에 있어야 합니다.
    void Update()
    {
        // 필요한 경우 프레임마다 실행될 로직을 여기에 작성합니다.
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (objRenderer != null && selectedMaterial != null)
        {
            objRenderer.material = selectedMaterial;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (objRenderer != null && baseMaterial != null)
        {
            objRenderer.material = baseMaterial;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // 파티클 토글
        if (particle != null)
        {
            particle.SetActive(!particle.activeSelf);
        }

        // 사운드 재생
        if (source != null && clip != null)
        {
            source.PlayOneShot(clip);
        }

        // 메쉬 변경 로직
        if (filter != null && shapes != null && shapes.Length > 0)
        {
            index++;
            if (index >= shapes.Length) // 배열의 길이를 초과하지 않도록 수정
            {
                index = 0;
            }

            if (shapes[index] != null)
            {
                filter.mesh = shapes[index];
            }
            else
            {
                Debug.LogError($"Shapes 배열의 {index} 인덱스에 메쉬가 할당되지 않았습니다.");
            }
        }
        else
        {
            Debug.LogError("MeshFilter 또는 Shapes 배열이 제대로 설정되지 않아 메쉬를 변경할 수 없습니다.");
        }
    }
}
