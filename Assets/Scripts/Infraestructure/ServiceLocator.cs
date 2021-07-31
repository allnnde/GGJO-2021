using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Assertions;



public class ServiceLocator
{
    public static ServiceLocator Instance => _instance ?? (_instance = new ServiceLocator());
    private static ServiceLocator _instance;

    private readonly Dictionary<Type, object> _services;

    private ServiceLocator()
    {
        _services = new Dictionary<Type, object>();
    }

    public void RegisterService<T>(T service)
    {
        var type = typeof(T);
        Assert.IsFalse(_services.ContainsKey(type), $"Service {type} already registered");

        _services.Add(type, service);
    }

    public T GetServiceSingleton<T>()
    {
        var type = typeof(T);
        if (!_services.TryGetValue(type, out var service))
        {
            throw new Exception($"Service {type} not found");
        }

        return (T)service;
    }

    public T GetServiceScoped<T>()
    {
        var service = GetServiceSingleton<T>();
        var json = JsonConvert.SerializeObject(service);
        var obj = JsonConvert.DeserializeObject(json, service.GetType());
        return (T)obj;
    }

}

