using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class gameHandler : MonoBehaviour {

	[SerializeField] private SpriteAnimator spriteAnimator;

	// [SerializeField] private Sprite[] idleAnimationFrameArray;
	[SerializeField] private Sprite[] runAnimationFrameArray;
	[SerializeField] private Sprite[] jumpAnimationFrameArray;
	// Player isGrounded = gameObj.GetComponent<Player>();


	private enum AnimationType {
		idle,
		run,
		jump,
	}
	private AnimationType activeAnimationType;


	private void Start () {
		PlayAnimation(AnimationType.run);
	}
	
	// Update is called once per frame
	private void Update () {
		if (Input.GetKey(KeyCode.UpArrow)) {

		}


	}

	private void PlayAnimation (AnimationType animationType){
		if (animationType != activeAnimationType) {
			activeAnimationType = animationType;
			switch (animationType) {
			case AnimationType.run:
				spriteAnimator.PlayAnimation (runAnimationFrameArray, 0.1f);
				break;
			case AnimationType.jump:
				spriteAnimator.PlayAnimation (jumpAnimationFrameArray, 0.1f);
				break;
			}
		}


	}

}
