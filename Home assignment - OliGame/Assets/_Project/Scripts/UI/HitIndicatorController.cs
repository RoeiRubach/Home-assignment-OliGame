using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace HomeAssignment
{
    public class HitIndicatorController : MonoBehaviour
    {
        [SerializeField] private GameObject _panel;
        [SerializeField] private byte _alphaValue = 140;

        private void Start()
        {
            if (GameManager.AreEffectsOn)
                HealthManager.OnGettingDamage += HandlePanel;
        }

        private void HandlePanel(byte damamge)
        {
            _panel.SetActive(true);
            if (_panel.TryGetComponent(out Image image))
            {
                image.DOKill();
                image.DOFade(0, GameManager.GettingHitCooldown).OnComplete(() => OnFadeEnded(image));
            }
        }

        private void OnFadeEnded(Image image)
        {
            image.color = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, _alphaValue);
            _panel.SetActive(false);
        }

        private void OnDisable()
        {
            if (GameManager.AreEffectsOn)
                HealthManager.OnGettingDamage -= HandlePanel;
        }
    }
}