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

using SoomlaWpCore.util;

namespace SoomlaWpCore.rewards
{

    /// <summary>
    /// A specific type of <code>Reward</code> that represents a badge
    /// with an icon. For example: when the user achieves a top score,
    /// the user can earn a "Highest Score" badge reward.
    /// </summary>
    public class BadgeReward : Reward
    {
        public string IconUrl;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="id">see parent</param>
        /// <param name="name">see parent</param>
        public BadgeReward(string id, string name) : base(id, name) { }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="id">see parent</param>
        /// <param name="name">see parent</param>
        /// <param name="iconUrl">A url to the icon of this Badge on the device.</param>
        public BadgeReward(string id, string name, string iconUrl) : base(id, name) { IconUrl = iconUrl; }

        /// <summary>
        /// see parent.
        /// </summary>
        public BadgeReward(JSONObject jsonReward) : base(jsonReward) { }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <returns>see parent</returns>
        public override JSONObject toJSONObject() { return null; }

        protected override bool giveInner() { return false; }
        
        protected override bool takeInner() { return false; }

    }
}
