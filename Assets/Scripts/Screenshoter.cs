using UnityEngine;
using System.Collections;

public class Screenshoter : MonoBehaviour {

	void Update () {
		if(Input.GetKeyDown(KeyCode.F6)){
			string _name = "Screens/tobago_"+System.DateTime.Now.ToShortDateString().Replace('/', '-')+"_"+System.DateTime.Now.ToLongTimeString().Replace(":", "-").Replace(' ', '_')+".png";
			print("Saving screenshot " + _name);
			Application.CaptureScreenshot(_name);
		}
	}
}
