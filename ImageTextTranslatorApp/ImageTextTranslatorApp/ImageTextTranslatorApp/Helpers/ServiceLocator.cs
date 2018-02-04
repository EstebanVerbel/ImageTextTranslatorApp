using System;
using System.Collections.Generic;

namespace ImageTextTranslatorApp.Helpers
{
    public sealed class ServiceLocator
    {
        static readonly Lazy<ServiceLocator> _instance = new Lazy<ServiceLocator>(() => new ServiceLocator());
        readonly Dictionary<Type, Lazy<object>> _registeredServices = new Dictionary<Type, Lazy<object>>();

        public static ServiceLocator Instance => _instance.Value;

        public void Register<TContract, TService>() where TService : new()
        {
            _registeredServices[typeof(TContract)] =  new Lazy<object>(() => Activator.CreateInstance(typeof(TService)));
        }

        public T Get<T>() where T : class
        {
            Lazy<object> service;
            if (_registeredServices.TryGetValue(typeof(T), out service))
            {
                return (T)service.Value;
            }

            return null;
        }
    }
}
