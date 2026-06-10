using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerScript : MonoBehaviour
{

    public InputAction InputActions;
    public CharacterController playerChatachterController;


    private void OnEnable()
    {
        //InputActions.FindActionMap("Player").Enable();
    }
}
