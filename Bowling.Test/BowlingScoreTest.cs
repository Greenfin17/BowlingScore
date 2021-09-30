using System;
using Xunit;

namespace Bowling.Test
{
    public class BowlingScoreTest
    {
        [Fact]
        public void score_should_be_145()
        {
            // Arrange
            Frame[] frameList = {new Frame(9, 1), new Frame(10), new Frame(8, 1), new Frame(8, 2), new Frame(6, 3),
                                 new Frame(7, 2), new Frame(7, 3), new Frame(7, 2), new Frame(9,1), new Frame(9, 1, 8)};
            int expectedResult = 145;
            var game = new BowlingGame(frameList);

            // Act
            var actualResult = game.GetScore();

            // Assert
            Equals(expectedResult, actualResult);
        }
        [Theory]
        
        [InlineData(9,1,10,0,8,1,8,2,6,3,7,2,7,3,7,2,9,1,9,1,8,145)]
        [InlineData(6,4,4,4,8,1,8,2,6,3,7,3,9,1,9,0,9,1,10,10,8,151)]
        public void bowling_score_theory(int a1, int a2, int b1, int b2, int c1, int c2, int d1, int d2, int e1, int e2,
                                         int f1, int f2, int g1, int g2, int h1, int h2, int i1, int i2, int j1, int j2, int j3, int expectedResult)
        
        {
            Frame[] frameList = { new Frame(a1, a2), new Frame(b1, b2), new Frame(c1, c2), new Frame(d1, d2), new Frame(e1, e2),
                                  new Frame(f1, f2), new Frame(g1, g2), new Frame(h1, h2), new Frame(i1, i2), new Frame(j1, j2, j3) };
            var game = new BowlingGame(frameList);

            // Act
            var actualResult = game.GetScore();

            // Assert
            Equals(expectedResult, actualResult);

        }
    }
}
