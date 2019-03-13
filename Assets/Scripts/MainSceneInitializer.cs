using UnityEngine;

public class MainSceneInitializer : MonoBehaviour
{
    [Header("shipVariables")] [SerializeField]
    private GameObject shipPrefab;

    [SerializeField] private float shipSpeed;
    [SerializeField] private Vector2 shipStartingPos;

    [Header("MapConstrainst")] 
    [SerializeField] private float xMapConstraint;
    [SerializeField] private float yMapConstraint;

    [Header("MeteorVariables")]
    [SerializeField] private GameObject meteorPrefab;
    [SerializeField] private float spawnTime;
    [SerializeField] private float minMeteoSpeed, maxMeteoSpeed;
    
    private void Awake()
    {
        CreateShip();
        
        MeteorSpawner meteorSpawner = new MeteorSpawner(meteorPrefab, spawnTime,
            minMeteoSpeed,maxMeteoSpeed,xMapConstraint,yMapConstraint, -yMapConstraint,
            0.01f);
        
    }

    private void CreateShip()
    {
        GameObject ship = Instantiate(shipPrefab);
        IInputWrapper inputWrapper =
            new InputWrapperWithConstraints(ship.transform, xMapConstraint,
                yMapConstraint);

        ship.GetComponent<ShipController>().Initalize(shipSpeed, inputWrapper);
        ship.transform.position = shipStartingPos;
    }
}