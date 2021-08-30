using UnityEngine;

namespace HomeAssignment
{
    public class UnityService : IUnityService
    {
        public float GetAxis(string axisName) => Input.GetAxis(axisName);

        public float GetDeltaTime() => Time.deltaTime;
    }
}
