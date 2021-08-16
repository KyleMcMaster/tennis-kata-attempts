using Xunit;

namespace Kata.Starter
{
    public class GameTests
    {
        [Fact]
        public void Game_PlayersStartWithLoveState()
        {
            var sut = (PlayerOne: new Love(), PlayerTwo: new Love());

            Assert.IsAssignableFrom<Love>(sut.PlayerOne);
            Assert.IsAssignableFrom<Love>(sut.PlayerTwo);
        }

        [Fact]
        public void Game_PlayerOneScoresOnce_HasScoreFifteen()
        {
            var sut = (PlayerOne: new Love(), PlayerTwo: new Love());

            var result = sut.PlayerOneScores();

            Assert.IsAssignableFrom<Fifteen>(result.PlayerOne);
            Assert.IsAssignableFrom<Love>(result.PlayerTwo);
        }

        [Fact]
        public void Game_PlayerOneScoresTwice_HasScoreThirty()
        {
            var sut = (PlayerOne: new Love(), PlayerTwo: new Love());

            var result = sut.PlayerOneScores()
                .PlayerOneScores();

            Assert.IsAssignableFrom<Thirty>(result.PlayerOne);
            Assert.IsAssignableFrom<Love>(result.PlayerTwo);
        }

        [Fact]
        public void Game_PlayerOneScoresThree_HasScoreForty()
        {
            var sut = (PlayerOne: new Love(), PlayerTwo: new Love());

            var result = sut.PlayerOneScores()
                .PlayerOneScores()
                .PlayerOneScores();

            Assert.IsAssignableFrom<Forty>(result.PlayerOne);
            Assert.IsAssignableFrom<Love>(result.PlayerTwo);
        }

        [Fact]
        public void Game_BothPlayersScore_HaveScoreFifteen()
        {
            var sut = (PlayerOne: new Love(), PlayerTwo: new Love());

            var result = sut.PlayerOneScores()
                .PlayerTwoScores();

            Assert.IsAssignableFrom<Fifteen>(result.PlayerOne);
            Assert.IsAssignableFrom<Fifteen>(result.PlayerTwo);
        }

        [Fact]
        public void Game_PlayerOneScoresOnceHasScoreFifteen_PlayerTwoScoresTwiceHasScoreThirty()
        {
            var sut = (PlayerOne: new Love(), PlayerTwo: new Love());

            var result = sut.PlayerOneScores()
                .PlayerTwoScores()
                .PlayerTwoScores();

            Assert.IsAssignableFrom<Fifteen>(result.PlayerOne);
            Assert.IsAssignableFrom<Thirty>(result.PlayerTwo);
        }

        [Fact]
        public void Game_PlayerOneScoresThree_PlayerTwoScoresOnce_PlayerOneWins()
        {
            var sut = (PlayerOne: new Love(), PlayerTwo: new Love());

            var result = sut.PlayerOneScores()
                .PlayerOneScores()
                .PlayerOneScores()
                .PlayerTwoScores()
                .PlayerOneScores();

            Assert.IsAssignableFrom<Win>(result.PlayerOne);
            Assert.IsAssignableFrom<Fifteen>(result.PlayerTwo);
        }

        [Fact]
        public void Game_PlayerOneScoresThree_PlayerTwoScoresTwo_PlayerOneWins()
        {
            var sut = (PlayerOne: new Love(), PlayerTwo: new Love());

            var result = sut.PlayerOneScores()
                .PlayerOneScores()
                .PlayerOneScores()
                .PlayerTwoScores()
                .PlayerTwoScores()
                .PlayerOneScores();

            Assert.IsAssignableFrom<Win>(result.PlayerOne);
            Assert.IsAssignableFrom<Thirty>(result.PlayerTwo);
        }

        [Fact]
        public void Game_PlayerOneScoresThree_PlayerTwoScoresThree_Deuce()
        {
            var sut = (PlayerOne: new Love(), PlayerTwo: new Love());

            var result = sut.PlayerOneScores()
                .PlayerOneScores()
                .PlayerOneScores()
                .PlayerTwoScores()
                .PlayerTwoScores()
                .PlayerTwoScores();

            Assert.IsAssignableFrom<Deuce>(result.PlayerOne);
            Assert.IsAssignableFrom<Deuce>(result.PlayerTwo);
        }

        [Fact]
        public void Game_PlayerOneScoresThree_PlayerTwoScoresThree_PlayerOneScores_Advantage()
        {
            var sut = (PlayerOne: new Love(), PlayerTwo: new Love());

            var result = sut.PlayerOneScores()
                .PlayerOneScores()
                .PlayerOneScores()
                .PlayerTwoScores()
                .PlayerTwoScores()
                .PlayerTwoScores()
                .PlayerOneScores();

            Assert.IsAssignableFrom<Advantage>(result.PlayerOne);
            Assert.IsAssignableFrom<Deuce>(result.PlayerTwo);
        }
    }
}