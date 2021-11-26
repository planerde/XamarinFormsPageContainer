﻿using System;
using UIKit;
using CoreGraphics;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace ShellExample.iOS.Renderer
{
    public class ViewControllerContainer : UIView
    {
        public ViewControllerContainer()
        {
            BackgroundColor = Color.Transparent.ToUIColor();
        }

        public ViewControllerContainer(CGRect frame) : base(frame)
        {
            BackgroundColor = Color.Transparent.ToUIColor();
        }

        public UIViewController ParentViewController { get; set; }

        #region properties

        UIViewController _viewController;

        public UIViewController ViewController
        {
            get { return _viewController; }
            set
            {
                if (_viewController != null)
                {
                    RemoveCurrentViewController();
                }
                _viewController = value;

                if (_viewController != null)
                {

                    AddViewController();
                }
            }
        }

        void AddViewController()
        {
            if (ParentViewController == null)
            {
                throw new Exception("No Parent View controller was found");
            }

            ParentViewController.AddChildViewController(_viewController);
            AddSubview(_viewController.View);

            _viewController.View.Frame = Bounds;

            _viewController.DidMoveToParentViewController(ParentViewController);
        }

        #endregion

        #region private impl

        void RemoveCurrentViewController()
        {
            if (ViewController != null)
            {
                ViewController.WillMoveToParentViewController(null);
                ViewController.View.RemoveFromSuperview();
                ViewController.RemoveFromParentViewController();
            }
        }

        #endregion
    }
}

