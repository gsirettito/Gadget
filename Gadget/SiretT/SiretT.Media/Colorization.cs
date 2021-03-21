using Microsoft.Win32;
using SiretT.Converters;
using System;
using System.IO;
using System.Windows.Media;

namespace SiretT.Media {
    public static class ColorHelper {
        public static Color Colorization {
            get {
                try {
                    RegistryKey rk = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\DWM");
                    var value = Convert.ToString((int)rk.GetValue("ColorizationColor"), 16).Substring(2);
                    return Converter.HTMLColorToColor("#" + value);
                } catch {
                    try {
                        RegistryKey rk = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Themes");
                        string theme = (string)rk.GetValue("CurrentTheme", "");
                        using (StreamReader sr = new StreamReader(theme)) {
                            var txt = sr.ReadToEnd();
                            if (txt.Contains("ColorizationColor")) {
                                var indx = txt.IndexOf("ColorizationColor");
                                var value = txt.Substring(indx + "ColorizationColor".Length, txt.IndexOf("\r\n", indx) - (indx + "ColorizationColor".Length)).ToLower().Replace("=0x", "");
                                return Converter.HTMLColorToColor("#" + value);
                            }
                        }
                    } catch { }
                }
                return Color.FromArgb(255, 255, 255, 255);
            }
        }
    }
}
