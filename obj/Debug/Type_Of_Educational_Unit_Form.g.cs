﻿#pragma checksum "..\..\Type_Of_Educational_Unit_Form.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "A114C7D9F686E7D57F6A715A9AD3E2D95D1E5D0A80CEE339BF29109026826A59"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using NLP_Create;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace NLP_Create {
    
    
    /// <summary>
    /// Type_Of_Educational_Unit_Form
    /// </summary>
    public partial class Type_Of_Educational_Unit_Form : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\Type_Of_Educational_Unit_Form.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgType_Of_Educational_Unit;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\Type_Of_Educational_Unit_Form.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbNumber_Of_Type;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\Type_Of_Educational_Unit_Form.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbFindValue;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\Type_Of_Educational_Unit_Form.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btSearch;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\Type_Of_Educational_Unit_Form.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btFilter;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\Type_Of_Educational_Unit_Form.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btCancel;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\Type_Of_Educational_Unit_Form.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btInsert;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\Type_Of_Educational_Unit_Form.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btUpdate;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\Type_Of_Educational_Unit_Form.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btDelete;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/NLP_Create;component/type_of_educational_unit_form.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Type_Of_Educational_Unit_Form.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 16 "..\..\Type_Of_Educational_Unit_Form.xaml"
            ((NLP_Create.Type_Of_Educational_Unit_Form)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.dgType_Of_Educational_Unit = ((System.Windows.Controls.DataGrid)(target));
            
            #line 19 "..\..\Type_Of_Educational_Unit_Form.xaml"
            this.dgType_Of_Educational_Unit.AutoGeneratingColumn += new System.EventHandler<System.Windows.Controls.DataGridAutoGeneratingColumnEventArgs>(this.DgType_Of_Educational_Unit_AutoGeneratingColumn);
            
            #line default
            #line hidden
            return;
            case 3:
            this.tbNumber_Of_Type = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.tbFindValue = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.btSearch = ((System.Windows.Controls.Button)(target));
            
            #line 31 "..\..\Type_Of_Educational_Unit_Form.xaml"
            this.btSearch.Click += new System.Windows.RoutedEventHandler(this.btSearch_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btFilter = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\Type_Of_Educational_Unit_Form.xaml"
            this.btFilter.Click += new System.Windows.RoutedEventHandler(this.btFilter_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btCancel = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\Type_Of_Educational_Unit_Form.xaml"
            this.btCancel.Click += new System.Windows.RoutedEventHandler(this.btCancel_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btInsert = ((System.Windows.Controls.Button)(target));
            
            #line 37 "..\..\Type_Of_Educational_Unit_Form.xaml"
            this.btInsert.Click += new System.Windows.RoutedEventHandler(this.btInsert_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btUpdate = ((System.Windows.Controls.Button)(target));
            
            #line 39 "..\..\Type_Of_Educational_Unit_Form.xaml"
            this.btUpdate.Click += new System.Windows.RoutedEventHandler(this.btUpdate_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.btDelete = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\Type_Of_Educational_Unit_Form.xaml"
            this.btDelete.Click += new System.Windows.RoutedEventHandler(this.btDelete_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

