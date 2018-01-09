using UnityEngine;
using AlphaOwl.UniversalController;
using AlphaOwl.UniversalController.Utilities;

public class SamplePlayer : UCPlayer
{
    private Vector3 spawnPoint;
	public float movementSpeed;
	public float jump;
	private Rigidbody rb;

    // Use this for initialization
    void Start()
    {

		rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {

    }

	// Override callbacks from parent. Call the base methods 
	// for debug usage.
	protected override void OnPlayerRegisterAction()
	{
        base.OnPlayerRegisterAction();

		float x = Random.Range (-10.0f, 10.0f);
		float z = Random.Range (-10.0f, 10.0f);

		DebugUtilities.Log(x + " hello " + z);

		spawnPoint = new Vector3 (x, 5, z);

        // Sample action
        transform.position = spawnPoint;
        Debug.Log("Player Spawned", this);
    }

	public override void OnPlayerDeregister()
	{
		// Remove this line if you don't want to destroy 
		// the player gameobject when player deregister.
        base.OnPlayerDeregister(); 
    }

    public override void KeyDown(string key, string extra = "")
    {
        base.KeyDown(key, extra);

		switch(key)
		{
		case "jump":
			rb.AddForce (Vector3.up * jump, ForceMode.Impulse);

			break;
		case "left":

			transform.position += Vector3.left * Time.deltaTime * movementSpeed;

			break;
		case "right":

			transform.position += Vector3.right * Time.deltaTime * movementSpeed;

			break;
		case "forwards":

			transform.position += transform.forward * Time.deltaTime * movementSpeed;

			break;
		case "backwards":

			transform.position -= transform.forward * Time.deltaTime * movementSpeed;

			break;
		}

        // Switch statement is recommended here to 
        // response on different key inputs.
    }

    public override void Gyro(float x, float y, float z)
	{
		// Values of x, y, z are between 1 and -1.

        base.Gyro(x, y, z);
    }

	public override void Joystick(float x, float y)
	{
		// Values of x, y are between 1 and -1.

        base.Joystick(x, y);
    }
}
