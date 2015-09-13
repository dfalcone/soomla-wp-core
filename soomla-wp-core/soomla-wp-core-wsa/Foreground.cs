/// Copyright (C) 2012-2015 Soomla Inc.
///
/// Licensed under the Apache License, Version 2.0 (the "License");
/// you may not use this file except in compliance with the License.
/// You may obtain a copy of the License at
///
///      http://www.apache.org/licenses/LICENSE-2.0
///
/// Unless required by applicable law or agreed to in writing, software
/// distributed under the License is distributed on an "AS IS" BASIS,
/// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
/// See the License for the specific language governing permissions and
/// limitations under the License.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Microsoft.Phone.Shell;
using Windows.Foundation;
using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel.Core;
using Windows.UI.Xaml;
using SoomlaWpCore.util;
using SoomlaWpCore.events;
using Windows.UI.Core;

namespace SoomlaWpCore
{
    public class Foreground
    {
        public const String TAG = "SOOMLA Foreground";
        private static Foreground mInstance;
        private static bool isForeground;
        public static Foreground Instance
        {
            get
            {
                if (mInstance == null)
                {
                    mInstance = new Foreground();
                    mInstance.Init();
                }
                return mInstance;
            }
            set
            {
            }
        }

        private void Init()
        {
            Windows.UI.Xaml.Window.Current.Activated += OnActivated;
            //CoreApplication.MainView.Activated += OnActivated;
            //PhoneApplicationService.Current.Activated += OnActivated;
            //PhoneApplicationService.Current.Deactivated += OnDeactivated;

            CoreApplication.Suspending += OnClosing;
            //CoreApplication.Exiting += OnClosing;
            //PhoneApplicationService.Current.Closing += OnClosing;

            CoreApplication.Resuming += OnLaunching;
            //PhoneApplicationService.Current.Launching += OnLaunching;
            isForeground = true;
        }

        //rivate void OnLaunching(object sender, LaunchingEventArgs e)
        private void OnLaunching(object sender, object e)
        {
            isForeground = true;
            BusProvider.Instance.Post(new AppToForegroundEvent());
            SoomlaUtils.LogDebug(TAG, "became foreground");
        }

        //private void OnClosing(object sender, ClosingEventArgs e)
        private void OnClosing(object sender, object e)
        {
            isForeground = false;
            BusProvider.Instance.Post(new AppToBackgroundEvent());
            SoomlaUtils.LogDebug(TAG, "became close");
        }

        /*private void OnDeactivated(object sender, DeactivatedEventArgs e)
        {
            isForeground = false;
            BusProvider.Instance.Post(new AppToBackgroundEvent());
            SoomlaUtils.LogDebug(TAG, "became background");
        }*/

        //private void OnActivated(object sender, ActivatedEventArgs e)
        //private void OnActivated(CoreApplicationView view, IActivatedEventArgs e)
        private void OnActivated(object sender, WindowActivatedEventArgs e)
        {
            if (e.WindowActivationState == CoreWindowActivationState.CodeActivated)
            {
                isForeground = true;
                BusProvider.Instance.Post(new AppToForegroundEvent());
                SoomlaUtils.LogDebug(TAG, "became foreground");
            }

            if (e.WindowActivationState == CoreWindowActivationState.Deactivated)
            {
                isForeground = false;
                BusProvider.Instance.Post(new AppToBackgroundEvent());
                SoomlaUtils.LogDebug(TAG, "became background");
            }
        }

        
        public bool IsForeground()
        {
            return isForeground;
        }

        public bool IsBackground()
        {
            return !isForeground;
        }
    }
}
