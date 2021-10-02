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
        // input with errors - frames add up to over 10
        [InlineData(9,5,10,2,8,1,8,2,6,3,7,2,7,3,7,2,9,2,9,3,8,145)]
        [InlineData(9,1,10,0,8,1,8,2,6,3,7,3,7,3,7,2,9,2,9,3,8,153)]
        // input with errors - frames add up to over 10
        [InlineData(9,5,10,2,8,1,8,2,6,3,7,5,7,3,7,2,9,2,9,3,8,153)]
        [InlineData(6,4,4,4,8,1,8,2,6,3,7,3,9,1,9,0,9,1,10,10,8,151)]
        [InlineData(5,3,2,3,4,5,10,0,9,1,8,1,4,5,10,0,8,1,10,6,4,126)]
        [InlineData(0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0)]
        [InlineData(10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,300)]
        [InlineData(10,0,10,0,10,0,10,0,10,0,10,0,10,0,10,0,10,0,10,10,10,300)]
        public void bowling_score_theory(int a1, int a2, int b1, int b2, int c1, int c2, int d1, int d2, int e1, int e2,
                                         int f1, int f2, int g1, int g2, int h1, int h2, int i1, int i2, int j1, int j2, int j3, int expectedResult)
        
        {
            Frame[] frameList = { new Frame(a1, a2), new Frame(b1, b2), new Frame(c1, c2), new Frame(d1, d2), new Frame(e1, e2),
                                  new Frame(f1, f2), new Frame(g1, g2), new Frame(h1, h2), new Frame(i1, i2), new Frame(j1, j2, j3) };
            var game = new BowlingGame(frameList);

            // Act
            var Result1 = game.GetScore();
            var actualResult = game.GetScore();

            // Assert
            Assert.Equal(expectedResult, actualResult);

        }
        
        [Theory]
        [InlineData(9,1,10,0,8,1,8,2,58)]
        [InlineData(7,3,9,1,8,1,10,0,56)]
        public void bowling_score_theory_4_frames_partial_game(int a1, int a2, int b1, int b2, int c1, int c2, int d1, int d2, int expectedResult)
        {

            Frame[] frameList = { new Frame(a1, a2), new Frame(b1, b2), new Frame(c1, c2), new Frame(d1, d2) };
            var game = new BowlingGame(frameList);

            // Act
            var Result1 = game.GetScore();
            var actualResult = game.GetScore();

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }
        [Theory]
        [InlineData("9","1","10","0","8","1","8","2","6","3","7","2","7","3","7","2","9","1","9","1","8",145)]
        [InlineData("9","/","X","0","8","1","8","/","6","3","7","2","7","/","7","2","9","/","9","/","8",145)]
        [InlineData("6","4","4","4","8","1","8","2","6","3","7","3","9","1","9","0","9","1","10","10","8",151)]
        [InlineData("6","/","4","4","8","1","8","/","6","3","7","/","9","/","9","0","9","/","X","X","8",151)]
        public void bowling_score_theory_string_input(string a1, string a2, string b1, string b2, string c1, string c2, string d1, string d2, string e1, string e2,
                                         string f1, string f2, string g1, string g2, string h1, string h2, string i1, string i2, string j1, string j2, string j3, int expectedResult)
        
        {
            Frame[] frameList = { new Frame(a1, a2), new Frame(b1, b2), new Frame(c1, c2), new Frame(d1, d2), new Frame(e1, e2),
                                  new Frame(f1, f2), new Frame(g1, g2), new Frame(h1, h2), new Frame(i1, i2), new Frame(j1, j2, j3) };
            var game = new BowlingGame(frameList);

            // Act
            var Result1 = game.GetScore();
            var actualResult = game.GetScore();

            // Assert
            Assert.Equal(expectedResult, actualResult);

        }
       
        [Theory]
        [InlineData("9","1","10","0","8","1","8","2",58)]
        [InlineData("9","/","X","0","8","1","8","/",58)]
        [InlineData("7","3","9","1","8","1","10","0",56)]
        // with invalid input
        [InlineData("7","/","9","/","8","1","X","2",56)]
        // with invalid input
        [InlineData("7","/","9","/","8","1","10","X",56)]
        public void bowling_score_theory_4_frames_partial_game_with_strings(string a1, string a2, string b1, string b2, string c1, string c2, string d1, string d2, int expectedResult)
        {

            Frame[] frameList = { new Frame(a1, a2), new Frame(b1, b2), new Frame(c1, c2), new Frame(d1, d2) };
            var game = new BowlingGame(frameList);

            // Act
            var Result1 = game.GetScore();
            var actualResult = game.GetScore();

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }
        
    }
}
