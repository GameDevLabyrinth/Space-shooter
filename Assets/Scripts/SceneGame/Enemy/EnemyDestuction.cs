using UnityEngine;

namespace GameDevLabirinth
{
    public class EnemyDestuction : MonoBehaviour
    {
        public void Activate()
        {
            Destroy(gameObject, 0.2f);
            //TODO: add effects, score ....
        }
    }
}
