using UnityEngine;

namespace Singleton
{
    /// <summary>
    /// Singleton class which stays in all scenes
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PersistentSingleton<T> : MonoBehaviour where T : PersistentSingleton<T>
    {
        #region Variables
        private static T instance;
        #endregion

        #region Properties
        public static T Instance{ get { return instance; } }
        #endregion

        #region Unity Methods
        protected virtual void Awake()
        {
            if (instance == null)
            {
                instance = (T)this;
                DontDestroyOnLoad(this);
            }
            else if (instance != this)
            {
                Destroy(instance.gameObject);
                instance = (T)this;
                DontDestroyOnLoad(gameObject);
            }
        }
        #endregion
    }
}