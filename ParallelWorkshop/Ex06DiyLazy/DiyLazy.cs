﻿using System;
using System.Threading;

namespace Lurchsoft.ParallelWorkshop.Ex06DiyLazy
{
    /// <summary>
    /// Try at least the following approaches: -
    /// <list type="number">
    /// <item>
    /// a lazy with the behaviour of <see cref="LazyThreadSafetyMode.PublicationOnly"/>. For this one, you definitely
    /// do not need any locks, just <see cref="Interlocked"/>.
    /// </item>
    /// <item>
    /// a lazy with the behaviour of <see cref="LazyThreadSafetyMode.ExecutionAndPublication"/>. For this one, you can
    /// try: -
    ///   (a) using a lock (that's what <see cref="System.Lazy{T}"/> does. In this case, it will block, consuming no CPU, while 
    ///       another thread is evaluating the value
    ///   (b) using only <see cref="Interlocked"/>. In this case, it will spin the CPU, while another thread is evaluating the
    ///       value. A tough exercise!
    /// </item>
    /// </list>
    /// </summary>
    /// <remarks>
    /// Some solutions will be easier if you restrict the generic type to a reference type. Do so if you wish.
    /// <para>Obviously, you don't get to use <see cref="System.Lazy{T}"/> in your solution!</para>
    /// </remarks>
    public class DiyLazy<T> : ILazy<T> where T : class
    {
        private readonly Func<T> evaluator;

        public DiyLazy(Func<T> evaluator)
        {
            this.evaluator = evaluator;
        }

        public T Value
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public LazyThreadSafetyMode Mode
        {
            get
            {
                // Return whatever mode is supported by your implementation. Used by tests to decide what to assert.
                throw new NotImplementedException();
            }
        }
    }
}
