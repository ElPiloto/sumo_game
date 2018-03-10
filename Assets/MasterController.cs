using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectIterator {

	public ObjectIterator(){
	}

	public abstract GameObject Dequeue(); 
}

public class SequenceOfBagsIterator : ObjectIterator {

	private List<List<GameObject>> bags;
	private List<GameObject> currentBag;
	private int currentBagIndex = -1;

	public SequenceOfBagsIterator() {
		if (bags == null) {
			bags = new List<List<GameObject>>();
			currentBagIndex = -1;
		}
	}

	public void AddToBag(GameObject go) {
		bags[currentBagIndex].Add(go);
	}

	public void MakeNewBag() {
		bags.Add(new List<GameObject>());
		currentBagIndex++;
	}

	public void AddBag(List<GameObject> bag) {
		bags.Add(bag);
		currentBagIndex++;
	}

	public void AddBagToCurrentBag(List<GameObject> l) {
		//TODO: implement
	}

	public override GameObject Dequeue() {
		if (currentBagIndex >= 0 && bags[currentBagIndex].Count == 0) {
			currentBagIndex--;
		}

		if (currentBagIndex >= 0 && bags[currentBagIndex].Count > 0 && currentBagIndex >= 0) {
			List<GameObject> l = bags[currentBagIndex];
			GameObject retVal = l[Random.Range(0,bags[currentBagIndex].Count)];
			l.Remove(retVal);
			return retVal;
		}
		return null;
	}
}

public class MasterController : MonoBehaviour {

	private float startTime;
	public Material stageMaterial;
	private GameObject top, centerTile, bottom, left, right;
	//Dropping
	private SequenceOfBagsIterator droppables;
	private int direction = -1;
	private bool doneDropping = false;
	//Shaking
	private bool isShaking = false;
	private GameObject shaking;
	private float startShakeTime;
	private float shakeDuration = 0.5f;
	private float shakeDelta = 0.1f;
	// Timing
	public float dropTime = 6.0f;
	public float delayBetweenDrops = 6.0f;
	private int numDropped = 0;

	List<GameObject> MakeOuterRing(float existingDiameter, float ringWidth) {
		GameObject top, left, right, bottom;
		float x = existingDiameter;
		float w = ringWidth;

		left = GameObject.CreatePrimitive(PrimitiveType.Cube);
		SetRotation(left);
		left.transform.position = new Vector3(-0.5f*(x+w),0,0);
		left.transform.localScale = new Vector3(w,x,0.1f);

		right = GameObject.CreatePrimitive(PrimitiveType.Cube);
		SetRotation(right);
		right.transform.position = new Vector3(0.5f*(x+w),0,0);
		right.transform.localScale = new Vector3(w,x,0.1f);

		top = GameObject.CreatePrimitive(PrimitiveType.Cube);
		SetRotation(top);
		top.transform.position = new Vector3(0,0,0.5f*(x+w));
		top.transform.localScale = new Vector3(2.0f*w+x,w,0.1f);

		bottom = GameObject.CreatePrimitive(PrimitiveType.Cube);
		SetRotation(bottom);
		bottom.transform.position = new Vector3(0,0,-0.5f*(x+w));
		bottom.transform.localScale = new Vector3(2.0f*w+x,w,0.1f);

		SetMaterial(top);
		SetMaterial(bottom);
		SetMaterial(left);
		SetMaterial(right);
		List<GameObject> ringGameObjects = new List<GameObject>();
		ringGameObjects.Add(top);
		ringGameObjects.Add(bottom);
		ringGameObjects.Add(left);
		ringGameObjects.Add(right);
		return ringGameObjects;
	}
	void Start () {
		droppables = new SequenceOfBagsIterator();
		startTime = Time.time;
		float x = 2.0f;

		centerTile = GameObject.CreatePrimitive(PrimitiveType.Cube);
		centerTile.transform.localScale = new Vector3(x,x,0.1f);
		SetRotation(centerTile);
		SetMaterial(centerTile);

		List<GameObject> ring1 = MakeOuterRing(x,1.0f);
		List<GameObject> ring2 = MakeOuterRing(4.0f,1.0f);
		List<GameObject> ring3 = MakeOuterRing(6.0f,1.0f);
		droppables.AddBag(ring1);
		droppables.AddBag(ring2);
		droppables.AddBag(ring3);
	}

	private void SetRotation(GameObject gameObject) {
		gameObject.transform.rotation = Quaternion.AngleAxis(90, Vector3.right);
	}

	private void SetMaterial(GameObject go) {
        Renderer rend = go.GetComponent<Renderer>();
        rend.material = stageMaterial;
	}

	/* 
	public static GameObject MakeSymmetricCube(float diameter) {
		GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
		go.transform.localScale = new Vector3(diameter, diameter, diameter);
		return go;
	}
	public static void CenterObject(GameObject go) {
		Vector3 origPos = go.transform.position;
		Vector3 scale = go.transform.localScale;
		Vector3 newPos = new Vector3(-scale.x /2.0f, origPos.y, -scale.z/2.0f);
		go.transform.position = newPos;
	}
	//Cubes have different mappings between coordinates and scale
	public static void CenterCube(GameObject go) {
		Vector3 origPos = go.transform.position;
		Vector3 scale = go.transform.localScale;
		Vector3 newPos = new Vector3(-scale.x /2.0f, origPos.y, -scale.y/2.0f);
		go.transform.position = newPos;
	}*/

	void ShakeGameObject(){
		if (!isShaking) {
			shaking = droppables.Dequeue();
			if (shaking == null) {
				doneDropping = true;
				return;
			}

			// this is the start of shaking
			isShaking = true;
			startShakeTime = Time.time;

			SetColor(shaking);
			
		}
		direction = direction * -1;
		//actually do the shaking
		shaking.transform.position += new Vector3(0.0f, direction*shakeDelta, 0.0f);
		if (Time.time - startShakeTime > shakeDuration) {
			isShaking = false;
		}
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Time.time  > (dropTime+numDropped*delayBetweenDrops) && !doneDropping) {
			bool wasShaking = isShaking;
			ShakeGameObject();
			if (wasShaking && !isShaking) {
				MakeObjectFall(shaking);
				numDropped++;
			}
		}
	}

	void MakeObjectFall(GameObject ob) {
		Rigidbody gameObjectsRigidBody = ob.AddComponent<Rigidbody>();
		gameObjectsRigidBody.useGravity = true;
	}

	void SetColor(GameObject ob) {
		Renderer rend = ob.GetComponent<Renderer>();
        rend.material.SetColor("_Color", Color.red);
	}
}
