//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PropertyGridTest.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.8.1.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Normal")]
        public global::System.Windows.Forms.FormWindowState MainFormState {
            get {
                return ((global::System.Windows.Forms.FormWindowState)(this["MainFormState"]));
            }
            set {
                this["MainFormState"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::System.Drawing.Size MainFormSize {
            get {
                return ((global::System.Drawing.Size)(this["MainFormSize"]));
            }
            set {
                this["MainFormSize"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::System.Drawing.Point MainFormLocation {
            get {
                return ((global::System.Drawing.Point)(this["MainFormLocation"]));
            }
            set {
                this["MainFormLocation"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public int GridSplitterPos {
            get {
                return ((int)(this["GridSplitterPos"]));
            }
            set {
                this["GridSplitterPos"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::System.Drawing.Size PhoneNumbersCollectFormSize {
            get {
                return ((global::System.Drawing.Size)(this["PhoneNumbersCollectFormSize"]));
            }
            set {
                this["PhoneNumbersCollectFormSize"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::System.Drawing.Point PhoneNumbersCollectFormLocation {
            get {
                return ((global::System.Drawing.Point)(this["PhoneNumbersCollectFormLocation"]));
            }
            set {
                this["PhoneNumbersCollectFormLocation"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Normal")]
        public global::System.Windows.Forms.FormWindowState PhoneNumbersCollectFormState {
            get {
                return ((global::System.Windows.Forms.FormWindowState)(this["PhoneNumbersCollectFormState"]));
            }
            set {
                this["PhoneNumbersCollectFormState"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"<?xml version=""1.0"" encoding=""utf-16""?>
<ArrayOfString xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <string>Уборщик</string>
  <string>Директор</string>
  <string>Инженер</string>
  <string>Начальник отдела</string>
  <string>Начальник сектора</string>
  <string>Секретарь</string>
  <string>Заместитель директора</string>
</ArrayOfString>")]
        public global::System.Collections.Specialized.StringCollection PostList {
            get {
                return ((global::System.Collections.Specialized.StringCollection)(this["PostList"]));
            }
            set {
                this["PostList"] = value;
            }
        }
    }
}
