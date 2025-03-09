using System.Collections;
using UnityEngine;

namespace Tower
{
    public class CorrutineRunner : MonoBehaviour
    {
        private static CorrutineRunner _instance;

        public static CorrutineRunner Instance
        {
            get
            {
                if (_instance == null)
                {
                    GameObject obj = new GameObject("CoroutineRunner");
                    _instance = obj.AddComponent<CorrutineRunner>();
                    DontDestroyOnLoad(obj);
                }
                return _instance;
            }
        }

        public void RunCoroutine(IEnumerator coroutine)
        {
            StartCoroutine(coroutine);
        }
    }
}
