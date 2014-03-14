using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ScreenshotUtils {

	//TODO: Verify if there is a folder before trying to export the image
	[MenuItem("Other/Screenshot")]
	public static void Screenshot(){
		string _name = "Screens/Screen_"+System.DateTime.Now.ToShortDateString().Replace('/', '.')+"-"+System.DateTime.Now.ToShortTimeString().Replace(":", ".").Replace(" ", "")+".png";
		Debug.Log("Saving screenshot " + _name);
		Application.CaptureScreenshot(_name);
	}

}
