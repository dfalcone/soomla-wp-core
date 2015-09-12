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
/// 
using System;
using System.Collections.Generic;
using SoomlaWpCore.util;

namespace SoomlaWpCore.data
{
    public class KeyValueStorage
    {
        public KeyValueStorage() { }
        public static Dictionary<string, string> GetCache() { return null; }
        public static String GetValue(String Key, bool EncryptedKey = true) { return null; }
        public static String GetNonEncryptedKeyValue(String Key) { return null; }
        public static List<KeyValue> GetNonEncryptedQueryValues(String query) { return null; }
        public static String GetOneNonEncryptedQueryValues(String query) { return null; }
        public static int GetCountNonEncryptedQueryValues(String query) { return 0; }
        
        /// <summary>
        /// Gets all KeyValue keys in the storage with no encryption
        /// </summary>
        /// <returns></returns>
        public static List<KeyValue> GetEncryptedKeys() { return null; }

        public static void SetValue(String Key, String Value, bool EncryptedKey = true) { }
        public static void SetNonEncryptedKeyValue(String Key, String Value) { }
        public static void SetValueAsync(String Key, String Value, bool EncryptedKey = true) { }
        
        /// <summary>
        /// Delete a Key
        /// </summary>
        /// <param name="key"></param>
        /// <param name="EncryptedKey"></param>
        /// <returns>The number of record deleted</returns>
        public static int DeleteKeyValue(String key, bool EncryptedKey = true) { return 0; }

        public static KeyValDatabase GetDatabase() { return null; }
    }
}
