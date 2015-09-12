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
    /// A specific type of <code>Reward</code> that holds of list of other rewards
    /// in a certain sequence.  The rewards are given in ascending order.  For example,
    /// in a Karate game the user can progress between belts and can be rewarded a
    ///	sequence of: blue belt, yellow belt, green belt, brown belt, black belt
    /// </summary>
    public class SequenceReward : Reward
    {
        public List<Reward> Rewards;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="id">see parent.</param>
        /// <param name="name">see parent.</param>
        /// <param name="rewards">The list of rewards in the sequence.</param>
        public SequenceReward(string id, string name, List<Reward> rewards) : base(id, name) { }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="jsonReward">see parent.</param>
        public SequenceReward(JSONObject jsonReward) : base(jsonReward) { }

        /// <summary>
        /// see parent.
        /// </summary>
        /// <returns>see parent.</returns>
        public override JSONObject toJSONObject() { return null; }

        public Reward GetLastGivenReward() { return null; }
        public bool HasMoreToGive() { return false; }
        public bool ForceNextRewardToGive(Reward reward) { return false; }
        protected override bool giveInner() { return false; }
        protected override bool takeInner() { return false; }
    }
}
