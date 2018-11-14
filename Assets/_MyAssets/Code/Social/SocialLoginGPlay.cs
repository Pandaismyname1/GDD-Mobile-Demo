using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames.BasicApi;
using GooglePlayGames;

public class SocialLoginGPlay : MonoBehaviour {

	void Start () {
		PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
		PlayGamesPlatform.InitializeInstance(config);
		PlayGamesPlatform.Activate();
		Social.localUser.Authenticate((bool success) => {
			if(success)
				Debug.Log(":)");
			else
				Debug.Log(":(");
		});
	}
}
