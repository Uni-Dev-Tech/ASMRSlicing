using System.Linq;
using UnityEngine;

namespace Game
{
    public abstract class SingletonScriptableObject<T> : ScriptableObject where T : ScriptableObject
    {
        static T _instance = null;
        public static T Instance
        {
            get
            {
                if (!_instance)
                {
                    T[] typeObjects = Resources.LoadAll<T>("");
                    if (typeObjects[0] != null && typeObjects.Length > 0)
                    {
                        _instance = typeObjects[0];
                    }

                    if (typeObjects.Length > 1)
                    {
                        Debug.LogError($"There are more than 1 object of type {typeof(T).FullName}");
                    }
                    else if (typeObjects.Length == 0)
                    {
                        Debug.LogError($"There are no objects of type {typeof(T).FullName}");
                    }
                }
                return _instance;
            }
        }
    }
}