﻿#pragma checksum "D:\Project\EasyImages\EasyImages\Controls\SideBar.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "BD6566CB4437E0EDCAF5B89A62C8DCA6"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using EasyImages.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace YiWen.Controls {
    
    
    public partial class SideBar : System.Windows.Controls.UserControl {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Grid DownView;
        
        internal System.Windows.Controls.TextBlock txtFavorites;
        
        internal System.Windows.Controls.TextBlock txtOffline;
        
        internal System.Windows.Controls.TextBlock txtAboutUs;
        
        internal System.Windows.Controls.Grid UpView;
        
        internal System.Windows.Media.CompositeTransform uptansform;
        
        internal System.Windows.Controls.Grid LayoutRoot2;
        
        internal System.Windows.Controls.Grid gridMain;
        
        internal System.Windows.Media.VideoBrush _previewVideo;
        
        internal System.Windows.Media.CompositeTransform _previewTransform;
        
        internal System.Windows.Shapes.Rectangle rectangle;
        
        internal System.Windows.Controls.Image image;
        
        internal System.Windows.Media.CompositeTransform imageTransform;
        
        internal System.Windows.Controls.Image iamgeMark;
        
        internal System.Windows.Controls.TextBox txtMsg;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal EasyImages.Controls.ImageButton btnText;
        
        internal EasyImages.Controls.ImageButton btnCamera;
        
        internal EasyImages.Controls.ImageButton btnTextAlignmentLeft;
        
        internal EasyImages.Controls.ImageButton btnTextAlignmentRight;
        
        internal EasyImages.Controls.ImageButton btnTextAlignmentCenter;
        
        internal EasyImages.Controls.ImageButton btnTextAlignmentTop;
        
        internal EasyImages.Controls.ImageButton btnTextAlignmentBottom;
        
        internal EasyImages.Controls.ImageButton btnCancel;
        
        internal EasyImages.Controls.ImageButton btnShare;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/EasyImages;component/Controls/SideBar.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.DownView = ((System.Windows.Controls.Grid)(this.FindName("DownView")));
            this.txtFavorites = ((System.Windows.Controls.TextBlock)(this.FindName("txtFavorites")));
            this.txtOffline = ((System.Windows.Controls.TextBlock)(this.FindName("txtOffline")));
            this.txtAboutUs = ((System.Windows.Controls.TextBlock)(this.FindName("txtAboutUs")));
            this.UpView = ((System.Windows.Controls.Grid)(this.FindName("UpView")));
            this.uptansform = ((System.Windows.Media.CompositeTransform)(this.FindName("uptansform")));
            this.LayoutRoot2 = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot2")));
            this.gridMain = ((System.Windows.Controls.Grid)(this.FindName("gridMain")));
            this._previewVideo = ((System.Windows.Media.VideoBrush)(this.FindName("_previewVideo")));
            this._previewTransform = ((System.Windows.Media.CompositeTransform)(this.FindName("_previewTransform")));
            this.rectangle = ((System.Windows.Shapes.Rectangle)(this.FindName("rectangle")));
            this.image = ((System.Windows.Controls.Image)(this.FindName("image")));
            this.imageTransform = ((System.Windows.Media.CompositeTransform)(this.FindName("imageTransform")));
            this.iamgeMark = ((System.Windows.Controls.Image)(this.FindName("iamgeMark")));
            this.txtMsg = ((System.Windows.Controls.TextBox)(this.FindName("txtMsg")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.btnText = ((EasyImages.Controls.ImageButton)(this.FindName("btnText")));
            this.btnCamera = ((EasyImages.Controls.ImageButton)(this.FindName("btnCamera")));
            this.btnTextAlignmentLeft = ((EasyImages.Controls.ImageButton)(this.FindName("btnTextAlignmentLeft")));
            this.btnTextAlignmentRight = ((EasyImages.Controls.ImageButton)(this.FindName("btnTextAlignmentRight")));
            this.btnTextAlignmentCenter = ((EasyImages.Controls.ImageButton)(this.FindName("btnTextAlignmentCenter")));
            this.btnTextAlignmentTop = ((EasyImages.Controls.ImageButton)(this.FindName("btnTextAlignmentTop")));
            this.btnTextAlignmentBottom = ((EasyImages.Controls.ImageButton)(this.FindName("btnTextAlignmentBottom")));
            this.btnCancel = ((EasyImages.Controls.ImageButton)(this.FindName("btnCancel")));
            this.btnShare = ((EasyImages.Controls.ImageButton)(this.FindName("btnShare")));
        }
    }
}
