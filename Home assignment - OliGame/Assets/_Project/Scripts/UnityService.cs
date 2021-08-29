using UnityEngine;

namespace HomeAssignment
{
    public class UnityService : IUnityService
    {
        public float GetAxisRaw(string axisName) => Input.GetAxisRaw(axisName);

        public float GetDeltaTime() => Time.deltaTime;
    }
}
