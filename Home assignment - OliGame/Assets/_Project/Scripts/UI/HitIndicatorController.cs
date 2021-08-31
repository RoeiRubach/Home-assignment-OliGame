using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace HomeAssignment
{
    public class HitIndicatorController : MonoBehaviour
    {
        [SerializeField] private GameObject _panel;
        [SerializeField] private byte _alphaValue = 145;

        private void Start()
        {
            HealthManager.OnGettingDamage += HandlePanel;
        }

        private void HandlePanel(byte damamge)
        {
            _panel.SetActive(true);
            if(_panel.TryGetComponent(out Image image))
                image.DOFade(0, GameManager.GettingHitCooldown).OnComplete(() => OnFadeEnded(image));
        }

        private void OnFadeEnded(Image image)
        {
            image.color = new Color32(255, 255, 255, _alphaValue);
            _panel.SetActive(false);
        }
    }
}
