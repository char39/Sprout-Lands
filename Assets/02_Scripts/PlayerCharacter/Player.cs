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
        }
        //--------------------------------------------------------//
        private Animator ani;
        private Rigidbody2D rb;
        private Transform tr;
        private Transform pivotTr;
        private Collider2D col;
        //--------------------------------------------------------//
        private void GetComponents()
        {
            ani = GetComponent<Animator>();
            rb = GetComponent<Rigidbody2D>();
            tr = GetComponent<Transform>();
            pivotTr = tr.GetChild(0).GetComponent<Transform>();
            col = GetComponent<BoxCollider2D>();
        }
        private void SetValue()
        {
            groundMask = 1 << LayerMask.NameToLayer("GroundLayerMask");
        }



        private void OnDrawGizmos()
        {
            if (pivotTr == null) return;
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube((Vector2)pivotTr.position + Vector2.up * 0.1f, GetBoxCastSize());
            Gizmos.DrawWireCube((Vector2)pivotTr.position + Vector2.down * 0.1f, GetBoxCastSize());
            Gizmos.DrawWireCube((Vector2)pivotTr.position + Vector2.left * 0.1f, GetBoxCastSize());
            Gizmos.DrawWireCube((Vector2)pivotTr.position + Vector2.right * 0.1f, GetBoxCastSize());
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(GetRayOriginPos(pivotTr.position), GetBoxCastSize());
        }
    }
}