using System.Collections;
using UnityEngine;

namespace HomeAssignment
{
    public class Spikes : Obstacle
    {
        private Vector3 _startingScale;

        private void Start()
        {
            _startingScale = transform.localScale;
        }

        protected override void OnTriggerEnter(Collider other)
        {
            base.OnTriggerEnter(other);
            if (other.CompareTag("Player"))
                StartCoroutine(LaunchSpike());
        }

        private IEnumerator LaunchSpike()
        {
            GetComponent<BoxCollider>().isTrigger = false;
            while(transform.localScale.z < 20)
            {
                transform.localScale += Vector3.forward * 2f;
                yield return null;
            }

            yield return new WaitForSeconds(2);

            while (transform.localScale.z > _startingScale.z)
            {
                transform.localScale -= Vector3.forward;
                yield return null;
            }

            transform.localScale = _startingScale;
            GetComponent<BoxCollider>().isTrigger = true;
        }
    }
}