using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace WebUI.Utils {
    public static class ReflectHelper {
        public static dynamic GetDynamicObjectByString(string dllFile,string className) {
            var assemblyFilePath = AppDomain.CurrentDomain.BaseDirectory + dllFile;
            Assembly bllAssembly = Assembly.LoadFile(assemblyFilePath);
            Type type = bllAssembly.GetType(className);
            dynamic classInst = Activator.CreateInstance(type);
            return classInst;
        }
    }
}