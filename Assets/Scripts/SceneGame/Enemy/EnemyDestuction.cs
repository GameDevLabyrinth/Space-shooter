using UnityEngine;

namespace GameDevLabirinth
{
    public class EnemyDestuction : MonoBehaviour
    {
        public void Activate()
        {
            Destroy(gameObject);
            //TODO: add effects, score ....
        }
    }
}
