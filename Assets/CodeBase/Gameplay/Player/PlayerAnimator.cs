using UnityEngine;
using UnityEngine.Serialization;

namespace CodeBase.Gameplay.Player
{
   public class PlayerAnimator : MonoBehaviour
   {
      private static readonly int MoveHash = Animator.StringToHash("Move");

      public Animator Animator;
      public PlayerMove PlayerMove;

      
      private void Update() => 
         Animator.SetFloat(MoveHash, PlayerMove.Direction);
   }
}
