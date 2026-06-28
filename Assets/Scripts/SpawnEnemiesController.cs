using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemiesController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		float numberOfEnemies = Random.Range(10, 20);
		GameObject prefabEnemy = Resources.Load ("Enemy") as GameObject;

		for(int i = 0; i <= numberOfEnemies; i++) {
			float xPos = Random.Range(-1, 1);
			float zPos = Random.Range(15, 60);
			float attribute = Random.Range (1, 10);

			GameObject enemy = Instantiate (prefabEnemy);

			if(attribute >= 6) {
				enemy.GetComponent<EnemyController> ().moveUp = false;
				enemy.GetComponent<EnemyController> ().moveSide = true;
				enemy.GetComponent<EnemyController> ().moveForward = false;
			} else if(attribute >= 3) {
				enemy.GetComponent<EnemyController> ().moveUp = true;
				enemy.GetComponent<EnemyController> ().moveSide = false;
				enemy.GetComponent<EnemyController> ().moveForward = false;
			} else if(attribute >= 2) {
				enemy.GetComponent<EnemyController> ().moveUp = false;
				enemy.GetComponent<EnemyController> ().moveSide = true;
				enemy.GetComponent<EnemyController> ().moveForward = true;
			} else {
				enemy.GetComponent<EnemyController> ().moveUp = true;
				enemy.GetComponent<EnemyController> ().moveSide = false;
				enemy.GetComponent<EnemyController> ().moveForward = false;
			}

			Transform trans = enemy.GetComponent<Transform> ();
			trans.position = new Vector3(xPos, 15f, zPos);
		}
	}
}
