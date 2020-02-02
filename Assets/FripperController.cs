using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour {

	private HingeJoint myHingeJoint;

	//初期の傾き
	private float defaultAngle = 20;
	//弾いた時の傾き
	private float flickAngle = -20;



	// Use this for initialization
	void Start () {
		this.myHingeJoint = GetComponent<HingeJoint>();

		SetAngle(this.defaultAngle);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.LeftArrow) && tag =="LeftFripperTag"){
			SetAngle (this.flickAngle);
			//Debug.Log ("L D");
		}
		if (Input.GetKeyDown(KeyCode.RightArrow) && tag =="RightFripperTag"){
			SetAngle (this.flickAngle);
			//Debug.Log ("R D");
		}
		if (Input.GetKeyUp(KeyCode.LeftArrow) && tag =="LeftFripperTag"){
			SetAngle (this.defaultAngle);
			//Debug.Log ("L U");
		}
		if (Input.GetKeyUp (KeyCode.RightArrow) && tag == "RightFripperTag") {
			SetAngle (this.defaultAngle);
			//Debug.Log ("R U");
		} 
	

		if (Input.touchCount > 0) {
			Touch[] myTouches = Input.touches;
			for (int i = 0; i < myTouches.Length; i++) {

				if (myTouches [i].phase == TouchPhase.Began) {
					// タッチ開始
	
					if (myTouches [i].position.x < Screen.width / 2 && tag == "LeftFripperTag") {
						SetAngle (this.flickAngle);
						//Debug.Log ("▼▼▼----------左" + i);
					} else if (myTouches [i].position.x >= Screen.width / 2 && tag == "RightFripperTag") {
						SetAngle (this.flickAngle);
						//Debug.Log ("▼▼▼----------右" + i);
					}
				} else if (myTouches [i].phase == TouchPhase.Ended) {
					// タッチ終了

					if (myTouches [i].position.x < Screen.width / 2 && tag == "LeftFripperTag") {
						SetAngle (this.defaultAngle);
						//Debug.Log (i + "左-----------▲▲▲");
					} else if (myTouches [i].position.x >= Screen.width / 2 && tag == "RightFripperTag") {
						SetAngle (this.defaultAngle);
						//Debug.Log (i + "右-----------▲▲▲");
					}
				}
			}
		}
		if (Input.touchCount == 0 && !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow) ) {
			SetAngle (this.defaultAngle);
		}

	}

	public void SetAngle(float angle){
		JointSpring jointSpr = this.myHingeJoint.spring;
		jointSpr.targetPosition = angle;
		this.myHingeJoint.spring = jointSpr;
	}
}
