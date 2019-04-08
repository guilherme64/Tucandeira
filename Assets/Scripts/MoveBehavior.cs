using UnityEngine;
using System.Collections;

public class MoveBehavior : MonoBehaviour {
	int gbNumber = 0;
	float speed = 0.1f;
	bool goUp;
	bool goDown;
	bool goLeft;
	bool goRight;
	public bool wasSeen = false;
	public Animator _anim;
	// Use this for initialization
	void Start () {
		
		goRight = true;
		goUp	= true;
		goDown	= true;
		goLeft	= true;
		_anim = gameObject.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKey (KeyCode.W)) {
			_anim.SetBool ("UP", true);//gambiarra feia do caralho, conserta essa porra depois
			_anim.SetBool ("DOWN", false);
			_anim.SetBool ("LEFT", false);
			_anim.SetBool ("RIGHT", false);
			gameObject.transform.position = new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y + speed, gameObject.transform.position.z);

		} else if (Input.GetKey (KeyCode.S)) {
			if (goDown) {
				//_anim.SetTrigger("Down");
				_anim.SetBool ("DOWN", true);
				_anim.SetBool ("UP", false);//gambiarra feia do caralho, conserta essa porra depois
				_anim.SetBool ("LEFT", false);
				_anim.SetBool ("RIGHT", false);
				//gameObject.GetComponent<Animator> ().SetBool("Down", true);
				gameObject.transform.position = new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y - speed, gameObject.transform.position.z);
			}
		} else if (Input.GetKey (KeyCode.A)) {
			if (goLeft == true) {
				//_anim.SetTrigger("Left");
				_anim.SetBool ("LEFT", true);
				_anim.SetBool ("UP", false);//gambiarra feia do caralho, conserta essa porra depois
				_anim.SetBool ("DOWN", false);
				_anim.SetBool ("RIGHT", false);
				//gameObject.GetComponent<Animator> ().SetBool("Left", true);
				gameObject.transform.position = new Vector3 (gameObject.transform.position.x - speed, gameObject.transform.position.y, gameObject.transform.position.z);
			}
		} else if (Input.GetKey (KeyCode.D)) {
			if (goLeft) {
				//_anim.SetTrigger("Right");	
				_anim.SetBool ("RIGHT", true);
				_anim.SetBool ("UP", false);//gambiarra feia do caralho, conserta essa porra depois
				_anim.SetBool ("DOWN", false);
				_anim.SetBool ("LEFT", false);

				//gameObject.GetComponent<Animator> ().SetBool("Right", true);
				gameObject.transform.position = new Vector3 (gameObject.transform.position.x + speed, gameObject.transform.position.y, gameObject.transform.position.z);
			}
		} else {
			_anim.SetTrigger("Stand");
			_anim.SetBool ("UP", false);//gambiarra feia do caralho, conserta essa porra depois
			_anim.SetBool ("DOWN", false);
			_anim.SetBool ("LEFT", false);
			_anim.SetBool ("RIGHT", false);
			//gameObject.GetComponent<Animator> ().SetBool("Up", false);
			//gameObject.GetComponent<Animator> ().SetBool("Right", false);
			//gameObject.GetComponent<Animator> ().SetBool("Left", false);
			//gameObject.GetComponent<Animator> ().SetBool("Down", false);
			//gameObject.GetComponent<Animator> ().SetTrigger("Stand");
		} /*else {
			gameObject.GetComponent<Animator>().SetBool("WisPressed", false);
			gameObject.GetComponent<Animator>().SetBool("SisPressed", false);
			gameObject.GetComponent<Animator>().SetBool("AisPressed", false);
			gameObject.GetComponent<Animator>().SetBool("DisPressed", false);
		}*/
	}


	void OnCollisionEnter2D(Collision2D other){
		Debug.Log ("bateu");
		if (other.gameObject.tag == "Ant") {
			Destroy (gameObject);
			LoadScene (1);
		}
		if (other.gameObject.tag == "gb") {
			Destroy (other.gameObject);

		}
	}

	public void LoadScene(int level){
		Application.LoadLevel(level);
	}
}
