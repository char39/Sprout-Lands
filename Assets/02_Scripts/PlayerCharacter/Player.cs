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
            
        }

        void Update()
        {
            GetPlayerMoveKeyInput();
            SetPlayerAnimation();
            SetPlayerMoveVelocity();
            SetPlayerOrderMask();
        }
        //--------------------------------------------------------//
        private Animator ani;
        private SpriteRenderer sr;
        private Rigidbody2D rb;
        private Transform tr;
        private Transform pivotTr;
        private Collider2D col;
        //--------------------------------------------------------//
        private void GetComponents()
        {
            ani = GetComponent<Animator>();
            sr = GetComponent<SpriteRenderer>();
            rb = GetComponent<Rigidbody2D>();
            tr = GetComponent<Transform>();
            pivotTr = tr.GetChild(0).GetComponent<Transform>();
            col = GetComponent<BoxCollider2D>();
        }
        private void SetValue()
        {
            groundMask = 1 << LayerMask.NameToLayer("GroundMask");
            structureMask = 1 << LayerMask.NameToLayer("StructureMask");
            structureOrderMask = 1 << LayerMask.NameToLayer("StructureOrderMask");
        }



        private void OnDrawGizmos()
        {
            if (pivotTr == null) return;
            DrawGroundBoxCast();
            DrawGroundBoxCastLookAt();
        }
    }
}