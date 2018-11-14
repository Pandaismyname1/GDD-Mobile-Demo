using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PermanentUI : MonoBehaviour {

	void Start () {
		DontDestroyOnLoad (gameObject);
	}

	public void NavigateToScene(int sceneIndex)
	{
		SceneManager.LoadScene (sceneIndex);
	}

}
