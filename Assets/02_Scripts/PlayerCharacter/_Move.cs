using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerCharacter
{
    public partial class Player
    {
        private KeyCode upKey = KeyCode.UpArrow;
        private KeyCode downKey = KeyCode.DownArrow;
        private KeyCode leftKey = KeyCode.LeftArrow;
        private KeyCode rightKey = KeyCode.RightArrow;
        private KeyCode runKey = KeyCode.LeftShift;

        public int up;
        public int down;
        public int left;
        public int right;
        public bool run;

        internal float walkSpeed = 3.0f;
        internal float runSpeed = 4.5f;

        /// <summary> 플레이어의 이동 키를 설정함. </summary>
        public void UpdateKeySettings(KeyCode up, KeyCode down, KeyCode left, KeyCode right, KeyCode run)
        {
            upKey = up;
            downKey = down;
            leftKey = left;
            rightKey = right;
            runKey = run;
        }
        /// <summary> 플레이어의 이동 키 입력을 받음. </summary>
        private void GetPlayerMoveKeyInput()
        {
            up = Input.GetKey(upKey) ? 1 : 0;                   // ↑ 키를 누르면 1, 아니면 0
            down = Input.GetKey(downKey) ? -1 : 0;              // ↓ 키를 누르면 -1, 아니면 0
            left = Input.GetKey(leftKey) ? -1 : 0;              // ← 키를 누르면 -1, 아니면 0
            right = Input.GetKey(rightKey) ? 1 : 0;             // → 키를 누르면 1, 아니면 0
            run = Input.GetKey(runKey);                         // 달리기 키를 누르면 true, 아니면 false
        }
        /// <summary> 플레이어의 이동 방향을 방향벡터로 반환함. </summary>
        private Vector2 GetDirectionVector() => new Vector2(right + left, up + down).normalized;
        /// <summary> 플레이어의 이동 방향과 속도를 설정함. </summary>
        private void SetPlayerMoveVelocity()
        {
            Vector2 DirectionVector = GetDirectionVector();
            float speed = run ? runSpeed : walkSpeed;
            rb.velocity = DirectionVector * speed;
        }
    }
}
