using UnityEngine;

public class MaterialChanger : MonoBehaviour
{
    public Material baseMaterial;
    public Material selectedMaterial;
    [SerializeField]
    private Renderer renderer;

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
