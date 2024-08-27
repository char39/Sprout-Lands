using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerCharacter
{
    public partial class Player
    {
        private LayerMask groundMask;

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
        /// <summary> 플레이어의 이동 방향과 속도를 설정함. </summary>
        private void SetPlayerMoveVelocity()
        {
            float speed = run ? runSpeed : walkSpeed;

            bool boxup = GetGroundBoxCastSelect(pivotTr.position, Vector2.up);          // true면 움직일 수 있음
            bool boxdown = GetGroundBoxCastSelect(pivotTr.position, Vector2.down);
            bool boxleft = GetGroundBoxCastSelect(pivotTr.position, Vector2.left);
            bool boxright = GetGroundBoxCastSelect(pivotTr.position, Vector2.right);

            Vector2 dirNormal = GetDirNormalVector();

            if (dirNormal.x > 0 && dirNormal.y > 0)                         // 오른쪽 위
                MoveInDirection(dirNormal, boxup, boxright, speed);
            else if (dirNormal.x < 0 && dirNormal.y > 0)                    // 왼쪽 위
                MoveInDirection(dirNormal, boxup, boxleft, speed);
            else if (dirNormal.x > 0 && dirNormal.y < 0)                    // 오른쪽 아래
                MoveInDirection(dirNormal, boxdown, boxright, speed);
            else if (dirNormal.x < 0 && dirNormal.y < 0)                    // 왼쪽 아래
                MoveInDirection(dirNormal, boxdown, boxleft, speed);
            else                                                            // 상하좌우 단방향
            {
                if (GetGroundBoxCast())                                         // 충돌 없으면 이동 가능
                    rb.velocity = GetDirNormalVector() * speed;
                else                                                            // 충돌 있으면 이동 불가능
                    rb.velocity = Vector2.zero;
            }

            void MoveInDirection(Vector2 DirectionNormal, bool boxPrimary, bool boxSecondary, float speed)      // 로컬 함수
            {
                if (boxPrimary && !boxSecondary)                                // 한 축만 충돌하면 다른 축은 이동 가능
                    rb.velocity = new Vector2(0, DirectionNormal.y) * speed;
                else if (!boxPrimary && boxSecondary)                           // 한 축만 충돌하면 다른 축은 이동 가능
                    rb.velocity = new Vector2(DirectionNormal.x, 0) * speed;
                else if (boxPrimary && boxSecondary)                            // 두 축 모두 충돌하지 않으면 자유롭게 이동 가능
                    rb.velocity = DirectionNormal * speed;
                else                                                            // 두 축 모두 충돌하면 이동 불가능
                    rb.velocity = Vector2.zero;
            }
        }



        /// <summary> 플레이어의 이동 방향을 정규 벡터로 반환함. </summary>
        private Vector2 GetDirNormalVector() => new Vector2(right + left, up + down).normalized;
        /// <summary> 플레이어의 이동 방향을 벡터로 반환함. </summary>
        private Vector2 GetDirVector() => new(right + left, up + down);
        /// <summary> 플레이어 Pivot의 중심을 기준으로 Ray Origin 위치를 반환. </summary>
        private Vector2 GetlocalPivotPos(Vector2 pivot) => pivot + GetDirVector() * 0.1f;
        /// <summary> 플레이어의 이동에 따라 Ray Origin 위치를 반환. </summary>
        private Vector2 GetRayOriginPos(Vector2 pivot)
        {
            if (GetDirVector() == Vector2.zero)
            {
                if (state == State.UP) return pivot + Vector2.up * 0.1f;
                else if (state == State.DOWN) return pivot + Vector2.down * 0.1f;
                else if (state == State.RIGHT) return pivot + Vector2.right * 0.1f;
                else if (state == State.LEFT) return pivot + Vector2.left * 0.1f;
                else return Vector2.zero;
            }
            else
                return GetlocalPivotPos(pivot);
        }
        /// <summary> 플레이어의 BoxCast Size를 반환. </summary>
        private Vector2 GetBoxCastSize() => new(0.3f, 0.3f);
        

        
        /// <summary> 플레이어의 BoxCol부터 이동하는 방향의 BoxCast 충돌 여부를 반환. </summary>
        private bool GetGroundBoxCast()
        {
            Vector2 origin = GetRayOriginPos(pivotTr.position);
            RaycastHit2D hit = Physics2D.BoxCast(origin, GetBoxCastSize(), 0, Vector2.zero, 0, groundMask);
            return hit.collider == null;    // true면 움직일 수 있음.
        }
        /// <summary> 플레이어의 BoxCol부터 원하는 방향의 BoxCast 충돌 여부를 반환. </summary>
        private bool GetGroundBoxCastSelect(Vector2 pivot, Vector2 direction)
        {
            Vector2 origin = pivot + direction * 0.1f;
            RaycastHit2D hit = Physics2D.BoxCast(origin, GetBoxCastSize(), 0, Vector2.zero, 0, groundMask);
            return hit.collider == null;    // true면 움직일 수 있음.
        }
    }
}
