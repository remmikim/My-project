using UnityEngine;
using UnityEngine.EventSystems;

public class MaterialChanger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Material baseMaterial;
    public Material selectedMaterial;
    [SerializeField]
    private Renderer renderer;

    public void OnPointerEnter(PointerEventData eventData)
    {
        renderer.material = selectedMaterial;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        renderer.material = baseMaterial;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        renderer = GetComponent<Renderer>();
        renderer.material = baseMaterial;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
