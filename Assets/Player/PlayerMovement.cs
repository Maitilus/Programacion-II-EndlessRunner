using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Variables

    [Header("Jump Height")]
        public float JumpForce;
        public float JumpMultiplier;
        [SerializeField] private float MaxJumpTime;
        [SerializeField] private float FallMultiplier;

    [Header("Links")]
        [SerializeField] private Rigidbody2D PlayerRB;
        [SerializeField] private LayerMask GroundLayer;
        [SerializeField] private Transform FeetPos;
        [SerializeField] private Transform PlayerObj;

    //Checks
        private bool IsJumping;
        private float CurrentJumpTime;
        [SerializeField] private float GroundDistance = 0.25f;

    private Vector2 Gravity;
    #endregion

    private void Start()
    {
        PlayerRB = GetComponent<Rigidbody2D>();
        Gravity = new Vector2(0, -Physics2D.gravity.y);
    }

    //Ground Detection
    bool IsGrounded()
    {
        return Physics2D.OverlapCircle(FeetPos.position, GroundDistance, GroundLayer);
    }

    private void Update()
    {
        #region Jumping

        //Initial Jump Control
        if (IsGrounded() && Input.GetButtonDown("Jump"))
        {
            IsJumping = true;
            PlayerRB.velocity = new Vector2(PlayerRB.velocity.x, JumpForce);
        }

        //Extra Height if Holding
        if (IsJumping && PlayerRB.velocity.y > 0)
        {
            PlayerRB.velocity += JumpMultiplier * Time.deltaTime * Gravity;

            //Set time limit
            CurrentJumpTime += Time.deltaTime;
            if (CurrentJumpTime > MaxJumpTime) {IsJumping = false;}

            //Smoothen the jump   
            float t = CurrentJumpTime / MaxJumpTime;
            float CurrentJM = JumpMultiplier;

            if (t > 0.5f) {CurrentJM = JumpMultiplier * (1 - t);}

            PlayerRB.velocity += CurrentJM * Time.deltaTime * Gravity;
        }

        //Fall Force Control
        if (PlayerRB.velocity.y < 0) {PlayerRB.velocity -= FallMultiplier * Time.deltaTime * Gravity;}

        //Reset Jump
        if(Input.GetButtonUp("Jump")) 
        {
            IsJumping = false;
            CurrentJumpTime = 0;

            //Retain some momentum
            if (PlayerRB.velocity.y > 0) {PlayerRB.velocity = new Vector2(PlayerRB.velocity.x, PlayerRB.velocity.y * 0.6f);}
        }
        #endregion

        #region Crouching

        if (IsGrounded() && Input.GetKeyDown("down"))
        {
            PlayerObj.localScale = new Vector2(PlayerObj.localScale.x, 0.65f);
        }
        if (Input.GetKeyUp("down")) {PlayerObj.localScale = new Vector2(PlayerObj.localScale.x, 1f);}  



        #endregion
    }
}