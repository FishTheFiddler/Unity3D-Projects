using System;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class SpriteAnimator : MonoBehaviour 
{

	[SerializeField] private Sprite[] frameArray;
	private int currentFrame;
	private float timer;
	[SerializeField] private float frameRate = 0.1f;
	private SpriteRenderer spriteRenderer;
	private bool loop = true;
	private bool isPlaying = true;

	// Use this for initialization
	void Awake () 
	{
		spriteRenderer = gameObject.GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	private void Update () 
	{
		if (!isPlaying) 
		{
			return;
		}
		timer += Time.deltaTime;

		if (timer >= frameRate)
		{
			timer -= frameRate;
			currentFrame = (currentFrame +1) % frameArray.Length;
			if (!loop && currentFrame == 0)
			{
				StopPlaying();
			} else{
				spriteRenderer.sprite = frameArray[currentFrame];
			}
		}
	}

	private void StopPlaying()
	{
		isPlaying = false;
	}

	public void PlayAnimation(Sprite[] frameArray, float frameRate){
		this.frameArray = frameArray;
		this.frameRate = frameRate;
		currentFrame = 0;
		timer = 0f;
		spriteRenderer.sprite = frameArray[currentFrame];
	}
}
