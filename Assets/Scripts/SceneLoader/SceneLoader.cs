using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameDevLabirinth
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField]
        private string _sceneNameSaved;

        private readonly LevelNameData _levelName = new LevelNameData();

        private void Start()
        {
            if (!string.IsNullOrEmpty(_sceneNameSaved))
            {
                StartCoroutine(AddScene(_sceneNameSaved));
            }
        }

        public void Load()
        {
            if (!string.IsNullOrEmpty(_levelName.GetName()))
            {
                StartCoroutine(ScenesController(_levelName.GetName()));
            }
        }

        private IEnumerator ScenesController(string sceneName)
        {
            if (!string.IsNullOrEmpty(_sceneNameSaved))
            {
                yield return StartCoroutine(RemoveOldScene());
                yield return StartCoroutine(UnloadResources());
            }
            yield return StartCoroutine(AddScene(sceneName));
        }

        private IEnumerator AddScene(string name)
        {
            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(name, LoadSceneMode.Additive);

            while (!asyncOperation.isDone)
            {
                yield return null;
            }
            _sceneNameSaved = name;
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(name));
        }

        private IEnumerator RemoveOldScene()
        {
            AsyncOperation asyncOperation = SceneManager.UnloadSceneAsync(_sceneNameSaved);
            while (!asyncOperation.isDone)
            {
                yield return null;
            }
        }

        private IEnumerator UnloadResources()
        {
            AsyncOperation asyncOperation = Resources.UnloadUnusedAssets();
            while (!asyncOperation.isDone)
            {
                yield return null;
            }
        }
    }
}
