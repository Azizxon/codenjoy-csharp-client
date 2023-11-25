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

using System.Xml.Linq;

namespace Dojo.Games.Mollymage
{
    public enum Direction
    {
        None,
        Right,
        Left,
        Up,
        Down
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

        public MollymageElement GetNearElement(Direction direction, Point currentPosition)
        {
            return Board.GetAt(GetNextMove(direction, currentPosition));
        }
        public Point GetNextMove(Direction direction, Point currentPosition)
        {
            switch (direction)
            {
                case Direction.Left:
                    return new Point(currentPosition.X - 1, currentPosition.Y);
                case Direction.Right:
                    return new Point(currentPosition.X + 1, currentPosition.Y);
                case Direction.Up:
                    return new Point(currentPosition.X, currentPosition.Y + 1);
                case Direction.Down:
                    return new Point(currentPosition.X, currentPosition.Y - 1);
                default:
                    return currentPosition;
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

        public bool IsDamagePotion(MollymageElement nextMove) =>
    nextMove == MollymageElement.POTION_EXPLODER || nextMove == MollymageElement.POTION_TIMER_4 ||
    nextMove == MollymageElement.POTION_TIMER_3 || nextMove == MollymageElement.POTION_TIMER_2 ||
    nextMove == MollymageElement.POTION_TIMER_1 || nextMove == MollymageElement.POTION_IMMUNE ||
    nextMove == MollymageElement.POTION_COUNT_INCREASE || nextMove == MollymageElement.POTION_TIMER_5 ||
    nextMove == MollymageElement.POTION_REMOTE_CONTROL || nextMove == MollymageElement.POISON_THROWER ||
    nextMove == MollymageElement.HERO_POTION || nextMove == MollymageElement.OTHER_HERO_POTION ||
    nextMove == MollymageElement.ENEMY_HERO_POTION || nextMove == MollymageElement.POTION_BLAST_RADIUS_INCREASE;

        public bool IsNextFiveMovesSafe(Direction direction)
        {
            var currentPosition = GetCurrentPosition();
            var moves = new List<MollymageElement>();
            for (var i = 0; i < 5; i++)
            {
                var move = GetNearElement(direction, currentPosition);
                moves.Add(move);
                switch (direction)
                {
                    case Direction.Left:
                        currentPosition = new Point(currentPosition.X - 1, currentPosition.Y);
                        break;
                    case Direction.Right:
                        currentPosition = new Point(currentPosition.X + 1, currentPosition.Y); break;
                    case Direction.Up:
                        currentPosition = new Point(currentPosition.X, currentPosition.Y + 1); break;
                    case Direction.Down:
                        currentPosition = new Point(currentPosition.X, currentPosition.Y - 1); break;
                    default:
                        throw new NotImplementedException();
                }
            }

            return moves.All(move => move == MollymageElement.NONE || move == MollymageElement.POTION_IMMUNE || move == MollymageElement.POTION_REMOTE_CONTROL);
        }

        public string Move()
        {
            bool isNextMoveSafe = false;
            foreach (Direction direction in Enum.GetValues(typeof(Direction)))
            {
                var currentPosition = GetCurrentPosition();
                var random = new Random();
                var nextMoveCell = GetNearElement(direction, currentPosition);
                var nextMove = GetNextMove(direction, currentPosition);
                var treasureBoxes = Board.Get(MollymageElement.TREASURE_BOX);
                var futureBlasts = Board.GetFutureBlasts();
                isNextMoveSafe = !futureBlasts.Contains(nextMove) &&
                                !IsDamagePotion(nextMoveCell)
                                && (nextMoveCell == MollymageElement.NONE || nextMoveCell == MollymageElement.POTION_IMMUNE || nextMoveCell == MollymageElement.POTION_REMOTE_CONTROL);

                if (isNextMoveSafe)
                {
                    var blastPoints = Board.GetPotionBlastPoints(currentPosition);
                    bool currentPositionHasBoxes = blastPoints.Any(x => Board.GetTreasureBox().Contains(x));

                    if (currentPositionHasBoxes)
                    {
                        switch (direction)
                        {
                            case Direction.Right:
                                return MollymageCommand.DROP_POTION_THEN_MOVE_RIGHT;
                            case Direction.Left:
                                return MollymageCommand.DROP_POTION_THEN_MOVE_LEFT;
                            case Direction.Up:
                                return MollymageCommand.DROP_POTION_THEN_MOVE_UP;
                            case Direction.Down:
                                return MollymageCommand.DROP_POTION_THEN_MOVE_DOWN;
                        }
                    }
                    else
                    {
                        switch (direction)
                        {
                            case Direction.Right:
                                return MollymageCommand.MOVE_RIGHT_THEN_DROP_POTION;
                            case Direction.Left:
                                return MollymageCommand.MOVE_LEFT_THEN_DROP_POTION;
                            case Direction.Up:
                                return MollymageCommand.MOVE_UP_THEN_DROP_POTION;
                            case Direction.Down:
                                return MollymageCommand.MOVE_DOWN_THEN_DROP_POTION;
                        }
                    }
                }                
            }
            return MollymageCommand.None;
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
