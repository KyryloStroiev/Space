using CodeBase.Infrastraction.Factory;
using CodeBase.Infrastraction.Service;
using CodeBase.StateData;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Hud : MonoBehaviour
{
   public TextMeshProUGUI ScoreText;
   public Button MenuButton;

   private float _score;

   private SpawnMeteorite _spawnMeteorite;
   private IWindowsService _windowsService;


   public void Construct(IWindowsService windowsService, SpawnMeteorite spawnMeteorite)
   {
      _windowsService = windowsService;
      _spawnMeteorite = spawnMeteorite;
      _spawnMeteorite.DestroyMeteorite += ChangeScore;
   }

   private void Awake()
   {
      ScoreText.text = $"Score: {_score}";
      MenuButton.onClick.AddListener(OpenMenu);
   }

   private void ChangeScore(float score)
   {
      _score += score;
      ScoreText.text = _score.ToString();
   }

   private void OpenMenu()
   {
      Time.timeScale = 0f;
      _windowsService.Open(WindowsTypeId.PauseMenu);
   }
}
