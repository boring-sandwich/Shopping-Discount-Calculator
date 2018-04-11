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
    public class ShoeSettings
    {
        IsolatedStorageSettings settings;
        //const keynames
        #region keynames
        const string WName01KeyName = "WomenName01";
        const string WSize01KeyName = "WomenSize01";
        const string WName02KeyName = "WomenName02";
        const string WSize02KeyName = "WomenSize02";
        const string WName03KeyName = "WomenName03";
        const string WSize03KeyName = "WomenSize03";
        const string WName04KeyName = "WomenName04";
        const string WSize04KeyName = "WomenSize04";
        const string WName05KeyName = "WomenName05";
        const string WSize05KeyName = "WomenSize05";

        const string MName01KeyName = "MenName01";
        const string MSize01KeyName = "MenSize01";
        const string MName02KeyName = "MenName02";
        const string MSize02KeyName = "MenSize02";
        const string MName03KeyName = "MenName03";
        const string MSize03KeyName = "MenSize03";
        const string MName04KeyName = "MenName04";
        const string MSize04KeyName = "MenSize04";
        const string MName05KeyName = "MenName05";
        const string MSize05KeyName = "MenSize05";

        const string CName01KeyName = "ChildName01";
        const string CSize01KeyName = "ChildSize01";
        const string CName02KeyName = "ChildName02";
        const string CSize02KeyName = "ChildSize02";
        const string CName03KeyName = "ChildName03";
        const string CSize03KeyName = "ChildSize03";
        const string CName04KeyName = "ChildName04";
        const string CSize04KeyName = "ChildSize04";
        const string CName05KeyName = "ChildName05";
        const string CSize05KeyName = "ChildSize05";

        #endregion
        //const default values
        #region default
        const string WName01Default = "default name 01";
        const string WSize01Default = "00";
        const string WName02Default = "default name 02";
        const string WSize02Default = "00";
        const string WName03Default = "default name 03";
        const string WSize03Default = "00";
        const string WName04Default = "default name 04";
        const string WSize04Default = "00";
        const string WName05Default = "default name 05";
        const string WSize05Default = "00";

        const string MName01Default = "default name 01";
        const string MSize01Default = "00";
        const string MName02Default = "default name 02";
        const string MSize02Default = "00";
        const string MName03Default = "default name 03";
        const string MSize03Default = "00";
        const string MName04Default = "default name 04";
        const string MSize04Default = "00";
        const string MName05Default = "default name 05";
        const string MSize05Default = "00";

        const string CName01Default = "default name 01";
        const string CSize01Default = "00";
        const string CName02Default = "default name 02";
        const string CSize02Default = "00";
        const string CName03Default = "default name 03";
        const string CSize03Default = "00";
        const string CName04Default = "default name 04";
        const string CSize04Default = "00";
        const string CName05Default = "default name 05";
        const string CSize05Default = "00";

        #endregion
        public ShoeSettings()
        {
            //get the settings for this application
            settings = IsolatedStorageSettings.ApplicationSettings;
        }
        public bool AddOrUpdateValue(string Key, Object value)
        {
            bool valueChanged = false;
            if (settings.Contains(Key))
            {
                if (settings[Key]!= value)
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
        public T GetValueOrDefault<T>(string Key, T defaultValue)
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
        private void SaveValue(string keyName, object value)
        {
            if (AddOrUpdateValue(keyName, value))
            {
                Save();
            }
        }
        #region womens shoe saves
        public string WomenName01
        {
            get
            {
                return GetValueOrDefault<string>(WName01KeyName, WName01Default);
            }
            set
            {
                SaveValue(WName01KeyName, value);
            }
        }
        public string WomenSize01
        {
            get
            {
                return GetValueOrDefault<string>(WSize01KeyName, WSize01Default);
            }
            set
            {
                SaveValue(WSize01KeyName, value);
            }
        }
        public string WomenName02
        {
            get
            {
                return GetValueOrDefault<string>(WName02KeyName, WName02Default);
            }
            set
            {
                SaveValue(WName02KeyName, value);
            }
        }
        public string WomenSize02
        {
            get
            {
                return GetValueOrDefault<string>(WSize02KeyName, WSize02Default);
            }
            set
            {
                SaveValue(WSize02KeyName, value);
            }
        }
        public string WomenName03
        {
            get
            {
                return GetValueOrDefault<string>(WName03KeyName, WName03Default);
            }
            set
            {
                SaveValue(WName03KeyName, value);
            }
        }
        public string WomenSize03
        {
            get
            {
                return GetValueOrDefault<string>(WSize03KeyName, WSize03Default);
            }
            set
            {
                SaveValue(WSize03KeyName, value);
            }
        }
        public string WomenName04
        {
            get
            {
                return GetValueOrDefault<string>(WName04KeyName, WName04Default);
            }
            set
            {
                SaveValue(WName04KeyName, value);
            }
        }
        public string WomenSize04
        {
            get
            {
                return GetValueOrDefault<string>(WSize04KeyName, WSize04Default);
            }
            set
            {
                SaveValue(WSize04KeyName, value);
            }
        }
        public string WomenName05
        {
            get
            {
                return GetValueOrDefault<string>(WName05KeyName, WName05Default);
            }
            set
            {
                SaveValue(WName05KeyName, value);
            }
        }
        public string WomenSize05
        {
            get
            {
                return GetValueOrDefault<string>(WSize05KeyName, WSize05Default);
            }
            set
            {
                SaveValue(WSize05KeyName, value);
            }
        }
        #endregion
        #region men shoe saves
        public string MenName01
        {
            get
            {
                return GetValueOrDefault<string>(MName01KeyName, MName01Default);
            }
            set
            {
                SaveValue(MName01KeyName, value);
            }
        }
        public string MenSize01
        {
            get
            {
                return GetValueOrDefault<string>(MSize01KeyName, MSize01Default);
            }
            set
            {
                SaveValue(MSize01KeyName, value);
            }
        }
        public string MenName02
        {
            get
            {
                return GetValueOrDefault<string>(MName02KeyName, MName02Default);
            }
            set
            {
                SaveValue(MName02KeyName, value);
            }
        }
        public string MenSize02
        {
            get
            {
                return GetValueOrDefault<string>(MSize02KeyName, MSize01Default);
            }
            set
            {
                SaveValue(MSize02KeyName, value);
            }
        }
        public string MenName03
        {
            get
            {
                return GetValueOrDefault<string>(MName03KeyName, MName03Default);
            }
            set
            {
                SaveValue(MName03KeyName, value);
            }
        }
        public string MenSize03
        {
            get
            {
                return GetValueOrDefault<string>(MSize03KeyName, MSize03Default);
            }
            set
            {
                SaveValue(MSize03KeyName, value);
            }
        }
        public string MenName04
        {
            get
            {
                return GetValueOrDefault<string>(MName04KeyName, MName04Default);
            }
            set
            {
                SaveValue(MName04KeyName, value);
            }
        }
        public string MenSize04
        {
            get
            {
                return GetValueOrDefault<string>(MSize04KeyName, MSize04Default);
            }
            set
            {
                SaveValue(MSize04KeyName, value);
            }
        }
        public string MenName05
        {
            get
            {
                return GetValueOrDefault<string>(MName05KeyName, MName05Default);
            }
            set
            {
                SaveValue(MName05KeyName, value);
            }
        }
        public string MenSize05
        {
            get
            {
                return GetValueOrDefault<string>(MSize05KeyName, MSize05Default);
            }
            set
            {
                SaveValue(MSize05KeyName, value);
            }
        }
        #endregion
        #region child shoe saves
        public string ChildName01
        {
            get
            {
                return GetValueOrDefault<string>(WName01KeyName, WName01Default);
            }
            set
            {
                SaveValue(WName01KeyName, value);
            }
        }
        public string ChildSize01
        {
            get
            {
                return GetValueOrDefault<string>(CSize01KeyName, CSize01Default);
            }
            set
            {
                SaveValue(CSize01KeyName, value);
            }
        }
        public string ChildName02
        {
            get
            {
                return GetValueOrDefault<string>(WName02KeyName, WName02Default);
            }
            set
            {
                SaveValue(WName02KeyName, value);
            }
        }
        public string ChildSize02
        {
            get
            {
                return GetValueOrDefault<string>(CSize02KeyName, CSize01Default);
            }
            set
            {
                SaveValue(CSize02KeyName, value);
            }
        }
        public string ChildName03
        {
            get
            {
                return GetValueOrDefault<string>(WName03KeyName, WName03Default);
            }
            set
            {
                SaveValue(WName03KeyName, value);
            }
        }
        public string ChildSize03
        {
            get
            {
                return GetValueOrDefault<string>(CSize03KeyName, CSize03Default);
            }
            set
            {
                SaveValue(CSize03KeyName, value);
            }
        }
        public string ChildName04
        {
            get
            {
                return GetValueOrDefault<string>(WName04KeyName, WName04Default);
            }
            set
            {
                SaveValue(WName04KeyName, value);
            }
        }
        public string ChildSize04
        {
            get
            {
                return GetValueOrDefault<string>(CSize04KeyName, CSize04Default);
            }
            set
            {
                SaveValue(CSize04KeyName, value);
            }
        }
        public string ChildName05
        {
            get
            {
                return GetValueOrDefault<string>(WName05KeyName, WName05Default);
            }
            set
            {
                SaveValue(WName05KeyName, value);
            }
        }
        public string ChildSize05
        {
            get
            {
                return GetValueOrDefault<string>(CSize05KeyName, CSize05Default);
            }
            set
            {
                SaveValue(CSize05KeyName, value);
            }
        }
        #endregion
    }
}
