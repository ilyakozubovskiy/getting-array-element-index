﻿using System;
using NUnit.Framework;

// ReSharper disable StringLiteralTypo
#pragma warning disable CA1707

namespace GettingArrayElementIndex.Tests
{
    [TestFixture]
    public sealed class ForMethodsTests
    {
        [Test]
        public void GetIndexOf_NullArray_ThrowsException()
        {
            // Act
            Assert.Throws<ArgumentNullException>(() => (null as uint[]).GetIndexOf(0));
        }

        [TestCase(new uint[0], 0u, ExpectedResult = -1)]
        [TestCase(new uint[] { 0, 1, 2, 3, 1, 2, 3 }, 0u, ExpectedResult = 0)]
        [TestCase(new uint[] { 0, 1, 2, 3, 1, 2, 3 }, 1u, ExpectedResult = 1)]
        [TestCase(new uint[] { 0, 1, 2, 3, 1, 2, 3 }, 2u, ExpectedResult = 2)]
        [TestCase(new uint[] { 0, 1, 2, 3, 1, 2, 3 }, 3u, ExpectedResult = 3)]
        [TestCase(new uint[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 9u, ExpectedResult = 9)]
        [TestCase(new uint[] { 0, 1, 2, 3, 1, 2, 3 }, 4u, ExpectedResult = -1)]
        public int GetIndexOf_NonEmptyArray_ReturnsPosition(uint[] arrayToSearch, uint value)
        {
            // Act
            return arrayToSearch.GetIndexOf(value);
        }

        [Test]
        public void GetIndexOfStartIndexCount_NullArray_ThrowsException()
        {
            // Act
            Assert.Throws<ArgumentNullException>(() => (null as uint[]).GetIndexOf(0, 0, 0));
        }

        [Test]
        public void GetIndexOfStartIndexCount_StartIndexLessZero_ThrowsException()
        {
            // Act
            Assert.Throws<ArgumentOutOfRangeException>(() => Array.Empty<uint>().GetIndexOf(0, -1, 0));
        }

        [Test]
        public void GetIndexOfStartIndexCount_StartIndexGreaterArrayLength_ThrowsException()
        {
            // Act
            Assert.Throws<ArgumentOutOfRangeException>(() => Array.Empty<uint>().GetIndexOf(0, 1, 0));
        }

        [Test]
        public void GetIndexOfStartIndexCount_CountLessZero_ThrowsException()
        {
            // Act
            Assert.Throws<ArgumentOutOfRangeException>(() => Array.Empty<uint>().GetIndexOf(0, 0, -1));
        }

        [TestCase(new uint[0], 0u, 0, 0, ExpectedResult = -1)]
        [TestCase(new uint[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, 0u, 0, 9, ExpectedResult = 0)]
        [TestCase(new uint[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, 0u, 0, 14, ExpectedResult = 0)]
        [TestCase(new uint[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, 0u, 1, 8, ExpectedResult = 7)]
        [TestCase(new uint[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, 0u, 1, 4, ExpectedResult = -1)]
        [TestCase(new uint[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, 0u, 7, 1, ExpectedResult = 7)]
        [TestCase(new uint[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, 0u, 9, 5, ExpectedResult = 11)]
        [TestCase(new uint[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, 1u, 0, 9, ExpectedResult = 1)]
        [TestCase(new uint[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, 1u, 0, 14, ExpectedResult = 1)]
        [TestCase(new uint[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, 1u, 1, 8, ExpectedResult = 1)]
        [TestCase(new uint[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, 1u, 1, 4, ExpectedResult = 1)]
        [TestCase(new uint[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, 1u, 2, 1, ExpectedResult = -1)]
        [TestCase(new uint[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, 1u, 6, 1, ExpectedResult = -1)]
        [TestCase(new uint[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, 1u, 4, 1, ExpectedResult = 4)]
        [TestCase(new uint[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, 1u, 9, 5, ExpectedResult = 12)]
        [TestCase(new uint[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, 3u, 0, 9, ExpectedResult = 3)]
        [TestCase(new uint[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, 3u, 0, 14, ExpectedResult = 3)]
        [TestCase(new uint[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, 3u, 1, 8, ExpectedResult = 3)]
        [TestCase(new uint[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, 3u, 1, 4, ExpectedResult = 3)]
        [TestCase(new uint[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, 3u, 2, 1, ExpectedResult = -1)]
        [TestCase(new uint[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, 3u, 6, 1, ExpectedResult = 6)]
        [TestCase(new uint[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, 3u, 4, 1, ExpectedResult = -1)]
        [TestCase(new uint[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, 3u, 9, 5, ExpectedResult = 10)]
        [TestCase(new uint[] { 0, 1, 2, 3, 1, 2, 3 }, 4u, 0, 7, ExpectedResult = -1)]
        public int GetIndexOf_NonEmptyArray_ReturnsPosition2(uint[] arrayToSearch, uint value, int startIndex, int count)
        {
            // Act
            return arrayToSearch.GetIndexOf(value, startIndex, count);
        }

        [Test]
        public void GetLastIndexOfChar_NullArray_ThrowsException()
        {
            // Act
            Assert.Throws<ArgumentNullException>(() => (null as uint[]).GetLastIndexOf(0));
        }

        [TestCase(new uint[0], 0u, ExpectedResult = -1)]
        [TestCase(new uint[] { 0, 1, 2, 3, 1, 2, 3 }, 0u, ExpectedResult = 0)]
        [TestCase(new uint[] { 0, 1, 2, 3, 1, 2, 3 }, 1u, ExpectedResult = 4)]
        [TestCase(new uint[] { 0, 1, 2, 3, 1, 2, 3 }, 2u, ExpectedResult = 5)]
        [TestCase(new uint[] { 0, 1, 2, 3, 1, 2, 3 }, 3u, ExpectedResult = 6)]
        [TestCase(new uint[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 9u, ExpectedResult = 9)]
        [TestCase(new uint[] { 0, 1, 2, 3, 1, 2, 3 }, 4u, ExpectedResult = -1)]
        public int GetLastIndexOfChar_NonEmptyArray_ReturnsPosition(uint[] arrayToSearch, uint value)
        {
            // Act
            return arrayToSearch.GetLastIndexOf(value);
        }

        [Test]
        public void GetLastIndexOfCharStartIndexCount_NullArray_ThrowsException()
        {
            // Act
            Assert.Throws<ArgumentNullException>(() => (null as uint[]).GetLastIndexOf(0, 0, 0));
        }

        [Test]
        public void GetLastIndexOfCharStartIndexCount_StartIndexLessZero_ThrowsException()
        {
            // Act
            Assert.Throws<ArgumentOutOfRangeException>(() => Array.Empty<uint>().GetLastIndexOf(0, -1, 0));
        }

        [Test]
        public void GetLastIndexOfCharStartIndexCount_StartIndexGreaterArrayLength_ThrowsException()
        {
            // Act
            Assert.Throws<ArgumentOutOfRangeException>(() => Array.Empty<uint>().GetLastIndexOf(0, 1, 0));
        }

        [Test]
        public void GetLastIndexOfCharStartIndexCount_CountLessZero_ThrowsException()
        {
            // Act
            Assert.Throws<ArgumentOutOfRangeException>(() => Array.Empty<uint>().GetLastIndexOf(0, 0, -1));
        }

        [TestCase(new uint[0], 0u, 0, 0, ExpectedResult = -1)]
        [TestCase(new uint[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, 0u, 0, 9, ExpectedResult = 7)]
        [TestCase(new uint[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, 0u, 0, 14, ExpectedResult = 11)]
        [TestCase(new uint[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, 0u, 1, 8, ExpectedResult = 7)]
        [TestCase(new uint[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, 0u, 1, 4, ExpectedResult = -1)]
        [TestCase(new uint[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, 0u, 7, 1, ExpectedResult = 7)]
        [TestCase(new uint[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, 0u, 9, 5, ExpectedResult = 11)]
        [TestCase(new uint[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, 1u, 0, 9, ExpectedResult = 8)]
        [TestCase(new uint[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, 1u, 0, 14, ExpectedResult = 12)]
        [TestCase(new uint[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, 1u, 1, 8, ExpectedResult = 8)]
        [TestCase(new uint[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, 1u, 1, 4, ExpectedResult = 4)]
        [TestCase(new uint[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, 1u, 2, 1, ExpectedResult = -1)]
        [TestCase(new uint[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, 1u, 6, 1, ExpectedResult = -1)]
        [TestCase(new uint[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, 1u, 4, 1, ExpectedResult = 4)]
        [TestCase(new uint[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, 1u, 9, 5, ExpectedResult = 12)]
        [TestCase(new uint[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, 3u, 0, 9, ExpectedResult = 6)]
        [TestCase(new uint[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, 3u, 0, 14, ExpectedResult = 10)]
        [TestCase(new uint[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, 3u, 1, 8, ExpectedResult = 6)]
        [TestCase(new uint[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, 3u, 1, 4, ExpectedResult = 3)]
        [TestCase(new uint[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, 3u, 2, 1, ExpectedResult = -1)]
        [TestCase(new uint[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, 3u, 6, 1, ExpectedResult = 6)]
        [TestCase(new uint[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, 3u, 4, 1, ExpectedResult = -1)]
        [TestCase(new uint[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, 3u, 9, 5, ExpectedResult = 10)]
        [TestCase(new uint[] { 0, 1, 2, 3, 1, 2, 3 }, 4u, 0, 7, ExpectedResult = -1)]
        public int GetLastIndexOfCharStartIndexCount_NonEmptyArray_ReturnsPosition(uint[] arrayToSearch, uint value, int startIndex, int count)
        {
            // Act
            return arrayToSearch.GetLastIndexOf(value, startIndex, count);
        }
    }
}
