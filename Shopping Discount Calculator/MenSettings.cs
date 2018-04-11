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
    public class MenSettings
    {
        IsolatedStorageSettings settings;
        #region keynames
        const string menName01KeyName = "MName01";
        const string menName02KeyName = "MName02";
        const string menName03KeyName = "MName03";
        const string menName04KeyName = "MName04";
        const string menName05KeyName = "MName05";

        const string menSize01KeyName = "MSize01";
        const string menSize02KeyName = "MSize02";
        const string menSize03KeyName = "MSize03";
        const string menSize04KeyName = "MSize04";
        const string menSize05KeyName = "MSize05";

        const string menChest01KeyName = "MChest01";
        const string menChest02KeyName = "MChest02";
        const string menChest03KeyName = "MChest03";
        const string menChest04KeyName = "MChest04";
        const string menChest05KeyName = "MChest05";

        const string menShoulder01KeyName = "MShoulder01";
        const string menShoulder02KeyName = "MShoulder02";
        const string menShoulder03KeyName = "MShoulder03";
        const string menShoulder04KeyName = "MShoulder04";
        const string menShoulder05KeyName = "MShoulder05";

        const string menWaist01KeyName = "MWaist01";
        const string menWaist02KeyName = "MWaist02";
        const string menWaist03KeyName = "MWaist03";
        const string menWaist04KeyName = "MWaist04";
        const string menWaist05KeyName = "MWaist05";

        const string menInseem01KeyName = "MInseem01";
        const string menInseem02KeyName = "MInseem02";
        const string menInseem03KeyName = "MInseem03";
        const string menInseem04KeyName = "MInseem04";
        const string menInseem05KeyName = "MInseem05";

        const string menHip01KeyName = "MHip01";
        const string menHip02KeyName = "MHip02";
        const string menHip03KeyName = "MHip03";
        const string menHip04KeyName = "MHip04";
        const string menHip05KeyName = "MHip05";

        const string menSleeve01KeyName = "MSleeve01";
        const string menSleeve02KeyName = "MSleeve02";
        const string menSleeve03KeyName = "MSleeve03";
        const string menSleeve04KeyName = "MSleeve04";
        const string menSleeve05KeyName = "MSleeve05";

        const string menNeck01KeyName = "MNeck01";
        const string menNeck02KeyName = "MNeck02";
        const string menNeck03KeyName = "MNeck03";
        const string menNeck04KeyName = "MNeck04";
        const string menNeck05KeyName = "MNeck05";

        #endregion
        #region default values
        const string menName01Default = "default name 01";
        const string menName02Default = "default name 02";
        const string menName03Default = "default name 03";
        const string menName04Default = "default name 04";
        const string menName05Default = "default name 05";

        const string menSize01Default = "default size 01";
        const string menSize02Default = "default size 02";
        const string menSize03Default = "default size 03";
        const string menSize04Default = "default size 04";
        const string menSize05Default = "default size 05";

        const string menChest01Default = "00";
        const string menChest02Default = "00";
        const string menChest03Default = "00";
        const string menChest04Default = "00";
        const string menChest05Default = "00";

        const string menShoulder01Default = "00";
        const string menShoulder02Default = "00";
        const string menShoulder03Default = "00";
        const string menShoulder04Default = "00";
        const string menShoulder05Default = "00";

        const string menWaist01Default = "00";
        const string menWaist02Default = "00";
        const string menWaist03Default = "00";
        const string menWaist04Default = "00";
        const string menWaist05Default = "00";

        const string menInseem01Default = "00";
        const string menInseem02Default = "00";
        const string menInseem03Default = "00";
        const string menInseem04Default = "00";
        const string menInseem05Default = "00";

        const string menHip01Default = "00";
        const string menHip02Default = "00";
        const string menHip03Default = "00";
        const string menHip04Default = "00";
        const string menHip05Default = "00";

        const string menSleeve01Default = "00";
        const string menSleeve02Default = "00";
        const string menSleeve03Default = "00";
        const string menSleeve04Default = "00";
        const string menSleeve05Default = "00";

        const string menNeck01Default = "00";
        const string menNeck02Default = "00";
        const string menNeck03Default = "00";
        const string menNeck04Default = "00";
        const string menNeck05Default = "00";

        #endregion
        public MenSettings()
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
        private void SaveValue(string keyName, object value)
        {
            if (AddOrUpdateValue(keyName, value))
            {
                Save();
            }
        }
        #region settings01
        public string MName01
        {
            get
            {
                return GetValueOrDefault<string>(menName01KeyName, menName01Default);
            }
            set
            {
                SaveValue(menName01KeyName, value);
            }
        }
        public string MSize01
        {
            get
            {
                return GetValueOrDefault<string>(menSize01KeyName, menSize01Default);
            }
            set
            {
                SaveValue(menSize01KeyName, value);
            }
        }
        public string MChest01
        {
            get
            {
                return GetValueOrDefault<string>(menChest01KeyName, menChest01Default);
            }
            set
            {
                SaveValue(menChest01KeyName, value);
            }
        }
        public string MShoulder1
        {
            get
            {
                return GetValueOrDefault<string>(menShoulder01KeyName, menShoulder01Default);
            }
            set
            {
                SaveValue(menShoulder01KeyName, value);
            }
        }
        public string MWaist1
        {
            get
            {
                return GetValueOrDefault<string>(menWaist01KeyName, menWaist01Default);
            }
            set
            {
                SaveValue(menWaist01KeyName, value);
            }
        }
        public string MInseem1
        {
            get
            {
                return GetValueOrDefault<string>(menInseem01KeyName, menInseem01Default);
            }
            set
            {
                SaveValue(menInseem01KeyName, value);
            }
        }
        public string MHip1
        {
            get
            {
                return GetValueOrDefault<string>(menHip01KeyName, menHip01Default);
            }
            set
            {
                SaveValue(menHip01KeyName, value);
            }
        }
        public string MSleeve1
        {
            get
            {
                return GetValueOrDefault<string>(menSleeve01KeyName, menSleeve01Default);
            }
            set
            {
                SaveValue(menSleeve01KeyName, value);
            }
        }
        public string MNeck1
        {
            get
            {
                return GetValueOrDefault<string>(menNeck01KeyName, menNeck01Default);
            }
            set
            {
                SaveValue(menNeck01KeyName, value);
            }
        }
        #endregion
        #region settings02
        public string Name02
        {
            get
            {
                return GetValueOrDefault<string>(menName02KeyName, menName02Default);
            }
            set
            {
                SaveValue(menName02KeyName, value);
            }
        }
        public string Size02
        {
            get
            {
                return GetValueOrDefault<string>(menSize02KeyName, menSize02Default);
            }
            set
            {
                SaveValue(menSize02KeyName, value);
            }
        }
        public string Chest02
        {
            get
            {
                return GetValueOrDefault<string>(menChest02KeyName, menChest02Default);
            }
            set
            {
                SaveValue(menChest02KeyName, value);
            }
        }
        public string Shoulder2
        {
            get
            {
                return GetValueOrDefault<string>(menShoulder02KeyName, menShoulder02Default);
            }
            set
            {
                SaveValue(menShoulder02KeyName, value);
            }
        }
        public string Waist2
        {
            get
            {
                return GetValueOrDefault<string>(menWaist02KeyName, menWaist02Default);
            }
            set
            {
                SaveValue(menWaist02KeyName, value);
            }
        }
        public string Inseem2
        {
            get
            {
                return GetValueOrDefault<string>(menInseem02KeyName, menInseem02Default);
            }
            set
            {
                SaveValue(menInseem02KeyName, value);
            }
        }
        public string Hip2
        {
            get
            {
                return GetValueOrDefault<string>(menHip02KeyName, menHip02Default);
            }
            set
            {
                SaveValue(menHip02KeyName, value);
            }
        }
        public string Sleeve2
        {
            get
            {
                return GetValueOrDefault<string>(menSleeve02KeyName, menSleeve02Default);
            }
            set
            {
                SaveValue(menSleeve02KeyName, value);
            }
        }
        public string Neck2
        {
            get
            {
                return GetValueOrDefault<string>(menNeck02KeyName, menNeck02Default);
            }
            set
            {
                SaveValue(menNeck02KeyName, value);
            }
        }
        #endregion
        #region settings03
        public string Name03
        {
            get
            {
                return GetValueOrDefault<string>(menName03KeyName, menName03Default);
            }
            set
            {
                SaveValue(menName03KeyName, value);
            }
        }
        public string Size03
        {
            get
            {
                return GetValueOrDefault<string>(menSize03KeyName, menSize03Default);
            }
            set
            {
                SaveValue(menSize03KeyName, value);
            }
        }
        public string Chest03
        {
            get
            {
                return GetValueOrDefault<string>(menChest03KeyName, menChest03Default);
            }
            set
            {
                SaveValue(menChest03KeyName, value);
            }
        }
        public string Shoulder3
        {
            get
            {
                return GetValueOrDefault<string>(menShoulder03KeyName, menShoulder03Default);
            }
            set
            {
                SaveValue(menShoulder03KeyName, value);
            }
        }
        public string Waist3
        {
            get
            {
                return GetValueOrDefault<string>(menWaist03KeyName, menWaist03Default);
            }
            set
            {
                SaveValue(menWaist03KeyName, value);
            }
        }
        public string Inseem3
        {
            get
            {
                return GetValueOrDefault<string>(menInseem03KeyName, menInseem03Default);
            }
            set
            {
                SaveValue(menInseem03KeyName, value);
            }
        }
        public string Hip3
        {
            get
            {
                return GetValueOrDefault<string>(menHip03KeyName, menHip03Default);
            }
            set
            {
                SaveValue(menHip03KeyName, value);
            }
        }
        public string Sleeve3
        {
            get
            {
                return GetValueOrDefault<string>(menSleeve03KeyName, menSleeve03Default);
            }
            set
            {
                SaveValue(menSleeve03KeyName, value);
            }
        }
        public string Neck3
        {
            get
            {
                return GetValueOrDefault<string>(menNeck03KeyName, menNeck03Default);
            }
            set
            {
                SaveValue(menNeck03KeyName, value);
            }
        }
        #endregion
        #region settings04
        public string Name04
        {
            get
            {
                return GetValueOrDefault<string>(menName04KeyName, menName04Default);
            }
            set
            {
                SaveValue(menName04KeyName, value);
            }
        }
        public string Size04
        {
            get
            {
                return GetValueOrDefault<string>(menSize04KeyName, menSize04Default);
            }
            set
            {
                SaveValue(menSize04KeyName, value);
            }
        }
        public string Chest04
        {
            get
            {
                return GetValueOrDefault<string>(menChest04KeyName, menChest04Default);
            }
            set
            {
                SaveValue(menChest04KeyName, value);
            }
        }
        public string Shoulder4
        {
            get
            {
                return GetValueOrDefault<string>(menShoulder04KeyName, menShoulder04Default);
            }
            set
            {
                SaveValue(menShoulder04KeyName, value);
            }
        }
        public string Waist4
        {
            get
            {
                return GetValueOrDefault<string>(menWaist04KeyName, menWaist04Default);
            }
            set
            {
                SaveValue(menWaist02KeyName, value);
            }
        }
        public string Inseem4
        {
            get
            {
                return GetValueOrDefault<string>(menInseem04KeyName, menInseem04Default);
            }
            set
            {
                SaveValue(menInseem04KeyName, value);
            }
        }
        public string Hip4
        {
            get
            {
                return GetValueOrDefault<string>(menHip04KeyName, menHip04Default);
            }
            set
            {
                SaveValue(menHip04KeyName, value);
            }
        }
        public string Sleeve4
        {
            get
            {
                return GetValueOrDefault<string>(menSleeve04KeyName, menSleeve04Default);
            }
            set
            {
                SaveValue(menSleeve04KeyName, value);
            }
        }
        public string Neck4
        {
            get
            {
                return GetValueOrDefault<string>(menNeck04KeyName, menNeck04Default);
            }
            set
            {
                SaveValue(menNeck04KeyName, value);
            }
        }
        #endregion
        #region settings05
        public string Name05
        {
            get
            {
                return GetValueOrDefault<string>(menName05KeyName, menName05Default);
            }
            set
            {
                SaveValue(menName05KeyName, value);
            }
        }
        public string Size05
        {
            get
            {
                return GetValueOrDefault<string>(menSize05KeyName, menSize05Default);
            }
            set
            {
                SaveValue(menSize05KeyName, value);
            }
        }
        public string Chest05
        {
            get
            {
                return GetValueOrDefault<string>(menChest05KeyName, menChest05Default);
            }
            set
            {
                SaveValue(menChest05KeyName, value);
            }
        }
        public string Shoulder5
        {
            get
            {
                return GetValueOrDefault<string>(menShoulder05KeyName, menShoulder05Default);
            }
            set
            {
                SaveValue(menShoulder05KeyName, value);
            }
        }
        public string Waist5
        {
            get
            {
                return GetValueOrDefault<string>(menWaist05KeyName, menWaist05Default);
            }
            set
            {
                SaveValue(menWaist05KeyName, value);
            }
        }
        public string Inseem5
        {
            get
            {
                return GetValueOrDefault<string>(menInseem05KeyName, menInseem05Default);
            }
            set
            {
                SaveValue(menInseem05KeyName, value);
            }
        }
        public string Hip5
        {
            get
            {
                return GetValueOrDefault<string>(menHip05KeyName, menHip05Default);
            }
            set
            {
                SaveValue(menHip05KeyName, value);
            }
        }
        public string Sleeve5
        {
            get
            {
                return GetValueOrDefault<string>(menSleeve05KeyName, menSleeve05Default);
            }
            set
            {
                SaveValue(menSleeve05KeyName, value);
            }
        }
        public string Neck5
        {
            get
            {
                return GetValueOrDefault<string>(menNeck05KeyName, menNeck05Default);
            }
            set
            {
                SaveValue(menNeck05KeyName, value);
            }
        }
        #endregion
    }
}
