using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {
	public float speed = 0.1f;
	public float jumpSpeed = 3f;
	public float jumpUpgradeDuration = 5f;
	bool playerAlreadyDead = false;
	bool canMove = false;

	public AudioSource coinAudioSource;
	public AudioSource dieAudioSource;

	Rigidbody myRigidBody;
	bool isOnFloor;
	bool pressedJump = false;

	// Use this for initialization
	void Start() {
		myRigidBody = GetComponent<Rigidbody>();
		Invoke("SetCanMove", 2f);
	}

	private void SetCanMove()
	{
		if(canMove)
		{
			canMove = false;
		} else
		{
			canMove = true;
		}
	}


	private void FixedUpdate()
	{
		if(canMove)
		{
			RunHandler();
			JumpHandler();
		}

	}

	private void RunHandler() {
		float moveVertical;
		float moveHorizontal;

		#if UNITY_EDITOR || UNITY_STANDALONE_WIN || UNITY_WEBGL
		moveVertical = Input.GetAxis("Vertical");
		moveHorizontal = Input.GetAxis("Horizontal");
		#endif

		Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
		myRigidBody.MovePosition(transform.position + (movement * speed));
	}

	private void JumpHandler()
	{
		float jumpAxis = Input.GetAxis("Jump");
		bool isJumping = CrossPlatformInputManager.GetButton("Jump");

		if(jumpAxis > 0f || isJumping)
		{
			if(isOnFloor && !pressedJump)
			{
				isOnFloor = false;
				pressedJump = true;
				Vector3 jumpVector = new Vector3(0f, jumpSpeed, 0f);

				myRigidBody.velocity = myRigidBody.velocity + jumpVector;
			}
		} else {
			pressedJump = false;
		}
	}

	private void JumpSpeedNormal()
	{
		jumpSpeed = jumpSpeed * (1 / 1.5f);
	}

	private void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.tag == "Floor")
		{
			isOnFloor = true;
		} else if(col.gameObject.tag == "Enemy")
		{
			if(col.contacts[0].point.y < transform.position.y)
			{
				Vector3 enemySize = col.transform.localScale;
				col.transform.localScale -= new Vector3(0, col.transform.localScale.y / 2, 0);
				col.gameObject.tag = "Untagged";

				EnemyController ec = col.gameObject.GetComponent<EnemyController>();
				ec.moveSide = false;
				ec.moveUp = false;
				ec.moveForward = false;

				Destroy(col.gameObject, 2f);
				GameManager.instance.AddScore(3);
			}
			else
			{
				canMove = false;
				PlayDieSound();
				playerAlreadyDead = true;

				Invoke("GameOver", 5f);
			}
		}
	}

	private void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.tag == "Coin")
		{
			PlayCoinSound();
		} else if(col.gameObject.tag == "Goal")
		{
			GameManager.instance.NextLevel();
		}
	}

	public void PlayCoinSound()
	{
		if (StaticClass.sound) {
			coinAudioSource.Play ();
		}
	}

	private void PlayDieSound()
	{
		if(playerAlreadyDead == false)
		{
			if (StaticClass.sound) {
				dieAudioSource.Play ();
			}
		}

	}

	private void GameOver()
	{
		SceneManager.LoadScene("GameOver");
	}
}
