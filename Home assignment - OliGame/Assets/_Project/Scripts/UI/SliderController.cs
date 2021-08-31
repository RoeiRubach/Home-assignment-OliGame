using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace HomeAssignment
{
    [RequireComponent(typeof(Slider))]
    public class SliderController : MonoBehaviour
    {
        private Slider _slider;

        private void Start()
        {
            _slider = GetComponent<Slider>();
            HealthManager.OnGettingDamage += DecreaseValue;
        }

        public void RestoreHealthViaButton() => _slider.DOValue(_slider.maxValue, duration:.5f);

        private void DecreaseValue(byte maxHealth)
        {
            float decreasingAmount = Mathf.Clamp(_slider.maxValue / maxHealth, 0, _slider.maxValue);
            _slider.DOValue(_slider.value - decreasingAmount, .2f);
        }

        private void OnDisable() => HealthManager.OnGettingDamage -= DecreaseValue;
    }
}