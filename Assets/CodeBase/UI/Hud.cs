using CodeBase.Gameplay.Armaments;
using CodeBase.Gameplay.Enemy;
using CodeBase.UI.Service;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI
{
   public class Hud : MonoBehaviour
   {
      public TextMeshProUGUI ScoreText;
      public TextMeshProUGUI BombsCountText;
      
      public Button MenuButton;
      
      public int MaxSpawnCountBomb { get; set; }

      private int _score = 0;
      private int _bomb = 0;

      private IWindowsService _windowsService;
      private IHudService _hudService;


      public void Construct(IWindowsService windowsService, IHudService hudService)
      {
         _hudService = hudService;
         _windowsService = windowsService;
         _hudService.SetScore += ChangeScore;
         _hudService.SetArmamentsCount += ChangeBombsCount;
      }

      private void Start()
      {
         ScoreText.text = $"Score: {_score}";
         MenuButton.onClick.AddListener(OpenMenu);
         
      }

      private void ChangeBombsCount(int bombs)
      {
         _bomb = bombs;
         BombsCountText.text = $"Bomb: {_bomb.ToString()}/{MaxSpawnCountBomb}";
      }

      

      private void ChangeScore(int score)
      {
         _score += score;
         ScoreText.text = $"Score: {_score.ToString()}";
      }

      private void OpenMenu()
      {
         Time.timeScale = 0f;
         _windowsService.Open(WindowsTypeId.PauseMenu);
      }
   }
}
