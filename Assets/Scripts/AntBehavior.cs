using UnityEngine;
using System.Collections;

public class AntBehavior : MonoBehaviour {
	float speed = 0.2f;
	public int direction = 1;
	GameObject target;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (direction == 1) {
			gameObject.transform.rotation = Quaternion.Euler (new Vector3 (0, 0, 0));
			gameObject.transform.position = new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y + speed, gameObject.transform.position.z);
			//gameObject.transform.localScale = new Vector3(-gameObject.transform.localScale.x, gameObject.transform.localScale.y+ speed, gameObject.transform.localScale.z );
		} else if (direction == 2) {
			gameObject.transform.rotation = Quaternion.Euler (new Vector3 (0, 0, -90));
			gameObject.transform.position = new Vector3 (gameObject.transform.position.x + speed, gameObject.transform.position.y, gameObject.transform.position.z);
		}else if (direction == 3) {
			gameObject.transform.rotation = Quaternion.Euler (new Vector3 (0, 0, 180));
			gameObject.transform.position = new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y - speed, gameObject.transform.position.z);
		}else if (direction == 4) {
			gameObject.transform.rotation = Quaternion.Euler (new Vector3 (0, 0, 90));
			gameObject.transform.position = new Vector3 (gameObject.transform.position.x - speed, gameObject.transform.position.y, gameObject.transform.position.z);
		}


	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Scenario") {
			if (direction == 1) {
				if (Random.value <= 0.5) {
					direction = 4;
				} else {
					direction = 2;
				}
			} else if (direction == 2) {
				if (Random.value <= 0.5) {
					direction = 1;
				} else {
					direction = 3;
				}
			}else if (direction == 3) {
				if (Random.value <= 0.5) {
					direction = 4;
				} else {
					direction = 2;
				}
			}else if (direction == 4) {
				if (Random.value <= 0.5) {
					direction = 1;
				} else {
					direction = 3;
				}
			}
		}

		if (other.gameObject.tag == "Ant" ||other.gameObject.tag == "gb" ) {
			Physics2D.IgnoreCollision (other.gameObject.GetComponent<BoxCollider2D> (), gameObject.GetComponent<BoxCollider2D> ());
		}
	}
}
