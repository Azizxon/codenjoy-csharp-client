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

namespace Dojo.Games.Rawelbbub
{
    public enum RawelbbubElement : short
    {

            // An empty space where hero can move.

        NONE = (short)' ',

            // The undestroyable wall.

        BATTLE_WALL = (short)'☼',

            // A destroyed hero. A new appears just in a second.

        BANG = (short)'Ѡ',

            // Ice, having driven onto which hero will begin to drift.
            // During a skid, hero will repeat the old commands for several
            // ticks in a row, ignoring the current commands.

        ICE = (short)'#',

            // The trees hide heroes which can continue to shoot at the
            // same time. The fired shells are also not visible under the
            // trees. Only prizes can be seen from behind the trees.

        TREE = (short)'%',

            // The river does not allow to pass through itself without the
            // PRIZE_WALKING_ON_WATER prize, but the shells fly freely
            // through the water. Hero stuck in the middle of the water,
            // after canceling the PRIZE_WALKING_ON_WATER prize, can move 1
            // cell in the water only every N ticks.

        RIVER = (short)'~',

            // A wall that hasn't been shot yet. It takes 3 shots to
            // completely destroy.

        WALL = (short)'╬',

            // Partially destroyed wall. For complete destruction, 2 shot
            // is required.

        WALL_DESTROYED_DOWN = (short)'╩',

            // Partially destroyed wall. For complete destruction, 2 shot
            // is required.

        WALL_DESTROYED_UP = (short)'╦',

            // Partially destroyed wall. For complete destruction, 2 shot
            // is required.

        WALL_DESTROYED_LEFT = (short)'╠',

            // Partially destroyed wall. For complete destruction, 2 shot
            // is required.

        WALL_DESTROYED_RIGHT = (short)'╣',

            // Partially destroyed wall. For complete destruction, 1 shot
            // is required.

        WALL_DESTROYED_DOWN_TWICE = (short)'╨',

            // Partially destroyed wall. For complete destruction, 1 shot
            // is required.

        WALL_DESTROYED_UP_TWICE = (short)'╥',

            // Partially destroyed wall. For complete destruction, 1 shot
            // is required.

        WALL_DESTROYED_LEFT_TWICE = (short)'╞',

            // Partially destroyed wall. For complete destruction, 1 shot
            // is required.

        WALL_DESTROYED_RIGHT_TWICE = (short)'╡',

            // Partially destroyed wall. For complete destruction, 1 shot
            // is required.

        WALL_DESTROYED_LEFT_RIGHT = (short)'│',

            // Partially destroyed wall. For complete destruction, 1 shot
            // is required.

        WALL_DESTROYED_UP_DOWN = (short)'─',

            // Partially destroyed wall. For complete destruction, 1 shot
            // is required.

        WALL_DESTROYED_UP_LEFT = (short)'┌',

            // Partially destroyed wall. For complete destruction, 1 shot
            // is required.

        WALL_DESTROYED_RIGHT_UP = (short)'┐',

            // Partially destroyed wall. For complete destruction, 1 shot
            // is required.

        WALL_DESTROYED_DOWN_LEFT = (short)'└',

            // Partially destroyed wall. For complete destruction, 1 shot
            // is required.

        WALL_DESTROYED_DOWN_RIGHT = (short)'┘',

            // Partially destroyed wall. For complete destruction, 2 shot
            // is required.

        WALL_DESTROYED = (short)' ',

            // Completely destroyed wall. Wall will recover over time.

        BULLET = (short)'•',

            // Your hero is pointing up.

        HERO_UP = (short)'▲',

            // Your hero is pointing right.

        HERO_RIGHT = (short)'►',

            // Your hero is pointing down.

        HERO_DOWN = (short)'▼',

            // Your hero is pointing left.

        HERO_LEFT = (short)'◄',

            // Enemy hero is pointing up.

        OTHER_HERO_UP = (short)'˄',

            // Enemy hero is pointing right.

        OTHER_HERO_RIGHT = (short)'˃',

            // Enemy hero is pointing down.

        OTHER_HERO_DOWN = (short)'˅',

            // Enemy hero is pointing left.

        OTHER_HERO_LEFT = (short)'˂',

            // AI is pointing up.

        AI_UP = (short)'?',

            // AI is pointing right.

        AI_RIGHT = (short)'»',

            // AI is pointing down.

        AI_DOWN = (short)'¿',

            // AI is pointing left.

        AI_LEFT = (short)'«',

            // AI can also be a prize, then it is highlighted by this
            // sprite every few ticks.

        AI_PRIZE = (short)'◘',

            // The dropped prize after the destruction of the prize AI
            // flickers on the field every even tick of the game with this
            // sprite.

        PRIZE = (short)'!',

            // A prize that gives the hero temporary invulnerability.

        PRIZE_IMMORTALITY = (short)'1',

            // A prize that allows you to temporarily destroy any walls
            // with 1 shot, even indestructible ones (but not the border of
            // the field).

        PRIZE_BREAKING_WALLS = (short)'2',

            // A prize that allows the hero to temporarily walk on water.

        PRIZE_WALKING_ON_WATER = (short)'3',

            // A prize that allows the hero to temporarily see all enemies
            // under the trees.

        PRIZE_VISIBILITY = (short)'4',

            // A prize that allows the hero to temporarily not slide on the
            // ice.

        PRIZE_NO_SLIDING = (short)'5'
    }
}

