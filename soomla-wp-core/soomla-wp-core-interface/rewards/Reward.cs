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
using SoomlaWpCore.util;

namespace SoomlaWpCore.rewards
{

    /// <summary>
    /// A reward is an entity which can be earned by the user for meeting certain
    /// criteria in game progress.  For example - a user can earn a badge for completing
    /// a mission. Dealing with <code>Reward</code>s is very similar to dealing with
    /// <code>VirtualItem</code>s: grant a reward by giving it and recall a
    /// reward by taking it.
    ///
    /// In the Profile module, rewards can be attached to various actions. For example:
    /// You can give your user 100 coins for logging in through Facebook.
    /// </summary>
    public abstract class Reward : SoomlaEntity<Reward>
    {
        public Schedule Schedule;
        public bool Owned;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="id">the reward's ID (unique id to distinguish between rewards).</param>
        /// <param name="name">the reward's name.</param>
        public Reward(string id, string name) : base(name, "", id) { }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="jsonReward">A JSONObject representation of <c>Reward</c>.</param>
        public Reward(JSONObject jsonReward) : base(jsonReward) { }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <returns>A JSONObject representation of <c>Reward</c>.</return>
        public override JSONObject toJSONObject() { return null; }

        /// <summary>
        /// Factory method to easily create a reward according to the given JSONObject.
        /// </summary>
        /// <returns>A JSONObject representation of <c>Reward</c>.</returns>
        /// <param name="rewardObj">The actual reward according to the given JSONObject.</param>
        public static Reward fromJSONObject(JSONObject rewardObj) { return null; }

        public bool Take() { return false; }
        public bool CanGive() { return false; }
        public bool Give() { return false; }
        protected abstract bool giveInner();
        protected abstract bool takeInner();
        public static Reward GetReward(string rewardID) { return null; }
        public static List<Reward> GetRewards() { return null; }
    }
}
