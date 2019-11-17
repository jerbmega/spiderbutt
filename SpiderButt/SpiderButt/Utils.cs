using System;
using System.Linq;
using System.Reflection;
        
namespace SpiderButt
{
    public class Utils
    {
        public Type[] GetTypesInNamespace(Assembly assembly, string nameSpace)
        {
            return 
                assembly.GetTypes()
                    .Where(t => String.Equals(t.Namespace, nameSpace, StringComparison.Ordinal))
                    .ToArray();
        }

        public void ExecuteEvents(string event_id, string namespace_id = "SpiderButt.Mods")
        {
            Type[] EventType = GetTypesInNamespace(Assembly.GetExecutingAssembly(), namespace_id);
            if(EventType != null)
            {
                for (int i = 0; i < EventType.Length; i++)
                {
                    MethodInfo methodInfo = EventType[i].GetMethod(event_id);
                    try
                    {
                        methodInfo.Invoke(Activator.CreateInstance(EventType[i], null), null);
                    }
                    catch{}
                }
            }
        }
    }
}