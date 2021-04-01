using CommandAPI.Models;
using System;
using Xunit;

namespace CommandAPI.Tests
{
    public class CommandTests : IDisposable
    {
        Command testCommand;
        public CommandTests()
        {
            var testCommand = new Command
            {
                HowTo = "Do something awesome",
                Platform = "xUnit",
                CommandLine = "dotnet test"
            };

            this.testCommand = testCommand;
        }

        [Fact]
        public void CanChangeHowTo()
        {
            //Arrange
            
            //Act
            testCommand.HowTo = "Execute Unit Tests";
            //Assert
            Assert.Equal("Execute Unit Tests", testCommand.HowTo);
        }

        [Fact]
        public void CanChangePlatform()
        {
            //Arrange

            //Act
            testCommand.Platform = "Tests";
            //Assert
            Assert.Equal("Tests", testCommand.Platform);
        }

        [Fact]
        public void CanChangeCommandLine()
        {
            //Arrange

            //Act
            testCommand.CommandLine = "Command";
            //Assert
            Assert.Equal("Command", testCommand.CommandLine);
        }

        public void Dispose()
        {
            testCommand = null;
        }
    }
}
