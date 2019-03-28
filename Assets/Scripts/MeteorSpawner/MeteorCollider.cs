using System;
using UnityEngine;

public class MeteorCollider : MonoBehaviour , ICollider
{
    private Action<GameObject> onCollision;

    public void Initialize(Action<GameObject> onCollison)
    {
        this.onCollision += onCollison;
    }

    public void TriggerCollision()
    {
        StopAllCoroutines();
        onCollision.Invoke(gameObject);
    }
}
