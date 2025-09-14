namespace Utility
{
    public static class PathUtility
    {
        public static readonly string PersistentDataPath =
#if UNITY_EDITOR
            System.IO.Path.Combine(UnityEngine.Application.dataPath, "..", "persistent");
#else
            UnityEngine.Application.persistentDataPath;
#endif

        public static readonly string StreamingAssetDataPath = "";

        public static readonly string WwiseAssetRootPath = "";
        public static readonly string WwiseProjectRootPath = "";
        public static readonly string AssetPackRootPath = "";
        public static readonly string GameplayChartRootPath = "";

        public static string GetPersistentFullPath(string path)
        {
            return System.IO.Path.Combine(PersistentDataPath, path);
        }
    }
}