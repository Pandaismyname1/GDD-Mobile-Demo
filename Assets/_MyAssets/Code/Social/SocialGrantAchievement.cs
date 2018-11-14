using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocialGrantAchievement : MonoBehaviour {

	public string AchievementID;
	void Start () 
	{
		Social.ReportProgress(AchievementID, 100.0f, (bool success) => {
		});
	}
}
