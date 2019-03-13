using System.Collections;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    private float ShipSpeed;
    private IInputWrapper inputWrapper;

    public void Initalize(float shipSpeed, IInputWrapper inputWrapper)
    {
        ShipSpeed = shipSpeed;
        this.inputWrapper = inputWrapper;
    }

    // Update is called once per frame
    void Update()
    {
        MoveShip(KeyCode.A, Vector3.left);
        MoveShip(KeyCode.W, Vector3.up);
        MoveShip(KeyCode.S, Vector3.down);
        MoveShip(KeyCode.D, Vector3.right);

        
    }

    private void MoveShip(KeyCode code, Vector3 direction)
    {
        if (inputWrapper.GetKey(code))
        {
            Debug.Log("im in" + direction + " " + ShipSpeed);
            transform.position += direction * Time.deltaTime * ShipSpeed;
        }
    }
}
