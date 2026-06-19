using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace acha
{
    //[DefaultExecutionOrder(-2)]   // script run early

    public class CustomJoystick : MonoBehaviour, Movement.IOnfootActions
    {
        public Movement Movement { get; private set; }
        public Vector2 MovementInput { get; private set; } //store x,y input

        public bool JumpPressed { get; private set; } //bool flag, if jump press hua ya nahi.
        public Animator animator;



        public void OnMovement(InputAction.CallbackContext context)
        {
            MovementInput = context.ReadValue<Vector2>();
            print(MovementInput);
        }
        private void OnEnable()
        {
            Movement = new Movement();
            Movement.Enable();

            Movement.onfoot.Enable();
            Movement.onfoot.SetCallbacks(this);
        }
        private void OnDisable()
        {

            Movement.onfoot.Disable();
            Movement.onfoot.RemoveCallbacks(this);
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            if (context.performed) // check if butt press or not
            {
                JumpPressed = true;
            }

        }
        public void ResetJump()
        {
            JumpPressed = false;
        }
        public void JumpButtonPressed()
        {
            JumpPressed = true;
        }



        public void OnAttack(InputAction.CallbackContext context)
        {
            animator.SetTrigger("attack");
        }

        public void OnAttack1(InputAction.CallbackContext context)
        {
            animator.SetTrigger("attack1");
        }

        public void OnAttack2(InputAction.CallbackContext context)
        {
            animator.SetTrigger("attack2");
        }

        public void OnLookAction(InputAction.CallbackContext context)
        {
        }

        public void OnSword(InputAction.CallbackContext context)
        {
            animator.SetTrigger("drawsword");
        }

        public void OnSheathsword(InputAction.CallbackContext context)
        {
            animator.SetTrigger("sheathsword");
        }


        //public void OnWalk(InputAction.CallbackContext context)
        //{
        //    if(!context.performed) 
        //    return;

        //    Walk = !Walk;
        // }
    }
}