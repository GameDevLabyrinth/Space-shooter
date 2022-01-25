using System.Collections.Generic;
using UnityEngine;

namespace GameDevLabirinth
{
    [CreateAssetMenu(menuName = "Game bonuses")]
    public class GameBonuseDataSO : ScriptableObject
    {
        public List<BaseBonus> Bonuses = new List<BaseBonus>();
    }
}
