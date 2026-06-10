using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{

    //get refrence to all player inputs in script
    private PlayerInputManager input;

    public CharacterController controller;

    //editable speed value
    [SerializeField] float speed = 4;

    void Start()
    {
        input = GetComponent<PlayerInputManager>();   
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        controller.Move(input.move* speed *Time.deltaTime);
    }
}
