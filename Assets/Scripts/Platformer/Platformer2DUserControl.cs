using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof(PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {
        private PlatformerCharacter2D m_Character;
        private bool m_Jump;
        private bool m_SustainJump;
        private bool m_DisableControl;
        private bool m_Dash;           // DASH UPDATE
        private float reverseTimer;
        public float reverseSpan = 5;
        public bool reverse;
        public bool panEquipped = false;
        

        private SpriteRenderer m_Renderer;  // Reference to the SpriteRenderer component

        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
            m_Renderer = GetComponent<SpriteRenderer>();
            reverseTimer = reverseSpan;
        }

        private void Update()
        {
            // If control is disabled, return.
            if (m_DisableControl) return;

            if (!m_Jump)
            {
                // Read the jump input in Update so button presses aren't missed.
                m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
                m_SustainJump = CrossPlatformInputManager.GetButton("Jump");
            }
            
            if (!m_Dash)
            {
                // Read the dash input (Fire2 is right shift)
                m_Dash = CrossPlatformInputManager.GetButtonDown("Fire2");
            }

            if (reverse)
            {
                if (reverseTimer > 0)
                {
                    reverseTimer -= Time.deltaTime;
                    return;
                }
                reverse = false;
                m_Renderer.color = Color.white;
                reverseTimer = reverseSpan;
            }
        }

        private void FixedUpdate()
        {
            // If control is disabled, return.
            if (m_DisableControl) return;

            // Read the inputs.
            bool crouch = Input.GetKey(KeyCode.S);
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            if (reverse)
            {
                h = -CrossPlatformInputManager.GetAxis("Horizontal");  // When reverse is true, horizontal inputs go in opposite directions
            }

            // Move function was updated in PlatformerCharacter2D with the dash and attack variables as the 5th and 6th arguments respectively
            m_Character.Move(h, crouch, m_Jump, m_SustainJump, m_Dash);
            m_Jump = false;
            m_Dash = false;
        }

        public void DisableControl(bool disableInput)
        {
            m_DisableControl = disableInput;
        }

        private void AddFryingPan()
        {
            panEquipped = true;
        }
    }
}
