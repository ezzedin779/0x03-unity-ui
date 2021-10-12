using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	// ref our Rigid body 
	public Rigidbody rb;
	public float speed = 500f;
	private int score = 0;
	public int health = 5;
	public Text scoreText;
	public Text healthText;
	public Text winloseText;
	public Image winloseBG;

	// Transition
	IEnumerator LoadScene(float seconds)
	{
		yield return new WaitForSeconds(seconds);
		health = 5;
		score = 0;
		SceneManager.LoadScene(0, LoadSceneMode.Single);
	}

	//Health text ?
	void SetHealthText()
	{
		healthText.text = "Health: " + health.ToString();
	}

	// the score text
	void SetScoreText()
	{
		scoreText.text = "Score: " + score.ToString();
	}
	// The pickup
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Pickup")
		{
			this.score += 1;
			SetScoreText();
			//Debug.Log("Score: " + score);
			other.GetComponent<Renderer>().enabled = false;
			Destroy(other);
		}
		if (other.tag == "Trap")
		{
			this.health -= 1;
			SetHealthText();
			//Debug.Log("Health: " + health);
		}
		if (other.tag == "Goal")
		{
			//Debug.Log("You win!");
			winloseText.color = Color.black;
			winloseText.text = "You win!";
			winloseBG.color = Color.green;
			winloseBG.gameObject.SetActive(true);
			StartCoroutine(LoadScene(3));
		}
	}
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
		{
			rb.AddForce(speed * Time.deltaTime, 0, 0);
		}
		if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.LeftArrow))
		{
			rb.AddForce(-speed * Time.deltaTime, 0, 0);
		}
		if (Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.UpArrow))
		{
			rb.AddForce(0, 0, speed * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
		{
			rb.AddForce(0, 0,  -speed * Time.deltaTime);
		}
		if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
	}

	void Start()
	{
		winloseBG.gameObject.SetActive(false);
	}
	// Reload the game when dead
	void Update()
	{
		if (health == 0)
		{
			//Debug.Log("Game Over!");
			winloseText.text = "Game Over!";
			winloseText.color = Color.white;
			winloseBG.color = Color.red;
			winloseBG.gameObject.SetActive(true);
			StartCoroutine(LoadScene(3));
		}
	}
}
