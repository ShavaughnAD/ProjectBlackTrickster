using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] CharacterController characterController;
    //[SerializeField] Animator anim;

    public float moveSpeed;
    public float horizontalStrafeSpeed;
    [SerializeField] float turnSpeed;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
        //anim = GetComponent<Animator>();
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        var horizontal = Input.GetAxis("Mouse X") ;
        var vertical = Input.GetAxis("Vertical");

        //transform.Rotate(Vector3.up, horizontal * turnSpeed * Time.deltaTime);
        transform.Rotate(new Vector3(0, horizontal * turnSpeed, 0));
        if (vertical != 0)
        {
            characterController.SimpleMove(transform.forward * moveSpeed * vertical);
        }
        if (Input.GetKey(KeyCode.A))
        {
            characterController.Move(-transform.right * horizontalStrafeSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            characterController.Move(transform.right * horizontalStrafeSpeed * Time.deltaTime);
        }
    }
}