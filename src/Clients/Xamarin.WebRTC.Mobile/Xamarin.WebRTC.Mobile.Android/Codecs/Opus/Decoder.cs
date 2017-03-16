using System;

using Android.Runtime;

using Java.Interop;

namespace Xamarin.WebRTC.Mobile.Android.Codecs.Opus
{
    public class Decoder
    {
        private long State;

        public Decoder(int clockRate, int channels, int packetTime)
        {
            try
            {
                State = OpusLibrary.Java_aopus_OpusLibrary_decoderCreate(JNIEnv.Handle, IntPtr.Zero, clockRate, channels, packetTime);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex); 
            }
        }

        public void Destroy()
        {
            try
            {
                OpusLibrary.Java_aopus_OpusLibrary_decoderDestroy(JNIEnv.Handle, IntPtr.Zero, State);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public byte[] Decode(byte[] encodedData)
        {
            IntPtr encodedDataPtr = JNIEnv.NewArray(encodedData);
            try
            {
                var result = OpusLibrary.Java_aopus_OpusLibrary_decoderDecode(JNIEnv.Handle, IntPtr.Zero, State, encodedDataPtr);
                var transfer = (encodedData == null);
                if (transfer)
                {
                    JniEnvironment.References.CreatedReference(new JniObjectReference(result, JniObjectReferenceType.Local));
                }
                return (byte[])JNIEnv.GetArray(result, (transfer ? JniHandleOwnership.TransferLocalRef : JniHandleOwnership.DoNotTransfer), typeof(byte));
            }
            finally
            {
                JNIEnv.DeleteLocalRef(encodedDataPtr);
            }
        }

        public byte[] Decode(byte[] encodedData, bool fec)
        {
            IntPtr encodedDataPtr = JNIEnv.NewArray(encodedData);
            try
            {
                var result = OpusLibrary.Java_aopus_OpusLibrary_decoderDecode2(JNIEnv.Handle, IntPtr.Zero, State, encodedDataPtr, fec);
                var transfer = (encodedData == null);
                if (transfer)
                {
                    JniEnvironment.References.CreatedReference(new JniObjectReference(result, JniObjectReferenceType.Local));
                }
                return (byte[])JNIEnv.GetArray(result, (transfer ? JniHandleOwnership.TransferLocalRef : JniHandleOwnership.DoNotTransfer), typeof(byte));
            }
            finally
            {
                JNIEnv.DeleteLocalRef(encodedDataPtr);
            }
        }
    }
}