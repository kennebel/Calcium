using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Calcium
{
    public class ModuleManager
    {
        public Page Overlay { get; set; }

        public Dictionary<string, List<ICalciumModule>> Modules { get; set; }

        public ModuleManager()
        {
            LoadModules();

            if (Modules.ContainsKey("calcium.overlay"))
            {
                Overlay = Modules["calcium.overlay"][0].OpeningPage; // TODO: Use settings to select proper one later
            }
        }

        protected void LoadModules()
        {
            Modules = new Dictionary<string, List<ICalciumModule>>();

            string[] Files = Directory.GetFiles(Environment.CurrentDirectory, "*.CalciumModule.dll");
            foreach (string OneFile in Files)
            {
                Assembly DLL = Assembly.LoadFile(OneFile);
                var Classes = DLL.GetExportedTypes();
                foreach (Type OneClass in Classes)
                {
                    if (OneClass.Name == "CalciumModule")
                    {
                        ICalciumModule CreateMe = Activator.CreateInstance(OneClass) as ICalciumModule;

                        if (CreateMe != null)
                        {
                            if (!Modules.ContainsKey(CreateMe.ModuleType)) { Modules.Add(CreateMe.ModuleType, new List<ICalciumModule>()); }
                            Modules[CreateMe.ModuleType].Add(CreateMe);
                        }
                    }
                }
            }
        }
    }
}
