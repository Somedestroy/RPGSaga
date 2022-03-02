namespace RpgSaga.Tests
{
    using System;
    using System.Collections.Generic;
    using RpgSaga.Configuration;
    using Xunit;

    public class ArgumentProcessorTests
    {
        [Theory]
        [InlineData("-i", "filename.json", "FileSource", "DummyHeroDestination")]
        [InlineData("-k", "45", "ArgsHeroSource", "DummyHeroDestination")]
        [InlineData("-s", "filename.json", "KeyboardSource", "FileDestination")]

        public void BuildHeroSourceCorrect(string argument, string value, string configType, string destination)
        {
            List<string> args = new List<string>() { argument, value };
            ArgumentsProcessor argumentProcessor = new ();

            var heroSource = argumentProcessor.BuildHeroSource(args);
            var heroDestination = argumentProcessor.BuildHeroDestination(args);

            Assert.True(heroSource.GetType().Name == configType && heroDestination.GetType().Name == destination);
        }

        [Theory]
        [InlineData("-k", "34", "-s", "filename.json", "ArgsHeroSource", "FileDestination")]
        public void GetConfigWithMixedArgs(string firstArgument, string firstValue, string secondArgument, string secondValue, string configType, string destination)
        {
            List<string> args = new List<string>() { firstArgument, firstValue, secondArgument, secondValue };
            ArgumentsProcessor argumentProcessor = new ();

            var heroSource = argumentProcessor.BuildHeroSource(args);
            var heroDestination = argumentProcessor.BuildHeroDestination(args);

            Assert.True(heroSource.GetType().Name == configType && heroDestination.GetType().Name == destination);
        }

        [Theory]
        [InlineData("-f", "34")]
        public void BuildHeroSourceException(string argument, string value)
        {
            List<string> args = new List<string>() { argument, value };
            ArgumentsProcessor argumentProcessor = new ();

            void Action() => argumentProcessor.BuildHeroSource(args);

            Assert.Throws<ArgumentException>(Action);
        }
    }
}
