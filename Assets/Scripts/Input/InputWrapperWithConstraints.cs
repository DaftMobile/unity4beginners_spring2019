using UnityEngine;

public class InputWrapperWithConstraints : IInputWrapper
{
    private Transform shipTransform;
    private float xBound, yBound;

    public InputWrapperWithConstraints(Transform shipTransform, 
        float xBound, float yBound)
    {
        this.shipTransform = shipTransform;
        this.xBound = xBound;
        this.yBound = yBound;
    }

    public bool GetKey(KeyCode code)
    {
        if (Input.GetKey(code) && code == KeyCode.A)
        {
            return shipTransform.position.x > -xBound;
        }

        if (Input.GetKey(code) && code == KeyCode.D)
        {
            return shipTransform.position.x < xBound;
        }

        if (Input.GetKey(code) && code == KeyCode.W)
        {
            return shipTransform.position.y < yBound;
        }

        if (Input.GetKey(code) && code == KeyCode.S)
        {
            return shipTransform.position.y > -yBound;
        }

        return false;
    }
}