﻿#pragma checksum "..\..\..\Pages\SaleItemsPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "9DB4F3B5624F91E190318ABBF21FB21D196A736E063C1C1AFB5D2656A488EBA9"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Computer.Pages;
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


namespace Computer.Pages {
    
    
    /// <summary>
    /// SaleItems
    /// </summary>
    public partial class SaleItems : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 20 "..\..\..\Pages\SaleItemsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CbSort;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\Pages\SaleItemsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CbFilter;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\Pages\SaleItemsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TbSearch;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\Pages\SaleItemsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DGridSaleItems;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\Pages\SaleItemsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnDelete;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\Pages\SaleItemsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnAdd;
        
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
            System.Uri resourceLocater = new System.Uri("/Computer;component/pages/saleitemspage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\SaleItemsPage.xaml"
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
            
            #line 9 "..\..\..\Pages\SaleItemsPage.xaml"
            ((Computer.Pages.SaleItems)(target)).Loaded += new System.Windows.RoutedEventHandler(this.SaleItems_OnLoaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.CbSort = ((System.Windows.Controls.ComboBox)(target));
            
            #line 20 "..\..\..\Pages\SaleItemsPage.xaml"
            this.CbSort.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.CbSort_OnSelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.CbFilter = ((System.Windows.Controls.ComboBox)(target));
            
            #line 22 "..\..\..\Pages\SaleItemsPage.xaml"
            this.CbFilter.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.CbFilter_OnSelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.TbSearch = ((System.Windows.Controls.TextBox)(target));
            
            #line 24 "..\..\..\Pages\SaleItemsPage.xaml"
            this.TbSearch.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TbSearch_OnTextChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.DGridSaleItems = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 7:
            this.BtnDelete = ((System.Windows.Controls.Button)(target));
            
            #line 46 "..\..\..\Pages\SaleItemsPage.xaml"
            this.BtnDelete.Click += new System.Windows.RoutedEventHandler(this.BtnDelete_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.BtnAdd = ((System.Windows.Controls.Button)(target));
            
            #line 47 "..\..\..\Pages\SaleItemsPage.xaml"
            this.BtnAdd.Click += new System.Windows.RoutedEventHandler(this.BtnAdd_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 6:
            
            #line 38 "..\..\..\Pages\SaleItemsPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BtnEdit_Click);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}
