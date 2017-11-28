using UnityEngine;

// MoveBehaviour inherits from GenericBehaviour. This class corresponds to basic walk and run behaviour, it is the default behaviour.
public class AstralBehaviour : GenericBehaviour
{
	public float walkSpeed = 0.15f;                 // Default walk speed.
	public float runSpeed = 50.0f;                   // Default run speed.
	public float sprintSpeed = 2.0f;                // Default sprint speed.
	public float speedDampTime = 0.1f;              // Default damp time to change the animations based on current speed.
	
	private float speed, speedSeeker;               // Moving speed.
	
	private bool isColliding;

	private bool isWalking;


	// Start is always called after any Awake functions.
	void Start() 
	{
		
		// Subscribe and register this behaviour as the default behaviour.
		behaviourManager.SubscribeBehaviour (this);
		behaviourManager.RegisterDefaultBehaviour (this.behaviourCode);
		speedSeeker = runSpeed;
	}

	// Update is used to set features regardless the active behaviour.
	void Update ()
	{
		// Get jump input.
	
	}

	// LocalFixedUpdate overrides the virtual function of the base class.
	public override void LocalFixedUpdate()
	{
		// Call the basic movement manager.
		MovementManagement(behaviourManager.GetH, behaviourManager.GetV);
		
	
	}
	void Posess(GameObject posessTarget){
		posessTarget.GetComponent<MoveBehaviour>().enabled=true;
		behaviourManager.GetCamScript.player=posessTarget.transform;
		posessTarget.GetComponent<MoveBehaviour>().isSleeping = false;
		Destroy(gameObject);

	}


	// Deal with the basic player movement
	void MovementManagement(float horizontal, float vertical)
	{
		

		// Call function that deals with player orientation.
		Rotating(horizontal, vertical);

		// Set proper speed.
		Vector2 dir = new Vector2(horizontal, vertical);
		speed = Vector2.ClampMagnitude(dir, 1f).magnitude;
		// This is for PC only, gamepads control speed via analog stick.
		speedSeeker += Input.GetAxis("Mouse ScrollWheel");
		speedSeeker = Mathf.Clamp(speedSeeker, walkSpeed, runSpeed);
		speed *= speedSeeker;
		if (behaviourManager.isSprinting())
		{
			speed = sprintSpeed;
		}

		behaviourManager.GetAnim.SetFloat(speedFloat, speed, speedDampTime, Time.deltaTime);
	}

	// Rotate the player to match correct orientation, according to camera and key pressed.
	Vector3 Rotating(float horizontal, float vertical)
	{
		// Get camera forward direction, without vertical component.
		Vector3 forward = behaviourManager.playerCamera.TransformDirection(Vector3.forward);

		// Player is moving on ground, Y component of camera facing is not relevant.
		forward.y = 0.0f;
		forward = forward.normalized;

		// Calculate target direction based on camera forward and direction key.
		Vector3 right = new Vector3(forward.z, 0, -forward.x);
		Vector3 targetDirection;
		targetDirection = forward * vertical + right * horizontal;

		// Lerp current direction to calculated target direction.
		if((behaviourManager.IsMoving() && targetDirection != Vector3.zero))
		{
			Quaternion targetRotation = Quaternion.LookRotation (targetDirection);

			Quaternion newRotation = Quaternion.Slerp(behaviourManager.GetRigidBody.rotation, targetRotation, behaviourManager.turnSmoothing);
			behaviourManager.GetRigidBody.MoveRotation (newRotation);
			behaviourManager.SetLastDirection(targetDirection);
		}
		// If idle, Ignore current camera facing and consider last moving direction.
		if(!(Mathf.Abs(horizontal) > 0.9 || Mathf.Abs(vertical) > 0.9))
		{
			behaviourManager.Repositioning();
		}

		return targetDirection;
	}

	// Collision detection.
	private void OnCollisionStay(Collision collision)
	{
		isColliding = true;
	}
	private void OnCollisionExit(Collision collision)
	{
		isColliding = false;
	}
	private void OnCollisionEnter(Collision other){
		if(other.gameObject.tag == "Enemy" && other.gameObject.GetComponent<MoveBehaviour>().isSleeping == true){
			Posess(other.gameObject);
		}
		
	}
}
