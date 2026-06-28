using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour {

	private void OnTriggerEnter(Collider other) {
		if(other.name == "Player") {
			gameObject.SendMessageUpwards ("getCoin", this.gameObject);	
		}
	}
}