namespace Utility
{
    public static class DiskUtility
    {
        // 需要 iOS/Android/Editor 分别实现
        public static long GetFreeSpace()
        {
            // TODO
            return 0;
        }

        public static long GetBusySpace()
        {
            return 0;
        }

        public static long GetTotalSpace()
        {
            return 0;
        }

        public static bool HasEnoughSpace(long byteSize)
        {
            return GetFreeSpace() > GetBusySpace();
        }
    }
}