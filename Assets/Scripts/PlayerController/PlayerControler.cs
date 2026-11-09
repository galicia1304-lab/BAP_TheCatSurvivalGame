using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControler : MonoBehaviour
{
    //control cats movement values here.
    [SerializeField] private float speed = 5f;
    [SerializeField] private float JumpHeight = 2f;
    [SerializeField] private float Gravity = -9.8f;
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private bool shouldFaceMoveDirection = false;


    private CharacterController CatControler;
    private Vector3 moveinput;
    private Vector3 velocity;



    void Start()
    {
        CatControler = GetComponent<CharacterController>();
    }

    //calling on movement through input
    public void OnMove(InputAction.CallbackContext context)
    {
        moveinput = context.ReadValue<Vector2>();
        //debug log for what input is pressed
        Debug.Log($"Move Input; {moveinput}");
    }

    //calling on jump through input
    public void OnJump(InputAction.CallbackContext context) 
    {
        //list state of character jumping
        Debug.Log($"jumping {context.performed} - Is Grounded: {CatControler.isGrounded}");
        if (context.performed && CatControler.isGrounded)
        {
            Debug.Log("I wanna Jump");
            //velocity for jumping when jumping
            velocity.y = Mathf.Sqrt(JumpHeight *  -2f * Gravity);
        }
    
    }

    void Update()
    {
        //question code posistion
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        Vector3 moveDirecton = forward * moveinput.y + right * moveinput.x;
        CatControler.Move(moveDirecton * speed * Time.deltaTime);

        //player rotation
        if (shouldFaceMoveDirection && moveDirecton.sqrMagnitude > 0.001f) 
        {
            Quaternion toRotation = Quaternion.LookRotation(moveDirecton, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, 10f * Time.deltaTime);
        }


        //this is related to [public void OnJump] 
        velocity.y += Gravity * Time.deltaTime;
        CatControler.Move(velocity * Time.deltaTime);

       
    }
}


//velocity is always going down fix later.