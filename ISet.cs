using System;

namespace IndusApp
{
    public interface ISet<T> where T : IEquatable<T>
    {
        void Add(T elem);
        bool Contains(T data);
        bool Remove(T elem);
    }
}