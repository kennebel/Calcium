﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Calcium
{
    public class SettingsManager : ISettings
    {
        public const string SETTINGS_FOLDER = "Calcium";
        public const string SETTINGS_FILE = "Calcium.jset";

        public Dictionary<string, Dictionary<string, string>> StoredSettings { get; set; }

        public SettingsManager()
        {
            StoredSettings = new Dictionary<string, Dictionary<string, string>>();
        }

        public void SetSetting(string module, string name, string value)
        {
            if (!StoredSettings.ContainsKey(module))
            {
                StoredSettings.Add(module, new Dictionary<string, string>());
            }
            StoredSettings[module][name] = value;
            Save();
        }

        public string GetSetting(string module, string name, bool nullOnNotFound = true)
        {
            if (StoredSettings.ContainsKey(module) && StoredSettings[module].ContainsKey(name))
            {
                return StoredSettings[module][name];
            }

            if (nullOnNotFound)
            {
                return null;
            }
            else
            {
                throw new Exception(string.Format("Setting not found: {0}/{1}", module, name));
            }
        }

        public static SettingsManager Load()
        {
            string SettingsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), SETTINGS_FOLDER, SETTINGS_FILE);
            try
            {
                if (File.Exists(SettingsPath))
                {
                    return JsonConvert.DeserializeObject<SettingsManager>(File.ReadAllText(SettingsPath));
                }
            }
            catch (Exception ex)
            {
                // TODO: Finish IError and raise an error
            }
            return new SettingsManager();
        }

        protected void Save()
        {
            string SettingsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), SETTINGS_FOLDER);
            try
            {
                if (!Directory.Exists(SettingsPath))
                {
                    Directory.CreateDirectory(SettingsPath);
                }

                SettingsPath = Path.Combine(SettingsPath, SETTINGS_FILE);
                File.WriteAllText(SettingsPath, JsonConvert.SerializeObject(this, Formatting.Indented));
            }
            catch (Exception ex)
            {
                // TODO: Finish IError and raise an error
            }
        }
    }
}
