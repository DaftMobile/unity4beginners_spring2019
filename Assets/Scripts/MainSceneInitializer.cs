using UnityEngine;

public class MainSceneInitializer : MonoBehaviour
{
    [SerializeField] private GameObject shipPrefab;

    private void Awake()
    {
    }

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject ship = Instantiate(shipPrefab);
            ship.transform.position = new Vector3(
                Random.Range(-10, 10),
                Random.Range(-5, 5),
                0);
        }
    }
}