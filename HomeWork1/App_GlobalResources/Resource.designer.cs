//------------------------------------------------------------------------------
// <auto-generated>
//     這段程式碼是由工具產生的。
//     執行階段版本:4.0.30319.42000
//
//     對這個檔案所做的變更可能會造成錯誤的行為，而且如果重新產生程式碼，
//     變更將會遺失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Resources {
    using System;
    
    
    /// <summary>
    ///   用於查詢當地語系化字串等的強型別資源類別。
    /// </summary>
    // 這個類別是自動產生的，是利用 StronglyTypedResourceBuilder
    // 類別透過 ResGen 或 Visual Studio 這類工具產生。
    // 若要加入或移除成員，請編輯您的 .ResX 檔，然後重新執行 ResGen
    // (利用 /str 選項)，或重建 Visual Studio 專案。
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Web.Application.StronglyTypedResourceProxyBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resource() {
        }
        
        /// <summary>
        ///   傳回這個類別使用的快取的 ResourceManager 執行個體。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Resources.Resource", global::System.Reflection.Assembly.Load("App_GlobalResources"));
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   覆寫目前執行緒的 CurrentUICulture 屬性，對象是所有
        ///   使用這個強型別資源類別的資源查閱。
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
        ///   查詢類似 選擇語言 的當地語系化字串。
        /// </summary>
        internal static string ChooseLanguage {
            get {
                return ResourceManager.GetString("ChooseLanguage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查詢類似 請先登入 的當地語系化字串。
        /// </summary>
        internal static string LoginFirst {
            get {
                return ResourceManager.GetString("LoginFirst", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查詢類似 主選單 的當地語系化字串。
        /// </summary>
        internal static string MainMenu {
            get {
                return ResourceManager.GetString("MainMenu", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查詢類似 {0} 為必填項目! 的當地語系化字串。
        /// </summary>
        internal static string Required {
            get {
                return ResourceManager.GetString("Required", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查詢類似 員工代碼 的當地語系化字串。
        /// </summary>
        internal static string StaNum {
            get {
                return ResourceManager.GetString("StaNum", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查詢類似 副選單 的當地語系化字串。
        /// </summary>
        internal static string SubMenu {
            get {
                return ResourceManager.GetString("SubMenu", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查詢類似 NCCUDefaultLanguage 的當地語系化字串。
        /// </summary>
        internal static string @__language {
            get {
                return ResourceManager.GetString("__language", resourceCulture);
            }
        }
    }
}