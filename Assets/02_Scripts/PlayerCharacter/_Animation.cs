namespace PlayerCharacter
{
    public partial class Player
    {
        internal enum State { UP, DOWN, LEFT, RIGHT }   // UP : Back(뒤), DOWN : Front(앞)
        internal State state = State.DOWN;
        
        private const string ANI_DIRECTION = "Direction";
        private const string MOVE_SPEED = "MoveSpeed";

        /// <summary> 플레이어의 이동 상태를 반환함. </summary>
        private State GetPlayerMoveState()
        {
            if (rb.velocity.y > 0) return State.UP;
            else if (rb.velocity.y < 0) return State.DOWN;
            else if (rb.velocity.x > 0) return State.RIGHT;
            else if (rb.velocity.x < 0) return State.LEFT;
            else return state;
        }
        /// <summary> 플레이어의 이동 상태에 따라 애니메이션을 설정함. </summary>
        private void SetPlayerAnimation()
        {
            state = GetPlayerMoveState();
            ani.SetFloat(ANI_DIRECTION, (int)state);  // UP : 0, DOWN : 1, LEFT : 2, RIGHT : 3
            ani.SetFloat(MOVE_SPEED, rb.velocity.magnitude > 0 ? (run ? 2 : 1) : 0);
        }
    }
}