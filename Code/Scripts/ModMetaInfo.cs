using System.Reflection;
using virtu9CommonLORUtil;

namespace virtu9WCorpPlus
{
    public static class ModMetaInfo
    {
        public static readonly Assembly assembly = Assembly.GetExecutingAssembly();
        public static readonly string path = ModMetaInfoLoader.LoadModPath(assembly);
        public static readonly string packageId = ModMetaInfoLoader.LoadPackageId(path);
    }
}
