using SharpVectors.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Markup.Primitives;
using System.Windows.Media;
using System.Xml;

namespace Gadget {
    public class Settings {
        private static Settings instance = null;
        private static readonly object padlock = new object();

        Settings() { }

        public static Settings Instance {
            get {
                if (instance == null) {
                    lock (padlock) {
                        if (instance == null) {
                            instance = new Settings();
                        }
                    }
                }
                return instance;
            }
        }

        public void Save(string path) {
            //XmlXamlWriter xmlw = new XmlXamlWriter();
            //xmlw.Save(this, new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write));
            Xml(path, this);
        }

        void Xml(string path, object obj) {
            StringBuilder sb = new StringBuilder();
            XmlWriterSettings xmlws = new XmlWriterSettings();
            xmlws.Indent = true;
            xmlws.OmitXmlDeclaration = true;
            XmlWriter xml = XmlWriter.Create(sb, xmlws);
            XmlWrite(xml, Settings.Instance);
            xml.Close();
            string xmlcode = sb.ToString();
            using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write)) {
                byte[] xmlbyte = UTF8Encoding.UTF8.GetBytes(xmlcode);
                fs.Write(xmlbyte, 0, xmlbyte.Length);
                fs.Flush();
                fs.Close();
            }
        }

        bool _nullExtension = false;

        private void XmlWrite(XmlWriter xmlw, object obj) {
            MarkupObject markupObj = MarkupWriter.GetMarkupObjectFor(obj);
            Type objectType = markupObj.ObjectType;

            string nspace = objectType.Namespace;
            xmlw.WriteStartElement(objectType.Name, nspace);

            List<MarkupProperty> propertyElements = new List<MarkupProperty>();
            foreach (System.Windows.Markup.Primitives.MarkupProperty markupProp in markupObj.Properties) {
                if (!markupProp.IsComposite) {
                    string temp = markupProp.StringValue;
                    if (!string.IsNullOrEmpty(temp))
                        xmlw.WriteAttributeString(markupProp.Name, temp);
                } else if (markupProp.Value.GetType() == typeof(System.Windows.Markup.NullExtension)) {
                    if (_nullExtension) {
                        xmlw.WriteAttributeString(markupProp.Name, "{x:Null}");
                    }
                } else {
                    propertyElements.Add(markupProp);
                }
            }

            if (propertyElements.Count > 0) {
                foreach (MarkupProperty markupProp in propertyElements) {
                    string propElementName = markupObj.ObjectType.Name + "." + markupProp.Name;
                    xmlw.WriteStartElement(propElementName);

                    System.Collections.IList collection = markupProp.Value as System.Collections.IList;
                    System.Collections.IDictionary dictionary = markupProp.Value as System.Collections.IDictionary;
                    if (collection != null && collection.Count > 0) {
                        foreach (object iobj in collection) {
                            XmlWrite(xmlw, iobj);
                            xmlw.WriteEndElement();
                        }
                    } else if (dictionary != null && dictionary.Count > 0) {
                        foreach (object iobj in dictionary) {
                            XmlWrite(xmlw, iobj);
                            xmlw.WriteEndElement();
                        }
                    } else {
                        xmlw.WriteEndElement();
                    }
                }
            }
        }

        public void Initalise() { Events = new List<Event>(); }

        public void Initalise(string path) {
            try {
                Events = new List<Event>();
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read)) {
                    XmlDocument xmldoc = new XmlDocument();
                    xmldoc.Load(fs);
                    var xml = new XmlXamlReader();
                    xml.AddKnowedTypes(typeof(OnClickEvent));
                    xml.AddKnowedTypes(typeof(OnWheelEvent));
                    xml.Load(Instance, xmldoc);
                }
            } catch { }
        }

        //public static readonly DependencyProperty Background = DependencyProperty.Register(
        //    "Background", typeof(Brush), typeof(Settings), new PropertyMetadata());

        public Brush BackColor {
            get;
            set;
        } = new SolidColorBrush(Colors.Transparent);

        public List<Event> Events { get; set; }

        public bool UseColorization { get; set; }

        public bool Topmost { get; set; }

        public double Left { get; set; }

        public double Top { get; set; }
    }
}
