using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private InputSystemActions inputActions;

    public InputSystemActions.PlayerActions Actions => inputActions.Player;

    void Start()
    {
        inputActions = new InputSystemActions();
        inputActions.Player.Enable();
    }
}