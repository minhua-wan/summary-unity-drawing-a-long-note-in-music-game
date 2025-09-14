using System.Text;

namespace Utility
{
    public static class PlatformUtility
    {
        public static class PlatformName
        {
            public const string Android = "Android";
            public const string IOS = "iOS";
            public const string Editor = "Editor";
            public const string NotSupported = "NotSupported";
        }

        public static bool IsAndroid()
        {
#if UNITY_ANDROID
            return true;
#endif
            return false;
        }

        public static bool IsIOS()
        {
#if UNITY_IOS
            return true;
#endif
            return false;
        }

        public static bool IsEditor()
        {
#if UNITY_EDITOR
            return true;
#endif
            return false;
        }

        public static string GetPlatformName()
        {
#if UNITY_EDITOR
            return PlatformName.Editor;
#elif UNITY_ANDROID
            return PlatformName.Android;
#elif UNITY_IOS
            return PlatformName.IOS;
#endif
            return PlatformName.NotSupported;
        }
    }
}