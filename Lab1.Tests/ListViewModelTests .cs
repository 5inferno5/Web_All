﻿using System;
using System.Collections.Generic;
using System.Text;
using Lab1.DAL.Entities;
using Lab1.Models;
using Xunit;

namespace Lab1.Tests
{   
        public class ListViewModelTests
        {
            [Fact]
            public void ListViewModelCountsPages()
            {
                // Act
                var model = ListViewModel<Dish>
               .GetModel(TestData.GetDishesList(), 1, 3);
                // Assert
                Assert.Equal(2, model.TotalPages);
            }
            [Theory]
            [MemberData(memberName: nameof(TestData.Params),
           MemberType = typeof(TestData))]
            public void ListViewModelSelectsCorrectQty(int page, int qty,
           int id)
            {
                // Act
                var model = ListViewModel<Dish>
               .GetModel(TestData.GetDishesList(), page, 3);
                // Assert
                Assert.Equal(qty, model.Count);
            }
            [Theory]
            [MemberData(memberName: nameof(TestData.Params),
           MemberType = typeof(TestData))]
            public void ListViewModelHasCorrectData(int page, int qty, int
           id)
            {
                // Act
                var model = ListViewModel<Dish>
               .GetModel(TestData.GetDishesList(), page, 3);
                // Assert
                Assert.Equal(id, model[0].DishId);
            }
        }
}
