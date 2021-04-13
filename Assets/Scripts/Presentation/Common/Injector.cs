using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Presentation
{
    public static class Injector
    {

        private static readonly Dictionary<Type, object> _registedServices = new Dictionary<Type, object>();

        public static void RegisterService<T>(T service)
        {
            if (_registedServices.ContainsKey(typeof(T)))
                throw new InvalidOperationException("El servicio ya esta registrado");

            _registedServices.Add(typeof(T), service);
        }
        public static T GetService<T>()
        {
            if (!_registedServices.TryGetValue(typeof(T), out object service))            
                throw new InvalidOperationException("El servicio no esta registrado");            
            return (T)service;
        }


    }
}
