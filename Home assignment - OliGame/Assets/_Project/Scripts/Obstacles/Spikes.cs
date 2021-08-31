using DG.Tweening;
using System.Collections;
using UnityEngine;

namespace HomeAssignment
{
    public class Spikes : Obstacle
    {
        private Vector3 _startingScale;
        private Vector3 _endingScale;

        private void Start()
        {
            _startingScale = transform.localScale;
            _endingScale = new Vector3(transform.localScale.x, transform.localScale.y, 20);
        }

        protected override void OnTriggerEnter(Collider other)
        {
            base.OnTriggerEnter(other);
            if (other.CompareTag("Player"))
                OnPlayerEnter();
        }

        private void OnPlayerEnter()
        {
            GetComponent<BoxCollider>().isTrigger = false;
            Sequence scaleUpAndDown = DOTween.Sequence();
            scaleUpAndDown.Append(Scale(_endingScale, .3f))
                .Append(Scale(_startingScale, GameManager.GettingHitCooldown))
                .OnComplete(() => GetComponent<BoxCollider>().isTrigger = true);
        }

        private Tween Scale(Vector3 endValue, float duration)
        {
            return transform.DOScale(endValue, duration);
        }

        private IEnumerator LaunchSpike()
        {
            GetComponent<BoxCollider>().isTrigger = false;
            while(transform.localScale.z < 20)
            {
                transform.localScale += Vector3.forward * 2f;
                yield return null;
            }

            float timeToReachTarget = GameManager.GettingHitCooldown;
            Vector3 currentScale = transform.localScale;
            var time = 0f;
            while (time < 1)
            {
                time += Time.deltaTime / timeToReachTarget;
                transform.localScale = Vector3.Lerp(currentScale, _startingScale, time);
                yield return null;
            }

            transform.localScale = _startingScale;
            GetComponent<BoxCollider>().isTrigger = true;
        }
    }
}