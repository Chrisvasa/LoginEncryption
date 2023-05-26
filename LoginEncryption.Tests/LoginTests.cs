using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LoginEncryption.Tests
{
    public class LoginTests
    {
        [Fact]
        public void HandleInputShouldReturnTrue_IfInputWasCorrect()
        {
            // Arrange
            Login userLogin = new Login();
            bool expected = true;
            // Act
            bool actual = userLogin.HandleInput("Test");
            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
