/*-
 * #%L
 * Codenjoy - it's a dojo-like platform from developers to developers.
 * %%
 * Copyright (C) 2021 Codenjoy
 * %%
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as
 * published by the Free Software Foundation, either version 3 of the
 * License, or (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public
 * License along with this program.  If not, see
 * <http://www.gnu.org/licenses/gpl-3.0.html>.
 * #L%
 */
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dojo.Games.Sample
{
    public enum SampleElement : short
    {

            // Empty place where the hero can go.

        NONE = (short)' ',

            // Wall you cant walk through.

        WALL = (short)'☼',

            // Your hero.

        HERO = (short)'☺',

            // Heroes of other players.

        OTHER_HERO = (short)'☻',

            // Your hero died. His body will disappear in the next tick.

        DEAD_HERO = (short)'X',

            // Another player's hero died.

        OTHER_DEAD_HERO = (short)'Y',

            // Gold. It must be picked up.

        GOLD = (short)'$',

            // Bomb planted by the hero. You can blow up on it.

        BOMB = (short)'x'
    }
}
