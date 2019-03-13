using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlwaysLeftInputWrapper : IInputWrapper {

	public bool GetKey(KeyCode code)
	{
		return code == KeyCode.A;
	}
}
