using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;
using System.Windows.Forms;
using System.Globalization;
using System.Configuration;
using System.Xml.Linq;

namespace BeeSys.Wasp3D.Utility
{
    public static class WAssemblyManager
    {
        static List<String> _addInLoadPaths;

        static WAssemblyManager()
        {
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
            _addInLoadPaths = new List<string>();
        }
        public static bool ResolveFormDlls { get; set; }
        static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            try
            {
                string assemblyFileName = args.Name;
                if (assemblyFileName.EndsWith(".resources"))
                {                   
                    assemblyFileName = assemblyFileName.Substring(0, assemblyFileName.Length - ".resources".Length);                  
                }
                AssemblyName name = new AssemblyName(assemblyFileName);
                string assemblyName = name.Name + ".dll";
                lock (_addInLoadPaths)
                {
                    for (int pathCount = 0; pathCount < _addInLoadPaths.Count; pathCount++)
                    {
                        if (File.Exists(Path.Combine(_addInLoadPaths[pathCount], assemblyName)))
                        {
                            return Assembly.LoadFrom(Path.Combine(_addInLoadPaths[pathCount], assemblyName));
                        }
                    }
                }
                if (ResolveFormDlls)
                {
                    Assembly assembly = null;
                    foreach (Assembly asm in AppDomain.CurrentDomain.GetAssemblies())
                    {
                        if (asm.FullName == args.Name)
                        {
                            assembly = asm;
                        }
                    }
                    return assembly;
                }

            }
            catch (Exception ex)
            {
                //EventLogger.WriteLog(ModuleNameEnum.SharedLibraryAssemblyLoader, ex, args.Name);
            }
            return null;
        }




        public static void AddDefaultPath()
        {
            string sCommonPath = Environment.GetEnvironmentVariable("WaspCommon", EnvironmentVariableTarget.Machine);

            var STARTPATH = sCommonPath + "{0}Shared Resources";
            var LEGACYPATH = sCommonPath + "{0}Shared Resources{0}Legacy";


            var _64BITPATH = sCommonPath + "{0}Shared Resources{0}X64";

            if (Environment.Is64BitProcess)
            {

                //RESOLVE SHARED RESOURCE -> 64 BIT DLL
                WAssemblyManager.AddPath
                                       (
                                           Path.Combine
                                                       (
                                                           sCommonPath,
                                                           String.Format(CultureInfo.InvariantCulture, _64BITPATH, Path.DirectorySeparatorChar)
                                                       )
                                       );
            }


            //to Connect 5.9 LegacyKC
            //https://waspsource.beesys.com/Products/ClientHosts/-/issues/707
            var KC_LEGACYPATH = sCommonPath + "{0}Shared Resources{0}KCLegacy";
            bool bConnectKCLegacy = false;
            if (ConfigurationManager.AppSettings["ConnectKcLegacy"] != null)
            {
                string value = ConfigurationManager.AppSettings["ConnectKcLegacy"].ToString();
                if (string.Compare(value, Boolean.TrueString, true) == 0)
                {
                    bConnectKCLegacy = true;
                }
            }
            if(!bConnectKCLegacy)
            bConnectKCLegacy = CheckToConnectKCLegacy();
            if (bConnectKCLegacy)
            {

                string kcLegacyPath = Path.Combine(sCommonPath, String.Format(CultureInfo.InvariantCulture, KC_LEGACYPATH, Path.DirectorySeparatorChar));
                //RESOLVE KC Legacy SHARED RESOURCE
                WAssemblyManager.AddPath(kcLegacyPath);

                //Load the dll from KC legacy
                FileInfo[] files = null;
                DirectoryInfo directoryInfo = new DirectoryInfo(kcLegacyPath);
                files = directoryInfo.GetFiles("*.dll");
                if (files != null && files.Length > 0)
                {
                    foreach (FileInfo item in files)
                    {
                        Assembly.LoadFrom(item.FullName);
                    }
                }
            }

            //RESOLVE SHARED RESOURCE

            WAssemblyManager.AddPath
                                    (
                                        Path.Combine
                                                    (
                                                        sCommonPath,
                                                        String.Format(CultureInfo.InvariantCulture, STARTPATH, Path.DirectorySeparatorChar)
                                                    )
                                    );

            //RESOLVE SHARED RESOURCE LEGACY

            WAssemblyManager.AddPath
                                    (
                                        Path.Combine
                                                    (
                                                        sCommonPath,
                                                        String.Format(CultureInfo.InvariantCulture, LEGACYPATH, Path.DirectorySeparatorChar)
                                                    )
                                    );

        }

        //to Connect 5.9 LegacyKC
        //https://waspsource.beesys.com/Products/ClientHosts/-/issues/707
        private static bool CheckToConnectKCLegacy()
        {
            try
            {
                string sCommonPath = Environment.GetEnvironmentVariable("WaspCommon", EnvironmentVariableTarget.Machine);
                var STARTPATH = sCommonPath + "{0}CommonConfig.config";

                string CommonPath = Path.Combine(sCommonPath,String.Format(CultureInfo.InvariantCulture, STARTPATH, Path.DirectorySeparatorChar));
                if (File.Exists(CommonPath))
                {
                    string connectKCLegacy = string.Empty;
                    XDocument document = XDocument.Load(CommonPath);
                    if (document != null)
                    {
                        XElement element = document.Descendants("add").Where(x => x.Attribute("key").Value == "ConnectKcLegacy").FirstOrDefault();
                        if (element != null)
                        {
                            connectKCLegacy = element.Attribute("value").Value;
                            bool bConnectKCLegacy = false;
                            bool bValid = bool.TryParse(connectKCLegacy, out bConnectKCLegacy);

                            if (bValid)
                            {
                                return bConnectKCLegacy;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return false;
        }

        public static void AddPath(string basePath)
        {
            try
            {

                lock (_addInLoadPaths)
                {

                    if (!_addInLoadPaths.Contains(basePath.ToLowerInvariant()))
                        _addInLoadPaths.Add(basePath.ToLowerInvariant());
                }
            }
            catch (Exception ex)
            {
               /// EventLogger.WriteLog(ModuleNameEnum.SharedLibraryAssemblyLoader, ex, basePath);
            }
        }

        public static void RemovePath(string basePath)
        {
            try
            {
                lock (_addInLoadPaths)
                {
                    basePath = basePath.ToLowerInvariant();
                    if (_addInLoadPaths.Contains(basePath))
                        _addInLoadPaths.Remove(basePath);
                }
            }
            catch (Exception ex)
            {
                //EventLogger.WriteLog(ModuleNameEnum.SharedLibraryAssemblyLoader, ex, basePath);
            }
        }
    }
}
