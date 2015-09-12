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
using SoomlaWpCore.util;

namespace SoomlaWpCore
{
    public abstract class SoomlaEntity<T>
    {
        public SoomlaEntity(String Name, String Description, String ID) { }
        public SoomlaEntity(JSONObject jsonObject) { }
        public virtual JSONObject toJSONObject() { return null; }
        public string GetId() { return null; }
        public string GetName() { return null; }
        public string GetDescription() { return null; }
        public override bool Equals(System.Object obj) { return false; }
        public bool Equals(SoomlaEntity<T> g) { return false; }
        public override int GetHashCode() { return 0; }
        public static bool operator ==(SoomlaEntity<T> a, SoomlaEntity<T> b) { return false; }
        public static bool operator !=(SoomlaEntity<T> a, SoomlaEntity<T> b) { return false; }
        public virtual T Clone(string newId) { return default(T); }
        //protected String mName;
        //protected String mDescription;
        //protected String mID;
    }
}
