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

using System.Collections.Generic;
using System;
using SoomlaWpCore.util;


namespace SoomlaWpCore
{

    public class Schedule
    {
        public enum Recurrence
        {
            EVERY_MONTH,
            EVERY_WEEK,
            EVERY_DAY,
            EVERY_HOUR,
            NONE
        }

        public class DateTimeRange
        {
            private DateTime endTime;
            private DateTime startTime;

            public DateTimeRange(DateTime startTime, DateTime endTime)
            {
                this.startTime = startTime;
                this.endTime = endTime;
            }
        }

        public Recurrence RequiredRecurrence;
        public List<DateTimeRange> TimeRanges;
        public int ActivationLimit;
        public static Schedule AnyTimeOnce() { return null; }
        public static Schedule AnyTimeLimited(int activationLimit) { return null; }
        public static Schedule AnyTimeUnLimited() { return null; }
        public Schedule(int activationLimit) : this(null, Recurrence.NONE, activationLimit) { }
        public Schedule(DateTime startTime, DateTime endTime, Recurrence recurrence, int activationLimit) : this(new List<DateTimeRange> { new DateTimeRange(startTime, endTime) }, recurrence, activationLimit) { }
        public Schedule(List<DateTimeRange> timeRanges, Recurrence recurrence, int activationLimit) { }
        public Schedule(JSONObject jsonSched) { }
        public JSONObject toJSONObject() { return null; }
        public bool Approve(int activationTimes) { return false; }
    }
}
