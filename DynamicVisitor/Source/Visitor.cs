using System;
using System.Collections.Generic;

namespace PatternSampales
{
    public static class Visitor
    {
        public static IFuncVisitor<T, TResult> For<T, TResult>()
            where T : class
        {
            return new FuncVisitor<T, TResult>();
        }

        public static IActionVisitor<T> For<T>()
            where T : class
        {
            return new ActionVisitor<T>();
        }

        private sealed class ActionVisitor<TBase> : IActionVisitor<TBase>
            where TBase : class
        {
            private readonly Dictionary<Type, Action<TBase>> _repository =
                new Dictionary<Type, Action<TBase>>();

            public void Register<T>(Action<T> action)
                where T : TBase
            {
                _repository[typeof (T)] = x => action((T) x);
            }

            public void Visit<T>(T value)
                where T : TBase
            {
                Action<TBase> action = _repository[value.GetType()];
                action(value);
            }
        }

        private sealed class FuncVisitor<TBase, TResult> : IFuncVisitor<TBase, TResult>
            where TBase : class
        {
            private readonly Dictionary<Type, Func<TBase, TResult>> _repository =
                new Dictionary<Type, Func<TBase, TResult>>();

            public void Register<T>(Func<T, TResult> action)
                where T : TBase
            {
                _repository[typeof (T)] = x => action((T) x);
            }

            public TResult Visit<T>(T value)
                where T : TBase
            {
                Func<TBase, TResult> action = _repository[value.GetType()];
                return action(value);
            }
        }
    }

    public interface IFuncVisitor<in TBase, TResult>
        where TBase : class
    {
        /// <summary>
        ///     Register action on <see cref="T" />.
        /// </summary>
        /// <typeparam name="T">Concrete type.</typeparam>
        /// <param name="action">Action.</param>
        void Register<T>(Func<T, TResult> action)
            where T : TBase;

        /// <summary>
        ///     Visit concrete type.
        /// </summary>
        /// <param name="value">Type to visit.</param>
        /// <returns>Result value.</returns>
        TResult Visit<T>(T value)
            where T : TBase;
    }

    public interface IActionVisitor<in TBase>
        where TBase : class
    {
        /// <summary>
        ///     Register action on <see cref="T" />.
        /// </summary>
        /// <typeparam name="T">Concrete type.</typeparam>
        /// <param name="action">Action.</param>
        void Register<T>(Action<T> action)
            where T : TBase;

        /// <summary>
        ///     Visit concrete type.
        /// </summary>
        /// <param name="value">Type to visit.</param>
        void Visit<T>(T value)
            where T : TBase;
    }
}