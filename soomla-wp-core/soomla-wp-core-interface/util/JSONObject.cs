#define PRETTY		//Comment out when you no longer need to read JSON to disable pretty Print system-wide
//Using doubles will cause errors in VectorTemplates.cs; Unity speaks floats
//#define USEFLOAT	//Use floats for numbers instead of doubles	(enable if you're getting too many significant digits in string output)
//#define POOLING	//Currently using a build setting for this one (also it's experimental)

using System.Collections;
using System.Collections.Generic;

/*
 * http://www.opensource.org/licenses/lgpl-2.1.php
 * JSONObject class
 * for use with Unity
 * Copyright Matt Schoen 2010 - 2013
 * 
 * 
 * 
 * 
 * The changes from the original version are under this license:
 * 
 * Copyright (C) 2012-2014 Soomla Inc.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
namespace SoomlaWpCore.util
{
    public class JSONObject : NullCheckable, IEnumerable<JSONObject>
    {
#if POOLING
	const int MAX_POOL_SIZE = 10000;
	public static Queue<JSONObject> releaseQueue = new Queue<JSONObject>();
#endif

        public enum Type { NULL, STRING, NUMBER, OBJECT, ARRAY, BOOL, BAKED }
        public bool isContainer { get { return (type == Type.ARRAY || type == Type.OBJECT); } }
        public Type type = Type.NULL;
        public int Count;
        public List<JSONObject> list;
        public List<string> keys;
        public string str;
        public double n;
        public float f;
        public bool b;
        public delegate void AddJSONConents(JSONObject self);
        public static JSONObject nullJO { get { return Create(Type.NULL); } }	//an empty, null object
        public static JSONObject obj { get { return Create(Type.OBJECT); } }		//an empty object
        public static JSONObject arr { get { return Create(Type.ARRAY); } }		//an empty array
        public JSONObject(Type t) { }
        public JSONObject(bool b) { }
        public JSONObject(double d) { }
        public JSONObject(Dictionary<string, string> dic) { }
        public JSONObject(Dictionary<string, JSONObject> dic) { }
        public JSONObject(AddJSONConents content) { }
        public JSONObject(JSONObject[] objs) { }
        public static JSONObject StringObject(string val) { return CreateStringObject(val); }
        public void Absorb(JSONObject obj) { }
        public static JSONObject Create() { return null; }
        public static JSONObject Create(Type t) { return null; }
        public static JSONObject Create(bool val) { return null; }
        public static JSONObject Create(float val) { return null; }
        public static JSONObject Create(int val) { return null; }
        public static JSONObject Create(double val) { return null; }
        public static JSONObject CreateStringObject(string val) { return null; }
        public static string EncodeJsString(string s) { return null; }
        public static JSONObject CreateBakedObject(string val) { return null; }

        /// <summary>
        /// Create a JSONObject by parsing string data
        /// </summary>
        /// <param name="val">The string to be parsed</param>
        /// <param name="maxDepth">The maximum depth for the parser to search.  Set this to to 1 for the first level, 
        /// 2 for the first 2 levels, etc.  It defaults to -2 because -1 is the depth value that is parsed (see below)</param>
        /// <param name="storeExcessLevels">Whether to store levels beyond maxDepth in baked JSONObjects</param>
        /// <param name="strict">Whether to be strict in the parsing. For example, non-strict parsing will successfully 
        /// parse "a string" into a string-type </param>
        /// <returns></returns>
        public static JSONObject Create(string val, int maxDepth = -2, bool storeExcessLevels = false, bool strict = false) { return null; }
        public static JSONObject Create(AddJSONConents content) { return null; }
        public static JSONObject Create(Dictionary<string, string> dic) { return null; }
        public JSONObject() { }
        public JSONObject(string str, int maxDepth = -2, bool storeExcessLevels = false, bool strict = false) { }
        public bool IsNumber { get { return type == Type.NUMBER; } }
        public bool IsNull { get { return type == Type.NULL; } }
        public bool IsString { get { return type == Type.STRING; } }
        public bool IsBool { get { return type == Type.BOOL; } }
        public bool IsArray { get { return type == Type.ARRAY; } }
        public bool IsObject { get { return type == Type.OBJECT; } }
        public void Add(bool val) { }
        public void Add(float val) { }
        public void Add(int val) { }
        public void Add(string str) { }
        public void Add(AddJSONConents content) { }
        public void Add(JSONObject obj) { }
        public void AddField(string name, bool val) { }
        public void AddField(string name, float val) { }
        public void AddField(string name, int val) { }
        public void AddField(string name, double val) { }
        public void AddField(string name, AddJSONConents content) { }
        public void AddField(string name, string val) { }
        public void AddField(string name, JSONObject obj) { }
        public void SetField(string name, bool val) { SetField(name, Create(val)); }
        public void SetField(string name, float val) { SetField(name, Create(val)); }
        public void SetField(string name, int val) { SetField(name, Create(val)); }
        public void SetField(string name, string val) { }
        public void SetField(string name, JSONObject obj) { }
        public void RemoveField(string name) { }
        public delegate void FieldNotFound(string name);
        public delegate void GetFieldResponse(JSONObject obj);
        public void GetField(ref bool field, string name, FieldNotFound fail = null) { }
        public void GetField(ref double field, string name, FieldNotFound fail = null) { }
        public void GetField(ref int field, string name, FieldNotFound fail = null) { }
        public void GetField(ref uint field, string name, FieldNotFound fail = null) { }
        public void GetField(ref string field, string name, FieldNotFound fail = null) { }
        public void GetField(string name, GetFieldResponse response, FieldNotFound fail = null) { }
        public JSONObject GetField(string name) { return null; }
        public bool HasFields(string[] names) { return false; }
        public bool HasField(string name) { return false; }
        public void Clear() { }

        /// <summary>
        /// Copy a JSONObject. This could probably work better
        /// </summary>
        /// <returns></returns>
        public JSONObject Copy() { return null; }

        public void Merge(JSONObject obj) { }

        /// <summary>
        /// Merge object right into left recursively
        /// </summary>
        /// <param name="left">The left (base) object</param>
        /// <param name="right">The right (new) object</param>
        static void MergeRecur(JSONObject left, JSONObject right) { }


        public void Bake() { }
        public IEnumerable BakeAsync() { return null; }
        public string print(bool pretty = false) { return null; }
        public string Print(bool pretty = false) { return null; }
        public IEnumerable<string> PrintAsync(bool pretty = false) { return null; }
        
        public JSONObject this[int index] { get { return null; } set { } }
        public JSONObject this[string index] { get { return null; } set { } }
        public override string ToString() { return null; }
        public string ToString(bool pretty) { return null; }
        public Dictionary<string, string> ToDictionary() { return null; }
        public static implicit operator bool (JSONObject o) { return false; }
#if POOLING
		public static void ClearPool() { }
#endif

        public IEnumerator<JSONObject> GetEnumerator() { yield return null; }

        IEnumerator IEnumerable.GetEnumerator() { yield return null; }
    }
}