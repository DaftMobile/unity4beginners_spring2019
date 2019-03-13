using System.Collections;
using UnityEngine;

public class MeteorSpawner : IMeteorSpawner
{
    private GameObject meteorPrefab;
    private float spawnTime;
    private float minMeteoSpeed, maxMeteoSpeed;
    private float xSpawn, yMax, yMin;
    private float timeSpeedUp;

    public MeteorSpawner(GameObject meteorPrefab, float spawnTime, float minMeteoSpeed,
        float maxMeteoSpeed, float xSpawn, float yMax, float yMin, float timeSpeedUp)
    {
        this.meteorPrefab = meteorPrefab;
        this.spawnTime = spawnTime;
        this.minMeteoSpeed = minMeteoSpeed;
        this.maxMeteoSpeed = maxMeteoSpeed;
        this.xSpawn = xSpawn;
        this.yMax = yMax;
        this.yMin = yMin;
        this.timeSpeedUp = timeSpeedUp;

        //Zle Zle Zle singletony
        CorutinSingleton.instance.StartCoroutine(SpawnMeteosInLoop());
    }

    IEnumerator SpawnMeteosInLoop()
    {
        while (true)
        {
            GameObject meteo = GameObject.Instantiate(meteorPrefab);
            IInputWrapper meteoInput = new AlwaysLeftInputWrapper();

            meteo.GetComponent<ShipController>().Initalize(GetRandomSpeed(), meteoInput);
            meteo.transform.position = new Vector3(xSpawn, GetRandomYPosition(), 0f);
            
            yield return new WaitForSeconds(spawnTime);
            spawnTime = Mathf.Max(spawnTime - timeSpeedUp, 0.01f);
            
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