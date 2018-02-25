using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		float centerDiameter = 5.0f;
		GameObject centerTile = MakeSymmetricQuad(centerDiameter);
		//SetRotation(centerTile);
		SurroundSquare(centerDiameter,2.5f);
	}

	private void SurroundSquare(float existingDiameter, float newDiameter) {
		float sideWidths = Mathf.Abs(newDiameter - existingDiameter);
		float topWidths = sideWidths;
		// left
		 
		 /*
		GameObject left = GameObject.CreatePrimitive(PrimitiveType.Quad);
		left.transform.localScale = new Vector3(sideWidths, existingDiameter, existingDiameter);
		GameObject right = GameObject.CreatePrimitive(PrimitiveType.Quad);
		right.transform.localScale = new Vector3(sideWidths, existingDiameter, existingDiameter);
		SetRotation(left);
		left.transform.position = new Vector3(-existingDiameter/2.0f+sideWidths/2.0f, 0.0f, 0.0f);
		right.transform.position = new Vector3(existingDiameter/2.0f-sideWidths/2.0f, 0.0f, 0.0f);
		SetRotation(right);
		*/
		

		GameObject top = GameObject.CreatePrimitive(PrimitiveType.Quad);
		top.transform.localScale = new Vector3(existingDiameter, sideWidths, sideWidths);

		GameObject bottom = GameObject.CreatePrimitive(PrimitiveType.Quad);
		bottom.transform.localScale = new Vector3(existingDiameter, sideWidths, sideWidths);

		SetRotation(top);
		top.transform.position = new Vector3(0.0f, 0.0f, -existingDiameter+sideWidths/2.0f);
		bottom.transform.position = new Vector3(0.0f, 0.0f, existingDiameter-sideWidths/2.0f);
		SetRotation(bottom);
	}

	private void SetRotation(GameObject gameObject) {
		gameObject.transform.rotation = Quaternion.AngleAxis(90, Vector3.right);
	}

	public static GameObject MakeSymmetricQuad(float diameter) {
		GameObject go = GameObject.CreatePrimitive(PrimitiveType.Quad);
		go.transform.localScale = new Vector3(diameter, diameter, diameter);
		return go;
	}
	public static void CenterObject(GameObject go) {
		Vector3 origPos = go.transform.position;
		Vector3 scale = go.transform.localScale;
		Vector3 newPos = new Vector3(-scale.x /2.0f, origPos.y, -scale.z/2.0f);
		go.transform.position = newPos;
	}
	//Quads have different mappings between coordinates and scale
	public static void CenterQuad(GameObject go) {
		Vector3 origPos = go.transform.position;
		Vector3 scale = go.transform.localScale;
		Vector3 newPos = new Vector3(-scale.x /2.0f, origPos.y, -scale.y/2.0f);
		go.transform.position = newPos;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
