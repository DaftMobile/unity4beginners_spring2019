using UnityEngine;

public class RotationgScript : MonoBehaviour
{
    [SerializeField] 
    private float rotationSpeed = 5f;

    [SerializeField] private GameObject otherObject;
    
    private RotationgScript rotationgScript;

    private BoxCollider boxy;
    
    //wywołuje sie zawsze raz przy stworzeniu obiektu,
    //odpaleniu projektu, załadowaniu sceny
    private void Awake()
    {
        
        rotationgScript = otherObject.GetComponent<RotationgScript>();
        boxy = gameObject.GetComponent<BoxCollider>();
        int x = 0;
    }
    //wywołuje sie zawsze raz przy stworzeniu obiektu,
    //odpaleniu projektu, załadowaniu sceny jesli obiekt jest aktywny
    private void Start()
    {
    }
    
    //Wywołuje się co klatkę
    //Time delta time uzywany w kazdej symulacji
    //mowi ile czsau miedzy jedna klatka a druga
    private void Update()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
    
    //Symulacja fizyki rzeczy w rownych odstepach czasu
    private void FixedUpdate()
    {
        
    }
}