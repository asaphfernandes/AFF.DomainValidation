﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AFF.ValidadorCore.Langs {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resource() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("AFF.ValidadorCore.Langs.Resource", typeof(Resource).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The field {0} is not in correct format..
        /// </summary>
        internal static string CpfAttribute {
            get {
                return ResourceManager.GetString("CpfAttribute", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The field {0} is not between {1} and {2}. Value: {3}..
        /// </summary>
        internal static string Validation_Between {
            get {
                return ResourceManager.GetString("Validation_Between", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The field {0} has not value.
        /// </summary>
        internal static string Validation_HasValue {
            get {
                return ResourceManager.GetString("Validation_HasValue", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The field {0} is not greater than {1}. Value: {2}..
        /// </summary>
        internal static string Validation_IsGreater {
            get {
                return ResourceManager.GetString("Validation_IsGreater", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The field {0} is not greater or equal than {1}. Value: {2}..
        /// </summary>
        internal static string Validation_IsGreaterOrEqual {
            get {
                return ResourceManager.GetString("Validation_IsGreaterOrEqual", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The field {0} is not less than {1}. Value: {2}..
        /// </summary>
        internal static string Validation_IsLess {
            get {
                return ResourceManager.GetString("Validation_IsLess", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The field {0} is not less or equal than {1}. Value: {2}..
        /// </summary>
        internal static string Validation_IsLessOrEqual {
            get {
                return ResourceManager.GetString("Validation_IsLessOrEqual", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Action need your confirmation..
        /// </summary>
        internal static string ValidationResponse_ALERT {
            get {
                return ResourceManager.GetString("ValidationResponse_ALERT", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Oops! An error has occurred..
        /// </summary>
        internal static string ValidationResponse_ERROR {
            get {
                return ResourceManager.GetString("ValidationResponse_ERROR", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Informações adicionais..
        /// </summary>
        internal static string ValidationResponse_INFO {
            get {
                return ResourceManager.GetString("ValidationResponse_INFO", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Ação realizada com sucesso..
        /// </summary>
        internal static string ValidationResponse_SUCCESS {
            get {
                return ResourceManager.GetString("ValidationResponse_SUCCESS", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Action performed, but needs future adjustments..
        /// </summary>
        internal static string ValidationResponse_WARNING {
            get {
                return ResourceManager.GetString("ValidationResponse_WARNING", resourceCulture);
            }
        }
    }
}
