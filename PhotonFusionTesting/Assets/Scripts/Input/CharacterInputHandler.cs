using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInputHandler : MonoBehaviour
{

    Vector2 inputVector = Vector2.zero;
    Vector2 viewInputVector = Vector2.zero;

    CharacterMovementHandler movementHandler;

    bool isJumping;

    private void Awake()
    {
        movementHandler = GetComponent<CharacterMovementHandler>();  
    }
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        viewInputVector.x = Input.GetAxis("Mouse X");
        viewInputVector.y = Input.GetAxis("Mouse Y") * -1;

        movementHandler.SetViewInputVector(viewInputVector);

        inputVector.x = Input.GetAxis("Horizontal");
        inputVector.y = Input.GetAxis("Vertical");

        isJumping = Input.GetButtonDown("Jump");
       
    }

    public NetworkInputData GetNetworkInput()
    {
        NetworkInputData networkInputData = new NetworkInputData();
        networkInputData.rotationInput = viewInputVector.x;
        networkInputData.movementInput = inputVector;
        networkInputData.isJumpPressed = isJumping;
        return networkInputData;
    }
}
