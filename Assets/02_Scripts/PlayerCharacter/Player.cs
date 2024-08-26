using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerCharacter
{
    public partial class Player : MonoBehaviour
    {
        //--------------------------------------------------------//
        void Awake()
        {

        }

        void Start()
        {
            GetComponents();
            SetValue();
        }

        void FixedUpdate()
        {
            SetPlayerMoveVelocity();
        }

        void Update()
        {
            GetPlayerMoveKeyInput();
            SetPlayerAnimation();
        }
        //--------------------------------------------------------//
        private Animator ani;
        private Rigidbody2D rb;
        private Transform tr;
        private Collider2D col;
        //--------------------------------------------------------//
        private void GetComponents()
        {
            ani = GetComponent<Animator>();
            rb = GetComponent<Rigidbody2D>();
            tr = GetComponent<Transform>();
            col = GetComponent<BoxCollider2D>();
        }
        private void SetValue()
        {
            
        }
    }
}