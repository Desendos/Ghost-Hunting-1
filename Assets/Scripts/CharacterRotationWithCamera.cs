//Michael Bishop

using UnityEngine; 
using System.Collections; 
using System.Collections.Generic; 
 
public class CharacterRotationWithCamera : MonoBehaviour 
{
	void Update () 
    { 
		transform.rotation = Quaternion.Euler(0,transform.rotation.eulerAngles.y,0);
	}
}