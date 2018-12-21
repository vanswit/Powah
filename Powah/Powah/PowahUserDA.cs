using System;
using System.Collections.Generic;
using System.Text;

namespace Powah
{
    public static class PowahUserDA
    {
        public static void SaveToSettings(PowahUser powahUser)
        {
            try
            {
                Plugin.Settings.CrossSettings.Current.AddOrUpdateValue("UserName", powahUser.UserName, "PowahSettings");
                Plugin.Settings.CrossSettings.Current.AddOrUpdateValue("Age", powahUser.Age, "PowahSettings");
                Plugin.Settings.CrossSettings.Current.AddOrUpdateValue("Weigth", powahUser.Weigth, "PowahSettings");
                Plugin.Settings.CrossSettings.Current.AddOrUpdateValue("DeadliftMax", powahUser.DeadliftMax, "PowahSettings");
                Plugin.Settings.CrossSettings.Current.AddOrUpdateValue("FlatBenchMax", powahUser.FlatBenchMax, "PowahSettings");
                Plugin.Settings.CrossSettings.Current.AddOrUpdateValue("SquatMax", powahUser.SquatMax, "PowahSettings");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static PowahUser GetUser()
        {
            string UserName = "";
            int Age = 0;
            int Weigth = 0;
            int DeadliftMax = 0;
            int FlatbenchMax = 0;
            int SquatMax = 0;

            try
            {
                UserName = Plugin.Settings.CrossSettings.Current.GetValueOrDefault("UserName", "", "PowahSettings");
                Age = Plugin.Settings.CrossSettings.Current.GetValueOrDefault("Age", 0, "PowahSettings");
                Weigth = Plugin.Settings.CrossSettings.Current.GetValueOrDefault("Weigth", 0, "PowahSettings");
                DeadliftMax = Plugin.Settings.CrossSettings.Current.GetValueOrDefault("DeadliftMax", 0, "PowahSettings");
                FlatbenchMax = Plugin.Settings.CrossSettings.Current.GetValueOrDefault("FlatBenchMax", 0, "PowahSettings");
                SquatMax = Plugin.Settings.CrossSettings.Current.GetValueOrDefault("SquatMax", 0, "PowahSettings");
            }
            catch (Exception ex)
            {
                throw ex;
            }

            PowahUser user = new PowahUser(UserName, Age, Weigth, DeadliftMax, FlatbenchMax, SquatMax);

            return user;
        }
    }
}
