using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scenes
{
    public class ObjectPool<T>
    {
        #region Fields

        private readonly Func<T> _preloadFunc;
        private readonly Action<T> _getAction;
        private readonly Action<T> _returnAction;
        
        private readonly Queue<T> _pool;
        private readonly List<T> _active;

        #endregion

        #region Constructors

        public ObjectPool(Func<T> preloadFunc, Action<T> getAction, Action<T> returnAction, int preloadCount)
        {
            if (preloadFunc == null)
            {
                Debug.LogError("Preload func is null!!!");
                return;
            }
            
            _preloadFunc = preloadFunc;
            _getAction = getAction;
            _returnAction = returnAction;

            _pool = new Queue<T>(preloadCount);
            _active = new List<T>(preloadCount);
            
            for (int i = 0; i < preloadCount; i++)
                _pool.Enqueue(_preloadFunc());
        }

        #endregion

        #region Public Methods

        public T Get()
        {
            T item = _pool.Count > 0 ? _pool.Dequeue() : _preloadFunc();

            _getAction(item);
            _active.Add(item);

            return item;
        }

        public void Return(T item)
        {
            _returnAction(item);
            _pool.Enqueue(item);
            _active.Remove(item);
        }

        public void ReturnAll()
        {
            foreach (T item in _active)
                Return(item);
        }

        #endregion
    }
}