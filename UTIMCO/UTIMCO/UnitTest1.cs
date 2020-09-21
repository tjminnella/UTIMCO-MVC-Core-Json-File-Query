using System;
using System.Collections.Generic;
using UTIMCO.Models;
using UTIMCO.Utilities;
using Xunit;

namespace UTIMCO
{
    public class UnitTest1
    {
        [Fact]
        public void Add_SimpleJsonShouldCalucate()
        {
            // Arrange
            int expected1 = 46;
            int expected2 = 0;
            int expected3 = 248;

            // test the json string
            string UTIMCOJson = "[{\"menu\":{\"header\":\"menu1\",\"items\":[{\"id\":27},{\"id\":0,\"label\":\"Label 0\"},null,{\"id\":93},{\"id\":85},{\"id\":54},null,{\"id\":46,\"label\":\"Label 46\"}]}},{\"menu\":{\"header\":\"menu2\",\"items\":[{\"id\":81}]}},{\"menu\":{\"header\":\"menu3\",\"items\":[{\"id\":70,\"label\":\"Label 70\"},{\"id\":85,\"label\":\"Label 85\"},{\"id\":93,\"label\":\"Label 93\"},{\"id\":2}]}}]";
            List<MyArray> myArray1 = Utility.GetJsonMenus(UTIMCOJson);
            Assert.NotNull(myArray1);
            List<ResultLine> myResults1 = Utility.GetResults(myArray1);
            Assert.NotNull(myResults1);

            // Assert
            Assert.Equal(expected1, myResults1[0].TotalId);
            Assert.Equal(expected2, myResults1[1].TotalId);
            Assert.Equal(expected3, myResults1[2].TotalId);

            // test the Models
            List<MyArray> myArray = new List<MyArray>();
            // Add parts to the list.
            Menu menu1 = new Menu(){header="Menu1"
                , items = new List<Item>{
                          new Item() { id = 27}
                        , new Item() { id = 46,  label = "Label 46"}
                        , null 
            }};
            Menu menu2 = new Menu(){header="Menu2"
                , items = new List<Item>{
                          new Item() { id = 81}
            }};
            Menu menu3 = new Menu(){header="Menu1"
                , items = new List<Item>{
                          new Item() { id = 70, label = "item10"}
                        , new Item() { id = 85, label = "item10"}
                        , new Item() { id = 93, label = "item30"}
                        , new Item() { id = 2}
            }};

            myArray.Add(new MyArray() { menu = menu1 });
            myArray.Add(new MyArray() { menu = menu2 });
            myArray.Add(new MyArray() { menu = menu3 });
        
            List<ResultLine> myResults2 = Utility.GetResults(myArray);

            Assert.NotNull(myResults2);

            // Assert
            Assert.Equal(expected1, myResults2[0].TotalId);
            Assert.Equal(expected2, myResults2[1].TotalId);
            Assert.Equal(expected3, myResults2[2].TotalId);
            //force a failure expect value should be 248
            //Assert.Equal(expected3, 75);
        }
    }
}
