using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

	Material myMaterial;

	private int SmallStarScore  =10;
	private int LargeStarScore = 20;
	private int SmallCloudScore = 20;
	private int LargeCloudScore = 50;

	private int ScoreSum = 0;

	private GameObject scoreText;

	// Use this for initialization
	void Start () {
		this.scoreText = GameObject.Find("ScoreText");
	}

	// Update is called once per frame
	void Update () {
		this.scoreText.GetComponent<Text>().text="Score : " + ScoreSum;
	}

	//衝突時に呼ばれる関数
	void OnCollisionEnter(Collision other) {
		//Debug.Log ("Score : " + ScoreSum);
		if (other.gameObject.tag == "SmallStarTag") {
			ScoreSum += SmallStarScore;
			//Debug.Log ("Score : " + ScoreSum);

		} else if (other.gameObject.tag == "LargeStarTag") {
			ScoreSum += LargeStarScore;
			//Debug.Log ("Score : " + ScoreSum);

		} else if (other.gameObject.tag == "SmallCloudTag") {
			ScoreSum += SmallCloudScore;
			//Debug.Log ("Score : " + ScoreSum);

		} else if (other.gameObject.tag == "LargeCloudTag") {
			ScoreSum += LargeCloudScore;
			//Debug.Log ("Score : " + ScoreSum);
		}
	}
}