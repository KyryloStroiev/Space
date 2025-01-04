using UnityEngine;

namespace CodeBase.Gameplay.Player
{
   public class PlayerAnimator : MonoBehaviour
   {
      private static readonly int MoveHash = Animator.StringToHash("Move");

      private Animator _animator;
      private PlayerMove _playerMove;

      private void Awake()
      {
         _animator = GetComponent<Animator>();
         _playerMove = GetComponent<PlayerMove>();
      }

      private void Update()
      {
         _animator.SetFloat(MoveHash, _playerMove.Direction);
      }
   }
}
