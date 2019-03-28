using System.Collections;
using UnityEngine;

public class MeteorSpawner : IMeteorSpawner
{
    private GameObject meteorPrefab;
    private float spawnTime;
    private float minMeteoSpeed, maxMeteoSpeed;
    private float xSpawn, xMin, yMax, yMin;
    private float timeSpeedUp;
    private ICoroutineRunner coroutineRunner;
    private ObjectPoool objectPoool;

    public MeteorSpawner(GameObject meteorPrefab, float spawnTime, float minMeteoSpeed,
        float maxMeteoSpeed, float xSpawn,float xMin, float yMax, float yMin, float timeSpeedUp, 
        ICoroutineRunner coroutineRunner, ObjectPoool objectPoool)
    {
        this.meteorPrefab = meteorPrefab;
        this.spawnTime = spawnTime;
        this.minMeteoSpeed = minMeteoSpeed;
        this.maxMeteoSpeed = maxMeteoSpeed;
        this.xSpawn = xSpawn;
        this.yMax = yMax;
        this.yMin = yMin;
        this.xMin = xMin;
        this.timeSpeedUp = timeSpeedUp;
        this.coroutineRunner = coroutineRunner;
        this.objectPoool = objectPoool;

        coroutineRunner.StartCoroutine(SpawnMeteosInLoop());
    }

    IEnumerator SpawnMeteosInLoop()
    {
        while (true)
        {
            GameObject meteo = GameObject.Instantiate(meteorPrefab);
            IInputWrapper meteoInput = new AlwaysLeftInputWrapper();
            
            meteo.GetComponent<MeteorCollider>().Initialize(OnMeteorCollisionAction);
            ShipController shipcontroller = meteo.GetComponent<ShipController>();
            shipcontroller.Initalize(GetRandomSpeed(), meteoInput);
            shipcontroller.StartCoroutine(DestroyMeteorAfterBoundary(shipcontroller.gameObject));
            meteo.transform.position = new Vector3(xSpawn, GetRandomYPosition(), 0f);
            yield return new WaitForSeconds(spawnTime);
        }
    }

    private void OnMeteorCollisionAction(GameObject meteor)
    {
        spawnTime = Mathf.Max(spawnTime - timeSpeedUp, 0.01f);    
        GameObject.Destroy(meteor);
    }
    
    IEnumerator DestroyMeteorAfterBoundary(GameObject meteo)
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            if (meteo.transform.position.x < xMin)
            {
                GameObject.Destroy(meteo);
            }
        }
    }

    private float GetRandomSpeed()
    {
        return Random.RandomRange(minMeteoSpeed, maxMeteoSpeed);
    }

    private float GetRandomYPosition()
    {
        return Random.RandomRange(yMin, yMax);
    }
}