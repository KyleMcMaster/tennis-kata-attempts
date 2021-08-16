using System;

namespace Kata.Starter
{
    /*
    Player 1 Player 2 (IPoint, IPoint)
     Love     Love  // PlayerOneScores() -> 
     Fifteen  Love  // PlayerOneScores() -> 
     Thirty   Love  // PlayerTwoScores() ->
     Thirty   Fifteen // PlayerTwoScores() ->
     Thirty   Thirty // PlayerTwoScores() -> 
     Thirty   Forty  // PlayerOneScores() ->
          Deuce      // PlayerOneScores() -> 
     Advantage       // PlayerTwoScores() -> 
          Deuce      // PlayerTwoScores() -> 
              Advantage // PlayerTwoScores() -> 
              Win   
     */

    public static class Game
    {
        public static (IPlayer PlayerOne, IPlayer PlayerTwo) PlayerOneScores(this (IPlayer PlayerOne, IPlayer PlayerTwo) points)
        {
            return (points.PlayerOne.Score(points.PlayerTwo));
        }

        public static (IPlayer PlayerOne, IPlayer PlayerTwo) PlayerTwoScores(this (IPlayer PlayerOne, IPlayer PlayerTwo) points)
        {
            return Flip(points.PlayerTwo.Score(points.PlayerOne));
        }

        private static (IPlayer PlayerOne, IPlayer PlayerTwo) Flip(this (IPlayer PlayerOne, IPlayer PlayerTwo) points)
        {
            return (points.PlayerTwo, points.PlayerOne);
        }
    }

    public interface IPlayer
    {
        (IPlayer PlayerOne, IPlayer PlayerTwo) Score(IPlayer other);
    }

    public class Love : IPlayer
    {
        public (IPlayer PlayerOne, IPlayer PlayerTwo) Score(IPlayer other) => (new Fifteen(), other);
    }

    public class Fifteen : IPlayer
    {
        public (IPlayer PlayerOne, IPlayer PlayerTwo) Score(IPlayer other) => (new Thirty(), other);
    }

    public class Thirty : IPlayer
    {
        public (IPlayer PlayerOne, IPlayer PlayerTwo) Score(IPlayer other) =>
            other.GetType() == typeof(Forty) ? (new Deuce(), new Deuce()) : (new Forty(), other);
    }

    public class Forty : IPlayer
    {
        public (IPlayer PlayerOne, IPlayer PlayerTwo) Score(IPlayer other) =>
            other.GetType() != typeof(Forty)
                ? (new Win(), other)
                : (new Advantage(), other);
    }

    public class Advantage : IPlayer
    {
        public (IPlayer PlayerOne, IPlayer PlayerTwo) Score(IPlayer other) => (new Win(), other);
    }

    public class Deuce : IPlayer
    {
        public (IPlayer PlayerOne, IPlayer PlayerTwo) Score(IPlayer other)
        {
            return (new Advantage(), other);
        }
    }

    public class Win : IPlayer
    {
        public (IPlayer PlayerOne, IPlayer PlayerTwo) Score(IPlayer other)
        {
            throw new NotImplementedException();
        }
    }
}