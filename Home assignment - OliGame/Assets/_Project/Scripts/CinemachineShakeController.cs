using UnityEngine;
using Cinemachine;
using System.Collections;

namespace HomeAssignment
{
    public class CinemachineShakeController : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera _virtualCamera;

        private void Start()
        {
            if (GameManager.AreEffectsOn)
                HealthManager.OnGettingDamage += StartShake;
        }

        private void StartShake(byte amplitude)
        {
            var perlin = _virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
            perlin.m_AmplitudeGain = 0;
            StartCoroutine(Shake(perlin));
        }

        private IEnumerator Shake(CinemachineBasicMultiChannelPerlin perlin)
        {
            float shakeTime = GameManager.GettingHitCooldown;
            var time = 0f;
            while (time < 1)
            {
                time += Time.deltaTime / shakeTime;

                perlin.m_AmplitudeGain = Mathf.Lerp(1, 0, time);
                yield return null;
            }
        }

        private void OnDisable()
        {
            if (GameManager.AreEffectsOn)
                HealthManager.OnGettingDamage -= StartShake;
        }
    }
}