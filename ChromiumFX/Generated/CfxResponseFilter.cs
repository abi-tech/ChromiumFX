// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium {
    using Event;

    /// <summary>
    /// Implement this structure to filter resource response content. The functions
    /// of this structure will be called on the browser process IO thread.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_response_filter_capi.h">cef/include/capi/cef_response_filter_capi.h</see>.
    /// </remarks>
    public class CfxResponseFilter : CfxClientBase {

        private static object eventLock = new object();

        internal static void SetNativeCallbacks() {
            init_filter_native = init_filter;
            filter_native = filter;

            init_filter_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(init_filter_native);
            filter_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(filter_native);
        }

        // init_filter
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void init_filter_delegate(IntPtr gcHandlePtr, out int __retval);
        private static init_filter_delegate init_filter_native;
        private static IntPtr init_filter_native_ptr;

        internal static void init_filter(IntPtr gcHandlePtr, out int __retval) {
            var self = (CfxResponseFilter)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                __retval = default(int);
                return;
            }
            var e = new CfxInitFilterEventArgs();
            self.m_InitFilter?.Invoke(self, e);
            e.m_isInvalid = true;
            __retval = e.m_returnValue ? 1 : 0;
        }

        // filter
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void filter_delegate(IntPtr gcHandlePtr, out int __retval, IntPtr data_in, UIntPtr data_in_size, out UIntPtr data_in_read, IntPtr data_out, UIntPtr data_out_size, out UIntPtr data_out_written);
        private static filter_delegate filter_native;
        private static IntPtr filter_native_ptr;

        internal static void filter(IntPtr gcHandlePtr, out int __retval, IntPtr data_in, UIntPtr data_in_size, out UIntPtr data_in_read, IntPtr data_out, UIntPtr data_out_size, out UIntPtr data_out_written) {
            var self = (CfxResponseFilter)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                __retval = default(int);
                data_in_read = default(UIntPtr);
                data_out_written = default(UIntPtr);
                return;
            }
            var e = new CfxFilterEventArgs(data_in, data_in_size, data_out, data_out_size);
            self.m_Filter?.Invoke(self, e);
            e.m_isInvalid = true;
            data_in_read = e.m_data_in_read;
            data_out_written = e.m_data_out_written;
            __retval = (int)e.m_returnValue;
        }

        internal CfxResponseFilter(IntPtr nativePtr) : base(nativePtr) {}
        public CfxResponseFilter() : base(CfxApi.ResponseFilter.cfx_response_filter_ctor) {}

        /// <summary>
        /// Initialize the response filter. Will only be called a single time. The
        /// filter will not be installed if this function returns false (0).
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_response_filter_capi.h">cef/include/capi/cef_response_filter_capi.h</see>.
        /// </remarks>
        public event CfxInitFilterEventHandler InitFilter {
            add {
                lock(eventLock) {
                    if(m_InitFilter == null) {
                        CfxApi.ResponseFilter.cfx_response_filter_set_callback(NativePtr, 0, init_filter_native_ptr);
                    }
                    m_InitFilter += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_InitFilter -= value;
                    if(m_InitFilter == null) {
                        CfxApi.ResponseFilter.cfx_response_filter_set_callback(NativePtr, 0, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxInitFilterEventHandler m_InitFilter;

        /// <summary>
        /// Called to filter a chunk of data. |DataIn| is the input buffer containing
        /// |DataInSize| bytes of pre-filter data (|DataIn| will be NULL if
        /// |DataInSize| is zero). |DataOut| is the output buffer that can accept up
        /// to |DataOutSize| bytes of filtered output data. Set |DataInRead| to the
        /// number of bytes that were read from |DataIn|. Set |DataOutWritten| to
        /// the number of bytes that were written into |DataOut|. If some or all of
        /// the pre-filter data was read successfully but more data is needed in order
        /// to continue filtering (filtered output is pending) return
        /// RESPONSE_FILTER_NEED_MORE_DATA. If some or all of the pre-filter data was
        /// read successfully and all available filtered output has been written return
        /// RESPONSE_FILTER_DONE. If an error occurs during filtering return
        /// RESPONSE_FILTER_ERROR. This function will be called repeatedly until there
        /// is no more data to filter (resource response is complete), |DataInRead|
        /// matches |DataInSize| (all available pre-filter bytes have been read), and
        /// the function returns RESPONSE_FILTER_DONE or RESPONSE_FILTER_ERROR. Do not
        /// keep a reference to the buffers passed to this function.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_response_filter_capi.h">cef/include/capi/cef_response_filter_capi.h</see>.
        /// </remarks>
        public event CfxFilterEventHandler Filter {
            add {
                lock(eventLock) {
                    if(m_Filter == null) {
                        CfxApi.ResponseFilter.cfx_response_filter_set_callback(NativePtr, 1, filter_native_ptr);
                    }
                    m_Filter += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_Filter -= value;
                    if(m_Filter == null) {
                        CfxApi.ResponseFilter.cfx_response_filter_set_callback(NativePtr, 1, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxFilterEventHandler m_Filter;

        internal override void OnDispose(IntPtr nativePtr) {
            if(m_InitFilter != null) {
                m_InitFilter = null;
                CfxApi.ResponseFilter.cfx_response_filter_set_callback(NativePtr, 0, IntPtr.Zero);
            }
            if(m_Filter != null) {
                m_Filter = null;
                CfxApi.ResponseFilter.cfx_response_filter_set_callback(NativePtr, 1, IntPtr.Zero);
            }
            base.OnDispose(nativePtr);
        }
    }


    namespace Event {

        /// <summary>
        /// Initialize the response filter. Will only be called a single time. The
        /// filter will not be installed if this function returns false (0).
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_response_filter_capi.h">cef/include/capi/cef_response_filter_capi.h</see>.
        /// </remarks>
        public delegate void CfxInitFilterEventHandler(object sender, CfxInitFilterEventArgs e);

        /// <summary>
        /// Initialize the response filter. Will only be called a single time. The
        /// filter will not be installed if this function returns false (0).
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_response_filter_capi.h">cef/include/capi/cef_response_filter_capi.h</see>.
        /// </remarks>
        public class CfxInitFilterEventArgs : CfxEventArgs {


            internal bool m_returnValue;
            private bool returnValueSet;

            internal CfxInitFilterEventArgs() {
            }

            /// <summary>
            /// Set the return value for the <see cref="CfxResponseFilter.InitFilter"/> callback.
            /// Calling SetReturnValue() more then once per callback or from different event handlers will cause an exception to be thrown.
            /// </summary>
            public void SetReturnValue(bool returnValue) {
                CheckAccess();
                if(returnValueSet) {
                    throw new CfxException("The return value has already been set");
                }
                returnValueSet = true;
                this.m_returnValue = returnValue;
            }
        }

        /// <summary>
        /// Called to filter a chunk of data. |DataIn| is the input buffer containing
        /// |DataInSize| bytes of pre-filter data (|DataIn| will be NULL if
        /// |DataInSize| is zero). |DataOut| is the output buffer that can accept up
        /// to |DataOutSize| bytes of filtered output data. Set |DataInRead| to the
        /// number of bytes that were read from |DataIn|. Set |DataOutWritten| to
        /// the number of bytes that were written into |DataOut|. If some or all of
        /// the pre-filter data was read successfully but more data is needed in order
        /// to continue filtering (filtered output is pending) return
        /// RESPONSE_FILTER_NEED_MORE_DATA. If some or all of the pre-filter data was
        /// read successfully and all available filtered output has been written return
        /// RESPONSE_FILTER_DONE. If an error occurs during filtering return
        /// RESPONSE_FILTER_ERROR. This function will be called repeatedly until there
        /// is no more data to filter (resource response is complete), |DataInRead|
        /// matches |DataInSize| (all available pre-filter bytes have been read), and
        /// the function returns RESPONSE_FILTER_DONE or RESPONSE_FILTER_ERROR. Do not
        /// keep a reference to the buffers passed to this function.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_response_filter_capi.h">cef/include/capi/cef_response_filter_capi.h</see>.
        /// </remarks>
        public delegate void CfxFilterEventHandler(object sender, CfxFilterEventArgs e);

        /// <summary>
        /// Called to filter a chunk of data. |DataIn| is the input buffer containing
        /// |DataInSize| bytes of pre-filter data (|DataIn| will be NULL if
        /// |DataInSize| is zero). |DataOut| is the output buffer that can accept up
        /// to |DataOutSize| bytes of filtered output data. Set |DataInRead| to the
        /// number of bytes that were read from |DataIn|. Set |DataOutWritten| to
        /// the number of bytes that were written into |DataOut|. If some or all of
        /// the pre-filter data was read successfully but more data is needed in order
        /// to continue filtering (filtered output is pending) return
        /// RESPONSE_FILTER_NEED_MORE_DATA. If some or all of the pre-filter data was
        /// read successfully and all available filtered output has been written return
        /// RESPONSE_FILTER_DONE. If an error occurs during filtering return
        /// RESPONSE_FILTER_ERROR. This function will be called repeatedly until there
        /// is no more data to filter (resource response is complete), |DataInRead|
        /// matches |DataInSize| (all available pre-filter bytes have been read), and
        /// the function returns RESPONSE_FILTER_DONE or RESPONSE_FILTER_ERROR. Do not
        /// keep a reference to the buffers passed to this function.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_response_filter_capi.h">cef/include/capi/cef_response_filter_capi.h</see>.
        /// </remarks>
        public class CfxFilterEventArgs : CfxEventArgs {

            internal IntPtr m_data_in;
            internal UIntPtr m_data_in_size;
            internal UIntPtr m_data_in_read;
            internal IntPtr m_data_out;
            internal UIntPtr m_data_out_size;
            internal UIntPtr m_data_out_written;

            internal CfxResponseFilterStatus m_returnValue;
            private bool returnValueSet;

            internal CfxFilterEventArgs(IntPtr data_in, UIntPtr data_in_size, IntPtr data_out, UIntPtr data_out_size) {
                m_data_in = data_in;
                m_data_in_size = data_in_size;
                m_data_out = data_out;
                m_data_out_size = data_out_size;
            }

            /// <summary>
            /// Get the DataIn parameter for the <see cref="CfxResponseFilter.Filter"/> callback.
            /// </summary>
            public IntPtr DataIn {
                get {
                    CheckAccess();
                    return m_data_in;
                }
            }
            /// <summary>
            /// Get the DataInSize parameter for the <see cref="CfxResponseFilter.Filter"/> callback.
            /// </summary>
            public ulong DataInSize {
                get {
                    CheckAccess();
                    return (ulong)m_data_in_size;
                }
            }
            /// <summary>
            /// Set the DataInRead out parameter for the <see cref="CfxResponseFilter.Filter"/> callback.
            /// </summary>
            public UIntPtr DataInRead {
                set {
                    CheckAccess();
                    m_data_in_read = value;
                }
            }
            /// <summary>
            /// Get the DataOut parameter for the <see cref="CfxResponseFilter.Filter"/> callback.
            /// </summary>
            public IntPtr DataOut {
                get {
                    CheckAccess();
                    return m_data_out;
                }
            }
            /// <summary>
            /// Get the DataOutSize parameter for the <see cref="CfxResponseFilter.Filter"/> callback.
            /// </summary>
            public ulong DataOutSize {
                get {
                    CheckAccess();
                    return (ulong)m_data_out_size;
                }
            }
            /// <summary>
            /// Set the DataOutWritten out parameter for the <see cref="CfxResponseFilter.Filter"/> callback.
            /// </summary>
            public UIntPtr DataOutWritten {
                set {
                    CheckAccess();
                    m_data_out_written = value;
                }
            }
            /// <summary>
            /// Set the return value for the <see cref="CfxResponseFilter.Filter"/> callback.
            /// Calling SetReturnValue() more then once per callback or from different event handlers will cause an exception to be thrown.
            /// </summary>
            public void SetReturnValue(CfxResponseFilterStatus returnValue) {
                CheckAccess();
                if(returnValueSet) {
                    throw new CfxException("The return value has already been set");
                }
                returnValueSet = true;
                this.m_returnValue = returnValue;
            }

            public override string ToString() {
                return String.Format("DataIn={{{0}}}, DataInSize={{{1}}}, DataOut={{{2}}}, DataOutSize={{{3}}}", DataIn, DataInSize, DataOut, DataOutSize);
            }
        }

    }
}
