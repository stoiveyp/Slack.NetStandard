﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Slack.NetStandard.Analyzers {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Slack.NetStandard.Analyzers.Resources", typeof(Resources).Assembly);
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
        ///   Looks up a localized string similar to All block types should have at least one empty and one helper constructors..
        /// </summary>
        internal static string BlockTypeDescription {
            get {
                return ResourceManager.GetString("BlockTypeDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Block type &apos;{0}&apos; is missing either an empty or helper constructor.
        /// </summary>
        internal static string BlockTypeMessageFormat {
            get {
                return ResourceManager.GetString("BlockTypeMessageFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Block type does not adhere to constructor rules.
        /// </summary>
        internal static string BlockTypeTitle {
            get {
                return ResourceManager.GetString("BlockTypeTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to All element types should have at least one empty and one helper constructors..
        /// </summary>
        internal static string ElementTypeDescription {
            get {
                return ResourceManager.GetString("ElementTypeDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Element type &apos;{0}&apos; is missing either an empty or helper constructor.
        /// </summary>
        internal static string ElementTypeMessageFormat {
            get {
                return ResourceManager.GetString("ElementTypeMessageFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Element type does not adhere to constructor rules.
        /// </summary>
        internal static string ElementTypeTitle {
            get {
                return ResourceManager.GetString("ElementTypeTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to All list properties must be newed in the property and have a ShouldSerialize method in case they&apos;re empty..
        /// </summary>
        internal static string ListNewDescription {
            get {
                return ResourceManager.GetString("ListNewDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to List Property &apos;{0}&apos; is not initialized.
        /// </summary>
        internal static string ListNewMessageFormat {
            get {
                return ResourceManager.GetString("ListNewMessageFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to List property missing initializer.
        /// </summary>
        internal static string ListNewTitle {
            get {
                return ResourceManager.GetString("ListNewTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to List properties should have a ShouldSerialize method in case they&apos;re empty..
        /// </summary>
        internal static string ListShouldSerializeDescription {
            get {
                return ResourceManager.GetString("ListShouldSerializeDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to List Property &apos;{0}&apos; does not have a corresponding ShouldSerialize{0} method.
        /// </summary>
        internal static string ListShouldSerializeMessageFormat {
            get {
                return ResourceManager.GetString("ListShouldSerializeMessageFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to List Property missing serialization method.
        /// </summary>
        internal static string ListShouldSerializeTitle {
            get {
                return ResourceManager.GetString("ListShouldSerializeTitle", resourceCulture);
            }
        }
    }
}
