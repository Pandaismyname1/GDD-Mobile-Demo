using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SocialRecordLeaderboardEvent : MonoBehaviour {

	public string LeaderboardId;
	private DateTime lastDate;
	private int seconds = 0;

	void Start()
	{
		DontDestroyOnLoad (gameObject);
		lastDate = DateTime.Now;
	}

	private void Update()
	{
		if ((DateTime.Now - lastDate).Seconds >= 5) {
			seconds+=5;
			Social.ReportScore (seconds, LeaderboardId,(bool success) =>
				{
				});
			lastDate = DateTime.Now;
		}
	}
}
