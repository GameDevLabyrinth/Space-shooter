using System.Collections.Generic;

namespace GameDevLabirinth
{
    [System.Serializable]
    public class PointStates
    {
        public List<PointState> States = new List<PointState>();
    }

    [System.Serializable]
    public enum PointState
    {
        Locked,
        Open,
        OneStar,
        TwoStars,
        ThreeStars
    }
}
