/// Copyright (C) 2012-2014 Soomla Inc.
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

namespace SoomlaWpCore
{
    
    public class SoomlaUtils
    {
        public static void LogDebug(String tag, String message) { }
        public static void LogWarning(String tag, String message) { }
        public static void LogError(String tag, String message) { }
        public static String DeviceId() { return null; }
        
        /// <summary>
        /// Returns the class name to be used in serialization/deserialization process
        /// in Soomla
        /// </summary>
        /// <param name="target">The target to get class name for</param>
        /// <returns>The class name of the provided instance</returns>
        public static string GetClassName(object target) { return null; }

        private const String TAG = null;
    }
}
