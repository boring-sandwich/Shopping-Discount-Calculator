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
    public class WomenSettings
    {
        IsolatedStorageSettings settings;
#region const keynames
        //the key names for the womens settings
        const string W01NameKeyName = "Name01";
        const string W01SizeKeyName = "Size01";
        const string W01BustKeyName = "Bust01";
        const string W01WaistKeyName = "Wasit01";
        const string W01HipKeyName = "Hip01";

        const string W02NameKeyName = "Name02";
        const string W02SizeKeyName = "Size02";
        const string W02BustKeyName = "Bust02";
        const string W02WaistKeyName = "Wasit02";
        const string W02HipKeyName = "Hip02";

        const string W03NameKeyName = "Name03";
        const string W03SizeKeyName = "Size03";
        const string W03BustKeyName = "Bust03";
        const string W03WaistKeyName = "Wasit03";
        const string W03HipKeyName = "Hip03";

        const string W04NameKeyName = "Name04";
        const string W04SizeKeyName = "Size04";
        const string W04BustKeyName = "Bust04";
        const string W04WaistKeyName = "Wasit04";
        const string W04HipKeyName = "Hip04";

        const string W05NameKeyName = "Name05";
        const string W05SizeKeyName = "Size05";
        const string W05BustKeyName = "Bust05";
        const string W05WaistKeyName = "Wasit05";
        const string W05HipKeyName = "Hip05";
#endregion
#region const default values
        //the default value for the womens settings
        const string W01NameDefault = "default name 01";
        const string W01SizeDefault = "default size 01";
        const string W01BustDefault = "00";
        const string W01WaistDefault = "00";
        const string W01HipDefault = "00";

        const string W02NameDefault = "default name 02";
        const string W02SizeDefault = "default size 02";
        const string W02BustDefault = "00";
        const string W02WaistDefault = "00";
        const string W02HipDefault = "00";

        const string W03NameDefault = "default name 03";
        const string W03SizeDefault = "default size 03";
        const string W03BustDefault = "00";
        const string W03WaistDefault = "00";
        const string W03HipDefault = "00";

        const string W04NameDefault = "default name 04";
        const string W04SizeDefault = "default size 04";
        const string W04BustDefault = "00";
        const string W04WaistDefault = "00";
        const string W04HipDefault = "00";

        const string W05NameDefault = "default name 05";
        const string W05SizeDefault = "default size 05";
        const string W05BustDefault = "00";
        const string W05WaistDefault = "00";
        const string W05HipDefault = "00";
#endregion
        public WomenSettings()
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
        private void Save()
        {
            settings.Save();
        }
#region settings01
        public string Name01
        {
            get
            {
                return GetValueOrDefault<string>(W01NameKeyName, W01NameDefault);
            }
            set
            {
                SaveValue(W01NameKeyName, value);
            }
        }
        public string Size01
        {
            get
            {
                return GetValueOrDefault<string>(W01SizeKeyName, W01SizeDefault);
            }
            set
            {
                SaveValue(W01SizeKeyName, value);
            }
        }
        public string Bust01
        {
            get
            {
                return GetValueOrDefault<string>(W01BustKeyName, W01BustDefault);
            }
            set
            {
                SaveValue(W01BustKeyName, value);
            }
        }
        public string Waist01
        {
            get
            {
                return GetValueOrDefault<string>(W01WaistKeyName, W01WaistDefault);
            }
            set
            {
                SaveValue(W01WaistKeyName, value);
            }
        }
        public string Hip01
        {
            get
            {
                return GetValueOrDefault<string>(W01HipKeyName, W01HipDefault);
            }
            set
            {
                SaveValue(W01HipKeyName, value);
            }
        }
#endregion
#region settings02
        public string Name02
        {
            get
            {
                return GetValueOrDefault<string>(W02NameKeyName, W02NameDefault);
            }
            set
            {
                SaveValue(W02NameKeyName, value);
            }
        }
        public string Size02
        {
            get
            {
                return GetValueOrDefault<string>(W02SizeKeyName, W02SizeDefault);
            }
            set
            {
                SaveValue(W02SizeKeyName, value);
            }
        }
        public string Bust02
        {
            get
            {
                return GetValueOrDefault<string>(W02BustKeyName, W02BustDefault);
            }
            set
            {
                SaveValue(W02BustKeyName, value);
            }
        }
        public string Waist02
        {
            get
            {
                return GetValueOrDefault<string>(W02WaistKeyName, W02WaistDefault);
            }
            set
            {
                SaveValue(W02WaistKeyName, value);
            }
        }
        public string Hip02
        {
            get
            {
                return GetValueOrDefault<string>(W02HipKeyName, W02HipDefault);
            }
            set
            {
                SaveValue(W02HipKeyName, value);
            }
        }
#endregion
#region settings03
        public string Name03
        {
            get
            {
                return GetValueOrDefault<string>(W03NameKeyName, W03NameDefault);
            }
            set
            {
                SaveValue(W03NameKeyName, value);
            }
        }
        public string Size03
        {
            get
            {
                return GetValueOrDefault<string>(W03SizeKeyName, W03SizeDefault);
            }
            set
            {
                SaveValue(W03SizeKeyName, value);
            }
        }
        public string Bust03
        {
            get
            {
                return GetValueOrDefault<string>(W03BustKeyName, W03BustDefault);
            }
            set
            {
                SaveValue(W03BustKeyName, value);
            }
        }
        public string Waist03
        {
            get
            {
                return GetValueOrDefault<string>(W03WaistKeyName, W03WaistDefault);
            }
            set
            {
                SaveValue(W03WaistKeyName, value);
            }
        }
        public string Hip03
        {
            get
            {
                return GetValueOrDefault<string>(W03HipKeyName, W03HipDefault);
            }
            set
            {
                SaveValue(W03HipKeyName, value);
            }
        }
#endregion
#region settings04
        public string Name04
        {
            get
            {
                return GetValueOrDefault<string>(W04NameKeyName, W04NameDefault);
            }
            set
            {
                SaveValue(W04NameKeyName, value);
            }
        }
        public string Size04
        {
            get
            {
                return GetValueOrDefault<string>(W04SizeKeyName, W04SizeDefault);
            }
            set
            {
                SaveValue(W04SizeKeyName, value);
            }
        }
        public string Bust04
        {
            get
            {
                return GetValueOrDefault<string>(W04BustKeyName, W04BustDefault);
            }
            set
            {
                SaveValue(W04BustKeyName, value);
            }
        }
        public string Waist04
        {
            get
            {
                return GetValueOrDefault<string>(W04WaistKeyName, W04WaistDefault);
            }
            set
            {
                SaveValue(W04WaistKeyName, value);
            }
        }
        public string Hip04
        {
            get
            {
                return GetValueOrDefault<string>(W04HipKeyName, W04HipDefault);
            }
            set
            {
                SaveValue(W04HipKeyName, value);
            }
        }
#endregion
#region settings05
        public string Name05
        {
            get
            {
                return GetValueOrDefault<string>(W05NameKeyName, W05NameDefault);
            }
            set
            {
                SaveValue(W05NameKeyName, value);
            }
        }
        public string Size05
        {
            get
            {
                return GetValueOrDefault<string>(W05SizeKeyName, W05SizeDefault);
            }
            set
            {
                SaveValue(W05SizeKeyName, value);
            }
        }
        public string Bust05
        {
            get
            {
                return GetValueOrDefault<string>(W05BustKeyName, W05BustDefault);
            }
            set
            {
                SaveValue(W05BustKeyName, value);
            }
        }
        public string Waist05
        {
            get
            {
                return GetValueOrDefault<string>(W05WaistKeyName, W05WaistDefault);
            }
            set
            {
                SaveValue(W05WaistKeyName, value);
            }
        }
        public string Hip05
        {
            get
            {
                return GetValueOrDefault<string>(W05HipKeyName, W05HipDefault);
            }
            set
            {
                SaveValue(W05HipKeyName, value);
            }
        }
#endregion
        private void SaveValue(string keyName, object value)
        {
            if (AddOrUpdateValue(keyName, value))
	        {
		         Save();
	        }
        }
    }
}
