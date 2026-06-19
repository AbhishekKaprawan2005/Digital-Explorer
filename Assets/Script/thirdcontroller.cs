using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.Playables;

namespace acha
{
    //[DefaultExecutionOrder(-1)]
    public class fps : MonoBehaviour
    {
        [SerializeField] CharacterController controller;
        [SerializeField] Transform playercamera;
        [SerializeField] public CustomJoystick player;
        public float playerSpeed = 4f;
        [SerializeField] private Animator animator;
        [SerializeField] private float blendspeed = 0.02f;
        private int lookfingerid = -1;
        public GameObject s;
        public GameObject s1;
        public GameObject c;


        //camera
        public float lookSensitivityH = 0.1f;
        public float lookSensitivityV = 0.1f;
        public float turnSensitivity = 0.1f;
        private float xRotation = 0f;
        private Vector3 currentblendinput = Vector3.zero;

      

        //jump
        private Vector3 velocity = Vector3.zero; // track vertical speed
        [SerializeField] private float gravity = -9.81f;
        private bool isGroundedd;
        private IEnumerator Start()
        {
            if (controller == null)
                controller = GetComponent<CharacterController>();

            animator = GetComponent<Animator>();

            controller.enabled = false;

 
            while (!LodMeshLoader.GlobeLoaded)
                yield return null;

            controller.enabled = true;

            Debug.Log("Player Enabled");
        }
        private void Awake()
        {

            player = GetComponent<CustomJoystick>();
        }

        private void Update()
        {
            Movement();
            Debug.Log(controller.isGrounded);
            if (Physics.Raycast(transform.position, -transform.up, out RaycastHit hit, 100f))
            {
                Debug.Log("Hit Object = " + hit.collider.gameObject.name);
                Debug.Log("Parent = " + hit.collider.transform.root.name);
            }
        }

        void Movement()
        {
            Vector3 cameraForward = new Vector3(playercamera.transform.forward.x, 0f, playercamera.transform.forward.z).normalized;
            Vector3 cameraRight = new Vector3(playercamera.transform.right.x, 0f, playercamera.transform.right.z).normalized;
            Vector3 movementDirection = cameraRight * player.MovementInput.x + cameraForward * player.MovementInput.y;
            
 
            if (c.activeInHierarchy)
                playerSpeed = 3f;
            else
                playerSpeed = 4f;
            if (s.activeInHierarchy)
                playerSpeed = 2f;
            else
                playerSpeed = 4f;
            if (s1.activeInHierarchy)
                playerSpeed = 2f;
            else
                playerSpeed = 4f;

            currentblendinput = Vector3.Lerp(currentblendinput, player.MovementInput, blendspeed * Time.deltaTime); // smooth animation
            animator.SetFloat("input x", currentblendinput.x);
            animator.SetFloat("input y", currentblendinput.y);

            if (Physics.Raycast(transform.position, -transform.up, out RaycastHit hit, 3f))
            {
                velocity.y = -2f;
            }
            else
            {
                velocity.y += gravity * Time.deltaTime;
            }

            Vector3 finalMove =
     movementDirection * playerSpeed +
     velocity;

            controller.Move(finalMove * Time.deltaTime);

            //velocity.y += gravity * Time.deltaTime;
            //controller.Move(velocity * Time.deltaTime);

            //if (controller.isGrounded)
            //{
            //    if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, controller.height / 3 + 1f))
            //    {
            //        float slopeAngle = Vector3.Angle(hit.normal, Vector3.up);

            //        if (slopeAngle > controller.slopeLimit)
            //        {
            //            Vector3 slideDirection = new Vector3(hit.normal.x, -1f, hit.normal.z);
            //            controller.Move(slideDirection * Time.deltaTime);
            //        }
            //    }
            //}



        }
        
        #region camera

        void HandleCameraLook()
        {
            if (Touchscreen.current == null) return;

            foreach (var touch in Touchscreen.current.touches) //loop sab active touches check karega
            {
                if (lookfingerid == -1)
                {
                    if (touch.phase.ReadValue() == UnityEngine.InputSystem.TouchPhase.Began)
                    {
                        Vector2 pos = touch.position.ReadValue();
                        if (pos.x > Screen.width / 2)
                        {
                            lookfingerid = touch.touchId.ReadValue();
                        }
                    }
                }
                if (touch.touchId.ReadValue() == lookfingerid)
                {
                    if (touch.phase.ReadValue() == UnityEngine.InputSystem.TouchPhase.Moved)
                    {
                        Vector2 delta = touch.delta.ReadValue();
                        float mouseX = delta.x * lookSensitivityH;
                        float mouseY = delta.y * lookSensitivityV;
                        transform.Rotate(Vector3.up * mouseX);

                        xRotation -= mouseY;
                        xRotation = Mathf.Clamp(xRotation, -10f, 30f);
                        playercamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);


                        bool isIdle = player.MovementInput == Vector2.zero && controller.isGrounded;

                        bool horizontaldominant = Mathf.Abs(mouseX) > Mathf.Abs(mouseY);
                        bool isTurning = isIdle && horizontaldominant && Mathf.Abs(mouseX) > turnSensitivity;

                        animator.SetBool("turn", isTurning);



                    }
                    else if (touch.phase.ReadValue() == UnityEngine.InputSystem.TouchPhase.Ended)
                    {
                        // finger uth gyi toh stop
                        lookfingerid = -1;
                        animator.SetBool("turn", false);


                    }
                }

            }
           
        }



         
        #endregion
        private void LateUpdate()
        {
            HandleCameraLook();

        }
       
    }

}