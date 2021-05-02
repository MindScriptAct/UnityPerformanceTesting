using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Utils
{
    static class GameObjectAssertExtensions
    {
        /// <summary>
        /// Verrifies all fields are not null and not defaults.
        /// </summary>
        /// <param name="gameObject"></param>
        /// <param name="fields"></param>
        internal static void AssertFields(this GameObject gameObject, params object[] fields)
        {
#if UNITY_EDITOR
            foreach (var field in fields)
            {
                if (field == null)
                {
                    Debug.LogError($"GameObject {gameObject.name} must have all required fields set.");
                }
                else
                {
                    var type = field.GetType();
                    if (type.IsValueType)
                    {
                        object defaultValue = Activator.CreateInstance(type);
                        if (field.Equals(defaultValue))
                        {
                            Debug.LogError($"GameObject {gameObject.name} must have all {type} fields set to not defaults.");
                        }
                    }
                    else if (type == typeof(string))
                    {
                        if (string.IsNullOrEmpty((string)field))
                        {
                            Debug.LogError($"GameObject {gameObject.name} must have all string fields set.");
                        }
                    }
                }
            }
#endif
        }
    }
}
