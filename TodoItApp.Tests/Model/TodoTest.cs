using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using TodoItApp.Model;

namespace TodoItApp.Tests
{
    public class TodoTest
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void BadDescriptionConstructor(string desc)
        {
            //Arrange

            int id = 0;

            //Act & assert
            Assert.Throws<ArgumentException>(() => new Todo(id, desc));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void BadDescriptionProperty(string desc)
        {
            //Arrange

            Todo todo = new Todo(0, "Good Description");

            //Act & assert

            Assert.Throws<ArgumentException>( () => todo.Description = desc );
        }
    }
}
