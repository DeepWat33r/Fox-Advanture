using Pathfinding;
using UnityEngine;

namespace Enemies
{
    public class VultureController : MonoBehaviour
    {
        public AIPath aiPath;

        // Update is called once per frame
        void Update()
        {
            if (aiPath.desiredVelocity.x >= 0.01f)
            {
                transform.localScale = new Vector3(5f, 5f, 5f);
            } else if (aiPath.desiredVelocity.x <= -0.01f)
            {
                transform.localScale = new Vector3(-5f, 5f, 5f);
            }
        }
    }
}
