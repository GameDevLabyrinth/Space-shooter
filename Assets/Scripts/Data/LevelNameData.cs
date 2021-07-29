using UnityEngine;

namespace GameDevLabirinth
{
    public class LevelNameData
    {
        private const string Key = "SceneName";

        public void SetName(string name)
        {
            PlayerPrefs.SetString(Key, name);
            PlayerPrefs.Save();
        }

        public string GetName()
        {
            if (PlayerPrefs.HasKey(Key))
            {
                return PlayerPrefs.GetString(Key);
            }

            return null;
        }
    }
}
