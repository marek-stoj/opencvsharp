/*
 * (C) 2008-2014 shimat
 * This code is licenced under the LGPL.
 */

using System;

namespace OpenCvSharp.CPlusPlus
{
    // ReSharper disable once InconsistentNaming

#if LANG_JP
    /// <summary>
    /// BOWKMeansTrainer 実装
    /// </summary>
#else
    /// <summary>
    /// BOWKMeansTrainer implementation
    /// </summary>
#endif
    public class BOWKMeansTrainer : DisposableCvObject // TODO IMM HI: ihnerit from BOWTrainer
    {
        private bool disposed;
        private Ptr<BOWKMeansTrainer> trainerPtr;

        #region Init & Disposal

        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="clusterCount">Number of clusters to split the set by.</param>
        /// <param name="termCrit">The algorithm termination criteria, that is, the maximum number of iterations and/or the desired accuracy.</param>
        /// <param name="attempts">Flag to specify the number of times the algorithm is executed using different initial labellings. The algorithm returns the labels that yield the best compactness.</param>
        /// <param name="flags">Flags. See <see cref="KMeansFlag" />.</param>
        public BOWKMeansTrainer(int clusterCount, TermCriteria termCrit, int attempts = 3, KMeansFlag flags = KMeansFlag.PpCenters)
        {
            ptr = NativeMethods.features2d_BOWKMeansTrainer_new(clusterCount, termCrit, attempts, (int)flags);
        }

        /// <summary>
        /// Creates instance by cv::Ptr&lt;cv::BOWKMeansTrainer&gt;
        /// </summary>
        internal BOWKMeansTrainer(Ptr<BOWKMeansTrainer> trainerPtr)
        {
            this.trainerPtr = trainerPtr;
            this.ptr = trainerPtr.Obj;
        }
        /// <summary>
        /// Creates instance by raw pointer cv::BOWKMeansTrainer*
        /// </summary>
        internal BOWKMeansTrainer(IntPtr rawPtr)
        {
            trainerPtr = null;
            ptr = rawPtr;
        }
        /// <summary>
        /// Creates instance from cv::Ptr&lt;T&gt; .
        /// ptr is disposed when the wrapper disposes. 
        /// </summary>
        /// <param name="ptr"></param>
        internal static new BOWKMeansTrainer FromPtr(IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException("Invalid cv::Ptr<BOWKMeansTrainer> pointer");
            var ptrObj = new Ptr<BOWKMeansTrainer>(ptr);
            return new BOWKMeansTrainer(ptrObj);
        }

#if LANG_JP
    /// <summary>
    /// リソースの解放
    /// </summary>
    /// <param name="disposing">
    /// trueの場合は、このメソッドがユーザコードから直接が呼ばれたことを示す。マネージ・アンマネージ双方のリソースが解放される。
    /// falseの場合は、このメソッドはランタイムからファイナライザによって呼ばれ、もうほかのオブジェクトから参照されていないことを示す。アンマネージリソースのみ解放される。
    ///</param>
#else
        /// <summary>
        /// Releases the resources
        /// </summary>
        /// <param name="disposing">
        /// If disposing equals true, the method has been called directly or indirectly by a user's code. Managed and unmanaged resources can be disposed.
        /// If false, the method has been called by the runtime from inside the finalizer and you should not reference other objects. Only unmanaged resources can be disposed.
        /// </param>
#endif
        protected override void Dispose(bool disposing)
        {
            if (!disposed)
            {
                try
                {
                    // releases managed resources
                    if (disposing)
                    {
                    }
                    // releases unmanaged resources
                    if (trainerPtr != null)
                    {
                        trainerPtr.Dispose();
                        trainerPtr = null;
                    }
                    else
                    {
                        if (ptr != IntPtr.Zero)
                            NativeMethods.features2d_BOWKMeansTrainer_delete(ptr);
                        ptr = IntPtr.Zero;
                    }
                    disposed = true;
                }
                finally
                {
                    base.Dispose(disposing);
                }
            }
        }
        #endregion

        #region Methods
        #endregion
    }
}
