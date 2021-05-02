using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Assertions;

namespace Assets.Scripts.Utils
{
    static class ComponentAssertExtensions
    {
        public static T GetAssertComponent<T>(this Component component) where T : Component
        {
            T retVal = component.GetComponent<T>();
#if UNITY_EDITOR
            Assert.IsNotNull(retVal, $"Component not found in {component.name}");
#endif
            return retVal;
        }
    }
}
