using System.Collections;
using UnityEngine;


public class ChearingCrowdTurn360 : MonoBehaviour, IChearingCrowd
{
    
    public bool IsFinished { get { return IsRuning(); } }

    private Coroutine corutine;
    private float time =0;
    
    public void Chear()
    {
        corutine = StartCoroutine(DoTheTurnAround());
    }

    private IEnumerator DoTheTurnAround()
    {
        time = 0;
        while (time < 1)
        {
            transform.Rotate(Vector3.up * 180 * Time.deltaTime);
            time = time + Time.deltaTime;
            yield return null;
        }
        
        transform.rotation = Quaternion.identity;
        time = 0;
    }

    private bool IsRuning()
    {
        return time == 0;
    }
}