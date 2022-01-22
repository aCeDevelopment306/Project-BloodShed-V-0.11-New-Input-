using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class InputManager : MonoBehaviour
{
    // movement.[action].performed += context => do something

    [SerializeField] Movement movementScript;
    [SerializeField] MouseLook mouseLookScript;
    [SerializeField] Weapon weaponScript;


    PlayerControls playerControls;
    PlayerControls.MovementActions movement;
    PlayerControls.GunActions gun;
    
    Vector2 horizontalInput;
    Vector2 mouseInput;
    Vector2 rightStickInput;

    private void Awake()
    {
        playerControls = new PlayerControls();
        movement = playerControls.Movement;
        gun = playerControls.Gun;
        
        movement.Horizontal.performed += ctx => horizontalInput = ctx.ReadValue<Vector2>();

        movement.Jump.performed += _ => movementScript.OnJumpPress();

        movement.MouseX.performed += ctx => mouseInput.x = ctx.ReadValue<float>();
        movement.MouseY.performed += ctx => mouseInput.y = ctx.ReadValue<float>();

        movement.StickX.performed += ctx => rightStickInput.x = ctx.ReadValue<float>();
        movement.StickY.performed += ctx => rightStickInput.y = ctx.ReadValue<float>();

        gun.Fire.performed += _ => weaponScript.Shooting();

        gun.AimAndShoot.performed += _ => weaponScript.ShootingAndAiming();

        gun.Aim.performed += _ => weaponScript.Aiming();
        gun.Aim.canceled += _ => weaponScript.StopAiming();

    }

    private void Update()
    {
        movementScript.RecieveInput(horizontalInput);
        mouseLookScript.RecieveInput(mouseInput);
    }
    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }
}
