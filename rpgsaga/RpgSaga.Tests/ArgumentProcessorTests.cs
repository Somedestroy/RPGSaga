namespace RpgSaga.Tests
{
    using System;
    using RpgSaga.Configuration;
    using Xunit;

    public class ArgumentProcessorTests
    {
        [Theory]
        [InlineData("-i", "filename.json", "FileConfig", false)]
        [InlineData("-k", "45", "ArgsConfig", false)]
        [InlineData("-s", "filename.json", "KeyboardConfig", true)]

        public void SelectedConfigIsCorrect(string argument, string value, string configType, bool needToSave)
        {
            string[] args = { argument, value };
            ArgumentsProcessor argumentProcessor = new ArgumentsProcessor();

            var result = argumentProcessor.SelectConfig(args);

            Assert.True(result.Item1.GetType().Name == configType && result.Item2 == needToSave);
        }

        [Theory]
        [InlineData("-i", "filename.json", "-s", "filename.json", "FileConfig", true)]
        [InlineData("-k", "34", "-s", "filename.json", "ArgsConfig", true)]
        public void SelectConfigWithMixedArgs(string firstArgument, string firstValue, string secondArgument, string secondValue, string configType, bool needToSave)
        {
            string[] args = { firstArgument, firstValue, secondArgument, secondValue };
            ArgumentsProcessor argumentProcessor = new ArgumentsProcessor();

            var result = argumentProcessor.SelectConfig(args);

            Assert.True(result.Item1.GetType().Name == configType && result.Item2 == needToSave);
        }

        [Theory]
        [InlineData("KeyboardConfig", false)]
        public void SelectConfigIfArgsCountIsZero(string configType, bool needToSave)
        {
            string[] args = new string[] { };

            ArgumentsProcessor argumentProcessor = new ArgumentsProcessor();

            var result = argumentProcessor.SelectConfig(args);

            Assert.True(result.Item1.GetType().Name == configType && result.Item2 == needToSave);
        }

        [Theory]
        [InlineData("-l", "filename.json")]
        [InlineData("-3", "filename.json")]
        [InlineData("-/", "filename.json")]
        public void Incorrect(string argument, string value)
        {
            string[] args = { argument, value };
            ArgumentsProcessor argumentProcessor = new ArgumentsProcessor();

            Action action = () => argumentProcessor.SelectConfig(args);

            Assert.Throws<ArgumentException>(action);
        }
    }
}
