using UnityEngine;

namespace Singletons
{
    public class SingletonComponent<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (!_instance)
                {
                    _instance = FindObjectOfType<T>();
                    if (_instance) return _instance;

                    var res = Resources.Load<T>(typeof(T).Name);
                    _instance = Instantiate(res);
                    DontDestroyOnLoad(_instance.gameObject);
                }

                return _instance;
            }
        }
    }
}