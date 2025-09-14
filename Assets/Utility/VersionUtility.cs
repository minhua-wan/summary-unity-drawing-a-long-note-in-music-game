using System;

namespace Utility
{
    public static class VersionUtility
    {
        // Compile time value, It will modified by patch builder
        private const int patchVersion = 0;
        private const string revision = "Editor";


        // This class should move out of file of VersionUtility
        public static class FeatureVerions
        {
            // Those Feature should read from config file? 
            public static readonly Version FeatureA = new Version(0, 0, 0);
            public static readonly Version FeatureB = new Version(1, 1, 0);

            public static bool IsFeatureSupported(Version version)
            {
                return VersionUtility.GetRuntimeVersion() >= version;
            }
        }

        public class Version : IComparable<Version>
        {
            public readonly int Major;
            public readonly int Minor;
            public readonly int Patch;
            public readonly string Revision;

            public Version(int major, int minor, int patch, string revision = null)
            {
                Major = major;
                Minor = minor;
                Patch = patch;
                Revision = revision;
            }

            public override string ToString()
            {
                if (string.IsNullOrEmpty(Revision))
                {
                    return $"{Major}.{Minor}.{Patch}";
                }

                return $"{Major}.{Minor}.{Patch}({Revision})";
            }

            public int CompareTo(Version other)
            {
                var majorComparison = Major.CompareTo(other.Major);
                if (majorComparison != 0) return majorComparison;
                var minorComparison = Minor.CompareTo(other.Minor);
                if (minorComparison != 0) return minorComparison;
                var patchComparison = Patch.CompareTo(other.Patch);
                if (patchComparison != 0) return patchComparison;
                return 0;
            }

            public static bool operator <(Version v1, Version v2) => v1.CompareTo(v2) < 0;
            public static bool operator >(Version v1, Version v2) => v1.CompareTo(v2) > 0;
            public static bool operator <=(Version v1, Version v2) => v1.CompareTo(v2) <= 0;
            public static bool operator >=(Version v1, Version v2) => v1.CompareTo(v2) >= 0;
        }


        private static Version runtimeVersion = null;

        public static Version GetRuntimeVersion()
        {
            if (runtimeVersion != null)
            {
                return runtimeVersion;
            }

            string appVersion = UnityEngine.Application.version;
            int major = 0;
            int minor = 0;
            var split = appVersion.Split(".");
            if (split.Length > 0 && int.TryParse(split[0], out major))
            {
            }

            if (split.Length > 1 && int.TryParse(split[1], out minor))
            {
            }

            runtimeVersion = new Version(major, minor, patchVersion, revision);
            return runtimeVersion;
        }
    }
}