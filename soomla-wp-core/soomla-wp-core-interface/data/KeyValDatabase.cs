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
using System.Collections.Generic;

namespace SoomlaWpCore.data
{
    public class KeyValDatabase
    {
        /// <summary>
        /// The database path.
        /// </summary>
        public static string DB_PATH = null;

        public KeyValDatabase() { }
        public void PurgeDatabse() { }
        public void PurgeDatabaseEntries() { }
        //public async void SetKeyVal(String Key, String Value) { } // Should this be public?
        public String GetKeyVal(String Key) { return null; }
        //public async Task<int> DeleteKeyVal(String Key) { return null; }  // Should this be public?
        public List<KeyValue> GetQueryVals(String query) { return null; }
        public string GetQueryOne(String query) { return null; }
        public int GetQueryCount(String query) { return 0; }

        /// <summary>
        /// Get all Keys from KeyValue without the Values
        /// </summary>
        /// <returns></returns>
        public List<KeyValue> GetAllKeys() { return null; }
    }

    public sealed class KeyValue
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
