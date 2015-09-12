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
using SoomlaWpCore.events;

namespace SoomlaWpCore.data
{
    public class RewardStorage
    {

        protected const string TAG = null;

        public static void SetRewardStatus(string rewardId, bool give) { }
        public static void SetRewardStatus(string rewardId, bool give, bool notify) { }
        public static bool IsRewardGiven(string rewardId) { return false; }
        public static int GetTimesGiven(string rewardId) { return 0; }
        public static DateTime GetLastGivenTime(string rewardId) { return default(DateTime); }
        public static void SetTimesGiven(string rewardId, bool up, bool notify) { }
        public static long GetCurrentTimeStampMillis() { return 0; }

        /// <summary>
        /// Retrieves the index of the last reward given in a sequence of rewards.
        /// </summary>
        public static int GetLastSeqIdxGiven(string rewardId) { return 0; }

        public static void SetLastSeqIdxGiven(string rewardId, int idx) { }
        public static long GetLastGivenTimeMillis(String rewardId) { return 0; }
        public static void SetLastGivenTimeMillis(String rewardId, long lastGiven) { }
        public static void ResetTimesGiven(String rewardId, int timesGiven) { }
    }
}

