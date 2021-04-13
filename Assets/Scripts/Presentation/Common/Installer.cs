using Application.Common;
using Domain.Interfaces;
using Infrastructure.Player;
using Presentation.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System;
using System.Linq;
using Infrastructure.Enemy;
using Application.Enemy;

namespace Presentation
{
    public class Installer : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            var assemblyNames = new string[] { "Application", "Domain", "Infrastructure", "Presentation"};

            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies()
                                    .Where(p=> assemblyNames.Any(q=>p.FullName.Contains(q))).ToArray();

            foreach (var assembly in assemblies)
            {
                var types = assembly.GetTypes();
                foreach (var type in types)
                {
                    var met = type.GetMethod("ConfigurationDependency");
                    if (met != null) {
                        var obj = FindObjectOfType(type);
                        met.Invoke(obj,null); 
                    }
                }
            }
        }
    }
}
