using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
	public Material trap;
	public Material goal;
	public Toggle colorblind;

    // Start is called before the first frame update
    public void PlayMaze()
	{
		if (colorblind.isOn == true)
		{
			trap.color = new Color32(255, 112, 0, 1);
			goal.color = Color.blue;
		}
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
	// quit the game ?
	public void QuitMaze()
	{
		Debug.Log("Quit Game");
		Application.Quit();
	}
}
