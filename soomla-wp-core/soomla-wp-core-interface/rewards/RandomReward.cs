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
    /// A specific type of <code>Reward</code> that holds of list of other
    /// rewards. When this reward is given, it randomly chooses a reward from
    ///	the list of rewards it internally holds.  For example: a user can earn a mystery box
    ///	reward (<code>RandomReward</code>, which in fact grants the user a random reward between a
    /// "Mayor" badge (<code>BadgeReward</code>) and a speed boost (<code>VirtualItemReward</code>)
    /// </summary>
    public class RandomReward : Reward
    {
        public List<Reward> Rewards;
        public Reward LastGivenReward;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="id">see parent.</param>
        /// <param name="name">see parent.</param>
        /// <param name="rewards">A list of rewards from which to choose the reward randomly.</param>
        public RandomReward(string id, string name, List<Reward> rewards) : base(id, name) { }
       
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="jsonReward">see parent.</param>
        public RandomReward(JSONObject jsonReward) : base(jsonReward) { }

        /// <summary>
        /// see parent.
        /// </summary>
        /// <returns>see parent.</returns>
        public override JSONObject toJSONObject() { return null; }

        protected override bool giveInner() { return false; }

        protected override bool takeInner() { return false; }

    }
}
