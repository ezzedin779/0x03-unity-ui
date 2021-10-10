using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	// ref our Rigid body 
	public Rigidbody rb;
	public float speed = 500f;
	private int score = 0;
	public int health = 5;

	// The pickup
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Pickup")
		{
			this.score += 1;
			Debug.Log("Score: " + score);
			other.GetComponent<Renderer>().enabled = false;
			Destroy(other);
		}
		if (other.tag == "Trap")
		{
			this.health -= 1;
			Debug.Log("Health: " + health);
		}
		if (other.tag == "Goal")
		{
			Debug.Log("You win!");
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
    }

	// Reload the game when dead
	void Update()
	{
		if (health == 0)
		{
			Debug.Log("Game Over!");
			health = 5;
			score = 0;
			SceneManager.LoadScene(0, LoadSceneMode.Single);
		}
	}
}
