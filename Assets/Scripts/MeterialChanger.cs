using System.Diagnostics;
using UnityEngine;
using UnityEngine.EventSystems;

public class MaterialChanger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public Material baseMaterial;
    public Material selectedMaterial;
    public AudioClip clip;

    public GameObject particle;
    public Mesh[] shapes = new Mesh[2];
    [SerializeField]
    private Renderer renderer;
    private AudioSource source;
    private MeshFilter filter;
    private int index = 0;

    public void OnPointerEnter(PointerEventData eventData)
    {
        renderer.material = selectedMaterial;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        renderer.material = baseMaterial;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        particle.SetActive(!particle.activeSelf);
        source.PlayOneShot(clip);
        if (++index > 1)
            index = 0;
        filter.mesh = shapes[index];
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        renderer = GetComponent<Renderer>();
        renderer.material = baseMaterial;
        source = GetComponent<AudioSource>();
        filter.mesh = shapes[index];


        // Update is called once per frame
        void Update()
        {

        }
    }
}
