﻿using System;
using System.Windows.Forms;
using System.Reflection;

namespace VirtualModeListView
{
    partial class AboutBox1 : Form
    {
        public AboutBox1()
        {
            InitializeComponent();
           
            this.Text = String.Format("Info about {0}", AssemblyTitle);
            this.labelProductName.Text = AssemblyProduct;
            this.labelVersion.Text = String.Format("Version {0}", AssemblyVersion);
            this.labelCopyright.Text = AssemblyCopyright;
            this.labelCompanyName.Text = AssemblyCompany;
            this.textBoxDescription.Text = AssemblyDescription;
            
        }

        #region Assemblyattributaccessoren

        public string AssemblyTitle
        {
            get
            {
                // Alle Title-Attribute in dieser Assembly abrufen
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                // Wenn mindestens ein Title-Attribut vorhanden ist
                if (attributes.Length > 0)
                {
                    // Erstes auswählen
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    // Zurückgeben, wenn es keine leere Zeichenfolge ist
                    if (titleAttribute.Title != "")
                        return titleAttribute.Title;
                }
                // Wenn kein Title-Attribut vorhanden oder das Title-Attribut eine leere Zeichenfolge war, den EXE-Namen zurückgeben
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                // Alle Description-Attribute in dieser Assembly abrufen
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                // Eine leere Zeichenfolge zurückgeben, wenn keine Description-Attribute vorhanden sind
                if (attributes.Length == 0)
                    return "";
                // Den Wert des Description-Attributs zurückgeben, wenn eines vorhanden ist
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                // Alle Product-Attribute in dieser Assembly abrufen
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                // Eine leere Zeichenfolge zurückgeben, wenn keine Product-Attribute vorhanden sind
                if (attributes.Length == 0)
                    return "";
                // Den Wert des Product-Attributs zurückgeben, wenn eines vorhanden ist
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                // Alle Copyright-Attribute in dieser Assembly abrufen
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                // Eine leere Zeichenfolge zurückgeben, wenn keine Copyright-Attribute vorhanden sind
                if (attributes.Length == 0)
                    return "";
                // Den Wert des Copyright-Attributs zurückgeben, wenn eines vorhanden ist
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                // Alle Company-Attribute in dieser Assembly abrufen
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                // Eine leere Zeichenfolge zurückgeben, wenn keine Company-Attribute vorhanden sind
                if (attributes.Length == 0)
                    return "";
                // Den Wert des Company-Attributs zurückgeben, wenn eines vorhanden ist
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion
    }
}
