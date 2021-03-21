using System;
using System.Text.RegularExpressions;
using System.Windows.Media;

namespace SiretT.Converters {
    public static class Converter {
        public static Color HTMLColorToColor(string colorString) {
            if (!String.IsNullOrEmpty(colorString)) {
                colorString = colorString.Replace(" ", "").ToLower();
                if (colorString.IndexOf("#") == colorString.LastIndexOf("#") && colorString.IndexOf("#") == 0)
                    if (Regex.IsMatch(colorString, "^#[a-f0-9]{8,8}$"))
                        return Color.FromArgb(
                            (byte)HexToInt(colorString.Substring(1, 2)),
                            (byte)HexToInt(colorString.Substring(3, 2)),
                            (byte)HexToInt(colorString.Substring(5, 2)),
                            (byte)HexToInt(colorString.Substring(7, 2)));
                    else if (Regex.IsMatch(colorString, "^#[a-f0-9]{6,6}$"))
                        return Color.FromArgb(
                            255,
                            (byte)HexToInt(colorString.Substring(1, 2)),
                            (byte)HexToInt(colorString.Substring(3, 2)),
                            (byte)HexToInt(colorString.Substring(5, 2)));
                    else if (Regex.IsMatch(colorString, "^#[a-f0-9]{4,4}$"))
                        return Color.FromArgb(
                            (byte)HexToInt(colorString.Substring(1, 1) + colorString.Substring(1, 1)),
                            (byte)HexToInt(colorString.Substring(2, 1) + colorString.Substring(2, 1)),
                            (byte)HexToInt(colorString.Substring(3, 1) + colorString.Substring(3, 1)),
                            (byte)HexToInt(colorString.Substring(4, 1) + colorString.Substring(4, 1)));
                    else if (Regex.IsMatch(colorString, "^#[a-f0-9]{3,3}$"))
                        return Color.FromArgb(
                            255,
                            (byte)HexToInt(colorString.Substring(1, 1) + colorString.Substring(1, 1)),
                            (byte)HexToInt(colorString.Substring(2, 1) + colorString.Substring(2, 1)),
                            (byte)HexToInt(colorString.Substring(3, 1) + colorString.Substring(3, 1)));
            }
            throw new Exception("Invalid string color format");
        }

        public static Color StringToColor(string colorString) {
            if (!String.IsNullOrEmpty(colorString)) {
                colorString = colorString.Replace(" ", "").ToLower();
                try { return HTMLColorToColor(colorString); } catch {
                    if (colorString.IndexOf("sc#") == colorString.LastIndexOf("sc#") && colorString.IndexOf("sc#") == 0)
                        if (Regex.IsMatch(colorString, "[0-9.]+")) {
                            var match = Regex.Matches(colorString, "[0-9.]+");
                            if (match.Count == 4
                                && match[match.Count - 1].Index + match[match.Count - 1].Length == colorString.Length)
                                return Color.FromScRgb(
                                    float.Parse(match[0].Value),
                                    float.Parse(match[1].Value),
                                    float.Parse(match[2].Value),
                                    float.Parse(match[3].Value));
                            else if (match.Count == 3
                                && match[match.Count - 1].Index + match[match.Count - 1].Length == colorString.Length)
                                return Color.FromScRgb(
                                    1f,
                                    float.Parse(match[0].Value),
                                    float.Parse(match[1].Value),
                                    float.Parse(match[2].Value));
                            if (match.Count == 1
                                 && match[match.Count - 1].Index + match[match.Count - 1].Length == colorString.Length)
                                return Color.FromScRgb(
                                    float.Parse(match[0].Value),
                                    float.Parse(match[1].Value),
                                    float.Parse(match[2].Value),
                                    float.Parse(match[3].Value));
                        }
                }
            }
            throw new Exception("Invalid string color format");
        }

        public static int HexToInt(string hexadecimal) {
            hexadecimal = hexadecimal.ToLower();
            if (Regex.IsMatch(hexadecimal, "^[a-f0-9]+"))
                return Convert.ToInt32(hexadecimal, 16);
            throw new Exception("El valor indicado no posee un formato correcto");
        }
    }
}
