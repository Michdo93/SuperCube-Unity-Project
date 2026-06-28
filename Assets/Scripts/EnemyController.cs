using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
	public float moveDistance = 2f;
	public bool moveUp = false;
	public bool moveSide = true;
	public bool moveForward = false;

	Vector3 startingPos;
	Transform trans;
	bool isOnFloor;

	public float leftBorder = -1.5f;
	public float rightBorder = 1.5f;
	public float backBorder = 2.5f;
	public float frontBorder = 75.5f;

	// Use this for initialization
	void Start () {
		trans = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		if(isOnFloor) {
			if(moveUp)
			{
				trans.position = new Vector3(startingPos.x, startingPos.y + Mathf.PingPong(Time.time, moveDistance), startingPos.z);
			}

			if(moveSide)
			{
				float newPos;

				if ((startingPos.x + Mathf.PingPong (Time.time, moveDistance)) < leftBorder && (startingPos.x + Mathf.PingPong (Time.time, moveDistance)) > rightBorder) {
					newPos = startingPos.x + Mathf.PingPong (Time.time, moveDistance);
				} else {
					newPos = leftBorder;
				}

				trans.position = new Vector3(newPos-(transform.localScale.x/2), startingPos.y , startingPos.z);
			}

			if(moveForward) {
				float newPos;

				if (startingPos.z + Mathf.PingPong (Time.time, moveDistance) < frontBorder && startingPos.z + Mathf.PingPong (Time.time, moveDistance) > backBorder) {
					newPos = startingPos.z + Mathf.PingPong (Time.time, moveDistance);
				} else {
					if ((startingPos.z - moveDistance) < backBorder) {
						newPos = backBorder + (transform.localScale.z / 2);
					} else if ((startingPos.z + moveDistance) > frontBorder) {
						newPos = frontBorder - (transform.localScale.z / 2);
					} else {
						newPos = (startingPos.z + Mathf.PingPong (Time.time, moveDistance)) - transform.localScale.z;
					}
				}
					
				trans.position = new Vector3 (startingPos.x, startingPos.y, startingPos.z  + Mathf.PingPong (Time.time, startingPos.z-newPos));
			}

			if(moveSide && moveForward)
			{
				float newPosX;
				float newPosZ;

				if ((startingPos.x + Mathf.PingPong (Time.time, moveDistance)) < leftBorder && (startingPos.x + Mathf.PingPong (Time.time, moveDistance)) > rightBorder) {
					newPosX = startingPos.x + Mathf.PingPong (Time.time, moveDistance);
				} else {
					newPosX = leftBorder;
				}

				if (startingPos.z + Mathf.PingPong (Time.time, moveDistance) < frontBorder && startingPos.z + Mathf.PingPong (Time.time, moveDistance) > backBorder) {
					newPosZ = startingPos.z + Mathf.PingPong (Time.time, moveDistance);
				} else {
					if ((startingPos.z - moveDistance) < backBorder) {
						newPosZ = backBorder + (transform.localScale.z / 2);
					} else if ((startingPos.z + moveDistance) > frontBorder) {
						newPosZ = frontBorder - (transform.localScale.z / 2);
					} else {
						newPosZ = (startingPos.z + Mathf.PingPong (Time.time, moveDistance)) - transform.localScale.z;
					}
				}

				trans.position = new Vector3(newPosX-(transform.localScale.x/2), startingPos.y, startingPos.z  + Mathf.PingPong (Time.time, startingPos.z-newPosZ));
			}
		}
	}

	private void OnCollisionEnter(Collision col) {
		if(col.gameObject.tag == "Floor") {
			isOnFloor = true;
			startingPos = trans.position;
		}
	}
}
