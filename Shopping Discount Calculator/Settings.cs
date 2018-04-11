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
    public class Settings
    {
        // Our settings
        IsolatedStorageSettings settings;

        // The key names of our settings 
        const string TaxSettingKeyName = "TaxSetting";
        const string TaxRadPoundKeyName = "RadPound";
        const string TaxRadDollarKeyName = "RadDollar";
        const string TaxRadEuroKeyName = "RadEuro";
        //const for women
        const string WCountryUKKeyName = "RadWCountryUK";
        const string WCountryUSKeyName = "RadWCountryUS";
        const string WCountryEUKeyName = "RadWCountryEU";
        const string WCountryAUKeyName = "RadWCountryAU";

        const string WShoeUKKeyName = "RadWMeasurementsUK";
        const string WShoeUSKeyName = "RadWMeasurementsUS";
        const string WShoeEUKeyName = "RadWMeasurementsEU";
        const string WShoeAUKeyName = "RadWMeasurementsAU";
        //const for men
        const string MCountryUSKeyName = "RadMCountryUS";
        const string MCountryEUKeyName = "RadMCountryEU";

        const string MShoeUKKeyName = "RadmMeasurementsUK";
        const string MShoeUSKeyName = "RadmMeasurementsUS";
        const string MShoeEUKeyName = "RadmMeasurementsEU";
        //const for child
        const string CCountryUKKeyName = "RadCCountryUK";
        const string CCountryUSKeyName = "RadCCountryUS";
        const string CCountryEUKeyName = "RadCCountryEU";
        const string CCountryAUKeyName = "RadCCountryAU";

        const string CShoeUKKeyName = "RadCMeasurementsUK";
        const string CShoeUSKeyName = "RadCMeasurementsUS";
        const string CShoeEUKeyName = "RadCMeasurementsEU";

        // The default value of our settings
        const double TaxSettingDefault = 0;
        const bool TaxRadPoundDefault = false;
        const bool TaxRadDollarDefault = true;
        const bool TaxRadEuroDefault = false;
        //const for women
        const bool WCountryUKDefault = false;
        const bool WCountryUSDefault = false;
        const bool WCountryEUDefault = false;
        const bool WCountryAUDefault = false;

        const bool WShoeUKDefault = false;
        const bool WShoeUSDefault = false;
        const bool WShoeEUDefault = false;
        const bool WShoeAUDefault = false;
        //const for men
        const bool MCountryUSDefault = false;
        const bool MCountryEUDefault = false;

        const bool MShoeUKDefault = false;
        const bool MShoeUSDefault = false;
        const bool MShoeEUDefault = false;
        //const for child
        const bool CCountryUKDefault = false;
        const bool CCountryUSDefault = false;
        const bool CCountryEUDefault = false;
        const bool CCountryAUDefault = false;

        const bool CShoeUKDefault = false;
        const bool CShoeUSDefault = false;
        const bool CShoeEUDefault = false;
        public Settings()
        {
            // Get the settings for this application.
            settings = IsolatedStorageSettings.ApplicationSettings;
        }
        /// <summary>
        /// Update a setting value for our application. If the setting does not
        /// exist, then add the setting.
        /// </summary>
        /// <param name="Key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool AddOrUpdateValue(string Key, Object value)
        {
            bool valueChanged = false;

            // If the key exists
            if (settings.Contains(Key))
            {
                // If the value has changed
                if (settings[Key] != value)
                {
                    // Store the new value
                    settings[Key] = value;
                    valueChanged = true;
                }
            }
            // Otherwise create the key.
            else
            {
                settings.Add(Key, value);
                valueChanged = true;
            }
            return valueChanged;
        }
        /// <summary>
        /// Get the current value of the setting, or if it is not found, set the 
        /// setting to the default setting.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        
        public T GetValueOrDefault<T>(string Key, T defaultValue)
        {
            T value;

            // If the key exists, retrieve the value.
            if (settings.Contains(Key))
            {
                value = (T)settings[Key];
            }
            // Otherwise, use the default value.
            else
            {
                value = defaultValue;
            }
            return value;
        }
        /// <summary>
        /// Save the settings.
        /// </summary>
        public void Save()
        {
            settings.Save();
        }
        /// <summary>
        /// Property to get and set the tax input value Setting Key.
        /// </summary>
        #region taxes
        public double TaxSetting
        {
            get
            {
                return GetValueOrDefault<double>(TaxSettingKeyName, TaxSettingDefault);
            }
            set
            {
                SaveValue(TaxSettingKeyName, value);
            }
        }
        public bool TaxRadPound
        {
            get
            {
                return GetValueOrDefault<bool>(TaxRadPoundKeyName, TaxRadPoundDefault);
            }
            set
            {
                SaveValue(TaxRadPoundKeyName, value);
            }
        }
        public bool TaxRadDollar
        {
            get
            {
                return GetValueOrDefault<bool>(TaxRadDollarKeyName, TaxRadDollarDefault);
            }
            set
            {
                SaveValue(TaxRadDollarKeyName, value);
            }
        }
        public bool TaxRadEuro
        {
            get
            {
                return GetValueOrDefault<bool>(TaxRadEuroKeyName, TaxRadEuroDefault);
            }
            set
            {
                SaveValue(TaxRadEuroKeyName, value);
            }
        }

        private void SaveValue(string keyName, object value)
        {
            if (AddOrUpdateValue(keyName, value))
            {
                Save();
            }
        }
        #endregion
        #region women
        public bool RadWCountryUK
        {
            get
            {
                return GetValueOrDefault<bool>(WCountryUKKeyName, WCountryUKDefault);
            }
            set
            {
                SaveValue(WCountryUKKeyName, value);
            }
        }
        public bool RadWCountryUS
        {
            get
            {
                return GetValueOrDefault<bool>(WCountryUSKeyName, WCountryUSDefault);
            }
            set
            {
                SaveValue(WCountryUSKeyName, value);
            }
        }
        public bool RadWCountryEU
        {
            get
            {
                return GetValueOrDefault<bool>(WCountryEUKeyName, WCountryEUDefault);
            }
            set
            {
                SaveValue(WCountryEUKeyName, value);
            }
        }
        public bool RadWCountryAU
        {
            get
            {
                return GetValueOrDefault<bool>(WCountryAUKeyName, WCountryAUDefault);
            }
            set
            {
                SaveValue(WCountryAUKeyName, value);
            }
        }
        public bool RadWShoeUK
        {
            get
            {
                return GetValueOrDefault<bool>(WShoeUKKeyName, WShoeUKDefault);
            }
            set
            {
                SaveValue(WShoeUKKeyName, value);
            }
        }
        public bool RadWShoeUS
        {
            get
            {
                return GetValueOrDefault<bool>(WShoeUSKeyName, WShoeUSDefault);
            }
            set
            {
                SaveValue(WShoeUSKeyName, value);
            }
        }
        public bool RadWShoeEU
        {
            get
            {
                return GetValueOrDefault<bool>(WShoeEUKeyName, WShoeEUDefault);
            }
            set
            {
                SaveValue(WShoeEUKeyName, value);
            }
        }
        public bool RadWShoeAU
        {
            get
            {
                return GetValueOrDefault<bool>(WShoeAUKeyName, WShoeAUDefault);
            }
            set
            {
                SaveValue(WShoeAUKeyName, value);
            }
        }
#endregion
        #region men
        public bool RadMCountryUS
        {
            get
            {
                return GetValueOrDefault<bool>(MCountryUSKeyName, MCountryUSDefault);
            }
            set
            {
                SaveValue(MCountryUSKeyName, value);
            }
        }
        public bool RadMCountryEU
        {
            get
            {
                return GetValueOrDefault<bool>(MCountryEUKeyName, MCountryEUDefault);
            }
            set
            {
                SaveValue(MCountryEUKeyName, value);
            }
        }
        public bool RadMShoeUK
        {
            get
            {
                return GetValueOrDefault<bool>(MShoeUKKeyName, MShoeUKDefault);
            }
            set
            {
                SaveValue(MShoeUKKeyName, value);
            }
        }
        public bool RadMShoeUS
        {
            get
            {
                return GetValueOrDefault<bool>(MShoeUSKeyName, MShoeUSDefault);
            }
            set
            {
                SaveValue(WShoeUSKeyName, value);
            }
        }
        public bool RadMShoeEU
        {
            get
            {
                return GetValueOrDefault<bool>(MShoeEUKeyName, MShoeEUDefault);
            }
            set
            {
                SaveValue(MShoeEUKeyName, value);
            }
        }

#endregion
        #region child
        public bool RadCCountryUK
        {
            get
            {
                return GetValueOrDefault<bool>(CCountryUKKeyName, CCountryUKDefault);
            }
            set
            {
                SaveValue(CCountryUKKeyName, value);
            }
        }
        public bool RadCCountryUS
        {
            get
            {
                return GetValueOrDefault<bool>(CCountryUSKeyName, CCountryUSDefault);
            }
            set
            {
                SaveValue(CCountryUSKeyName, value);
            }
        }
        public bool RadCCountryEU
        {
            get
            {
                return GetValueOrDefault<bool>(CCountryEUKeyName, CCountryEUDefault);
            }
            set
            {
                SaveValue(CCountryEUKeyName, value);
            }
        }
        public bool RadCCountryAU
        {
            get
            {
                return GetValueOrDefault<bool>(CCountryAUKeyName, CCountryAUDefault);
            }
            set
            {
                SaveValue(CCountryAUKeyName, value);
            }
        }
        public bool RadCShoeUK
        {
            get
            {
                return GetValueOrDefault<bool>(CShoeUKKeyName, CShoeUKDefault);
            }
            set
            {
                SaveValue(CShoeUKKeyName, value);
            }
        }
        public bool RadCShoeUS
        {
            get
            {
                return GetValueOrDefault<bool>(CShoeUSKeyName, CShoeUSDefault);
            }
            set
            {
                SaveValue(CShoeUSKeyName, value);
            }
        }
        public bool RadCShoeEU
        {
            get
            {
                return GetValueOrDefault<bool>(CShoeEUKeyName, CShoeEUDefault);
            }
            set
            {
                SaveValue(CShoeEUKeyName, value);
            }
        }
        #endregion
    }
}