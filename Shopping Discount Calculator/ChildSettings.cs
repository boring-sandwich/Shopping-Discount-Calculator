using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.IsolatedStorage;
using System.Diagnostics;

namespace Shopping_Discount_Calculator
{
    public class ChildSettings
    {
        IsolatedStorageSettings settings;
        //const keynames
        const string ChildName01KeyName = "CName01";
        const string ChildName02KeyName = "CName02";
        const string ChildName03KeyName = "CName03";
        const string ChildName04KeyName = "CName04";
        const string ChildName05KeyName = "CName05";

        const string ChildSize01KeyName = "CSize01";
        const string ChildSize02KeyName = "CSize02";
        const string ChildSize03KeyName = "CSize03";
        const string ChildSize04KeyName = "CSize04";
        const string ChildSize05KeyName = "CSize05";
        //const defaults
        const string ChildName01Default = "default name 01";
        const string ChildName02Default = "default name 02";
        const string ChildName03Default = "default name 03";
        const string ChildName04Default = "default name 04";
        const string ChildName05Default = "default name 05";

        const string ChildSize01Default = "default size 01";
        const string ChildSize02Default = "default size 02";
        const string ChildSize03Default = "default size 03";
        const string ChildSize04Default = "default size 04";
        const string ChildSize05Default = "default size 05";

        //methods
        public ChildSettings()
        {
            //get the settings for this application
            settings = IsolatedStorageSettings.ApplicationSettings;
        }
        private bool AddOrUpdateValue(string Key, Object value)
        {
            bool valueChanged = false;
            if (settings.Contains(Key))
            {
                if (settings[Key] != value)
                {
                    settings[Key] = value;
                    valueChanged = true;
                }
            }
            else
            {
                settings.Add(Key, value);
                valueChanged = true;
            }
            return valueChanged;
        }
        private T GetValueOrDefault<T>(string Key, T defaultValue)
        {
            T value;
            if (settings.Contains(Key))
            {
                value = (T)settings[Key];
            }
            else
            {
                value = defaultValue;
            }
            return value;
        }
        public void Save()
        {
            settings.Save();
        }
        private void saveValue(string keyName, object value)
        {
            if (AddOrUpdateValue(keyName, value))
            {
                Save();
            }
        }
        //settings01
        public string CName01
        {
            get
            {
                return GetValueOrDefault<string>(ChildName01KeyName, ChildName01Default);
            }
            set
            {
                saveValue(ChildName01KeyName, value);
            }
        }
        public string CSize01
        {
            get
            {
                return GetValueOrDefault<string>(ChildSize01KeyName, ChildSize01Default);
            }
            set
            {
                saveValue(ChildSize01KeyName, value);
            }
        }
        //settings02
        public string CName02
        {
            get
            {
                return GetValueOrDefault<string>(ChildName02KeyName, ChildName02Default);
            }
            set
            {
                saveValue(ChildName02KeyName, value);
            }
        }
        public string CSize02
        {
            get
            {
                return GetValueOrDefault<string>(ChildSize02KeyName, ChildSize02Default);
            }
            set
            {
                saveValue(ChildSize02KeyName, value);
            }
        }
        //settings03
        public string CName03
        {
            get
            {
                return GetValueOrDefault<string>(ChildName03KeyName, ChildName03Default);
            }
            set
            {
                saveValue(ChildName03KeyName, value);
            }
        }
        public string CSize03
        {
            get
            {
                return GetValueOrDefault<string>(ChildSize03KeyName, ChildSize03Default);
            }
            set
            {
                saveValue(ChildSize03KeyName, value);
            }
        }
        //settings04
        public string CName04
        {
            get
            {
                return GetValueOrDefault<string>(ChildName04KeyName, ChildName04Default);
            }
            set
            {
                saveValue(ChildName04KeyName, value);
            }
        }
        public string CSize04
        {
            get
            {
                return GetValueOrDefault<string>(ChildSize04KeyName, ChildSize04Default);
            }
            set
            {
                saveValue(ChildSize04KeyName, value);
            }
        }
        //settings05
        public string CName05
        {
            get
            {
                return GetValueOrDefault<string>(ChildName05KeyName, ChildName05Default);
            }
            set
            {
                saveValue(ChildName05KeyName, value);
            }
        }
        public string CSize05
        {
            get
            {
                return GetValueOrDefault<string>(ChildSize05KeyName, ChildSize05Default);
            }
            set
            {
                saveValue(ChildSize05KeyName, value);
            }
        }
    }
}
