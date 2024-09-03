using UnityEngine;
namespace PlayerCharacter
{
    public partial class Player
    {
        private LayerMask groundMask;
        private LayerMask structureMask;
        private LayerMask structureOrderMask;

        private void SetPlayerOrderMask()
        {
            if (GetOthersBoxCastBool(structureOrderMask))
                sr.sortingOrder = 0;
            else
                sr.sortingOrder = 10;
        }

        private bool GetOthersBoxCastBool(LayerMask layerMasks)
        {
            RaycastHit2D hit = GetOthersBoxCast(layerMasks);
            return hit.collider != null;    // 충돌하면 true
        }
        private RaycastHit2D GetOthersBoxCast(LayerMask layerMasks)
        {
            Vector2 origin = GetRayOriginPos(pivotTr.position);
            RaycastHit2D hit = Physics2D.BoxCast(origin, new(0.5f, 0.5f), 0, Vector2.zero, 0, layerMasks);
            return hit;
        }
    }
}