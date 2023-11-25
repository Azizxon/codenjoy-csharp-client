/*-
 * #%L
 * Codenjoy - it's a dojo-like platform from developers to developers.
 * %%
 * Copyright (C) 2012 - 2022 Codenjoy
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

namespace Dojo.Games.Mollymage
{
    public enum Direction
    {
        Right, Left, Up, Down
    }
    public class Hero
    {
        public MollymageBoard Board { get; set; }
        public Hero(MollymageBoard board)
        {
            Board = board;
        }

        public Point GetCurrentPosition()
        {
            var hx = Board.GetHero().X;
            var hy = Board.GetHero().Y;

            return new Point(hx, hy);
        }

        public MollymageElement GetNearElement(Direction direction)
        {
            var currentPosition = GetCurrentPosition();

            switch (direction)
            {
                case Direction.Left:
                    return Board.GetAt(new Point(currentPosition.X - 1, currentPosition.Y));
                case Direction.Right:
                    return Board.GetAt(new Point(currentPosition.X + 1, currentPosition.Y));
                case Direction.Up:
                    return Board.GetAt(new Point(currentPosition.X, currentPosition.Y + 1));
                case Direction.Down:
                    return Board.GetAt(new Point(currentPosition.X, currentPosition.Y - 1));
                default:
                    throw new NotImplementedException();
            }
        }
        public List<MollymageElement> GoodElements()
        {
            return new List<MollymageElement>()
            {
                MollymageElement.TREASURE_BOX,
                MollymageElement.NONE
            };
        }
        public string Move()
        {
            foreach (Direction direction in Enum.GetValues(typeof(Direction)))
            {
                var nextMove = GetNearElement(direction);

                if (nextMove == MollymageElement.NONE || nextMove == MollymageElement.TREASURE_BOX)
                {
                    return MollymageCommand.MOVE_RIGHT_THEN_DROP_POTION;
                }
            }

            return MollymageCommand.DROP_POTION;
        }

    }
    /// <summary>
    /// This is HeroAI client demo.
    /// </summary>
    public class MollymageSolver : ISolver
    {
        public string Get(IBoard gameBoard)
        {
            return Get(gameBoard as MollymageBoard);
        }

        private string Get(MollymageBoard gameBoard)
        {         
            var hero = new Hero(gameBoard);
               
            return hero.Move();
        }
    }
}
