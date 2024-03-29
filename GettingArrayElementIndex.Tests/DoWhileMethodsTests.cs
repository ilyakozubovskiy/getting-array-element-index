﻿using System;
using NUnit.Framework;

// ReSharper disable StringLiteralTypo
#pragma warning disable CA1707

namespace GettingArrayElementIndex.Tests
{
    [TestFixture]
    public sealed class DoWhileMethodsTests
    {
        [Test]
        public void GetIndexOfChar_NullArray_ThrowsException()
        {
            // Act
            Assert.Throws<ArgumentNullException>(() => (null as ulong[]).GetIndexOf(0));
        }

        [TestCase(new ulong[0], 0ul, ExpectedResult = -1)]
        [TestCase(new ulong[] { 0, 1, 2, 3, 1, 2, 3 }, 0ul, ExpectedResult = 0)]
        [TestCase(new ulong[] { 0, 1, 2, 3, 1, 2, 3 }, 1ul, ExpectedResult = 1)]
        [TestCase(new ulong[] { 0, 1, 2, 3, 1, 2, 3 }, 2ul, ExpectedResult = 2)]
        [TestCase(new ulong[] { 0, 1, 2, 3, 1, 2, 3 }, 3ul, ExpectedResult = 3)]
        [TestCase(new ulong[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 9ul, ExpectedResult = 9)]
        [TestCase(new ulong[] { 0, 1, 2, 3, 1, 2, 3 }, 4ul, ExpectedResult = -1)]
        public int GetIndexOfChar_NonEmptyArray_ReturnsPosition(ulong[] arrayToSearch, ulong value)
        {
            // Act
            return arrayToSearch.GetIndexOf(value);
        }

        [Test]
        public void GetIndexOfCharStartIndexCount_NullArray_ThrowsException()
        {
            // Act
            Assert.Throws<ArgumentNullException>(() => (null as ulong[]).GetIndexOf(0, 0, 0));
        }

        [Test]
        public void GetIndexOfCharStartIndexCount_StartIndexLessZero_ThrowsException()
        {
            // Act
            Assert.Throws<ArgumentOutOfRangeException>(() => Array.Empty<ulong>().GetIndexOf(0, -1, 0));
        }

        [Test]
        public void GetIndexOfCharStartIndexCount_StartIndexGreaterArrayLength_ThrowsException()
        {
            // Act
            Assert.Throws<ArgumentOutOfRangeException>(() => Array.Empty<ulong>().GetIndexOf(0, 1, 0));
        }

        [Test]
        public void GetIndexOfCharStartIndexCount_CountLessZero_ThrowsException()
        {
            // Act
            Assert.Throws<ArgumentOutOfRangeException>(() => Array.Empty<ulong>().GetIndexOf(0, 0, -1));
        }

        [TestCase(new ulong[0], 0ul, 0, 0, ExpectedResult = -1)]
        [TestCase(new ulong[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, 0ul, 0, 9, ExpectedResult = 0)]
        [TestCase(new ulong[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, 0ul, 0, 14, ExpectedResult = 0)]
        [TestCase(new ulong[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, 0ul, 1, 8, ExpectedResult = 7)]
        [TestCase(new ulong[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, 0ul, 1, 4, ExpectedResult = -1)]
        [TestCase(new ulong[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, 0ul, 7, 1, ExpectedResult = 7)]
        [TestCase(new ulong[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, 0ul, 9, 5, ExpectedResult = 11)]
        [TestCase(new ulong[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, 1ul, 0, 9, ExpectedResult = 1)]
        [TestCase(new ulong[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, 1ul, 0, 14, ExpectedResult = 1)]
        [TestCase(new ulong[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, 1ul, 1, 8, ExpectedResult = 1)]
        [TestCase(new ulong[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, 1ul, 1, 4, ExpectedResult = 1)]
        [TestCase(new ulong[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, 1ul, 2, 1, ExpectedResult = -1)]
        [TestCase(new ulong[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, 1ul, 6, 1, ExpectedResult = -1)]
        [TestCase(new ulong[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, 1ul, 4, 1, ExpectedResult = 4)]
        [TestCase(new ulong[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, 1ul, 9, 5, ExpectedResult = 12)]
        [TestCase(new ulong[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, 3ul, 0, 9, ExpectedResult = 3)]
        [TestCase(new ulong[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, 3ul, 0, 14, ExpectedResult = 3)]
        [TestCase(new ulong[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, 3ul, 1, 8, ExpectedResult = 3)]
        [TestCase(new ulong[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, 3ul, 1, 4, ExpectedResult = 3)]
        [TestCase(new ulong[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, 3ul, 2, 1, ExpectedResult = -1)]
        [TestCase(new ulong[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, 3ul, 6, 1, ExpectedResult = 6)]
        [TestCase(new ulong[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, 3ul, 4, 1, ExpectedResult = -1)]
        [TestCase(new ulong[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, 3ul, 9, 5, ExpectedResult = 10)]
        [TestCase(new ulong[] { 0, 1, 2, 3, 1, 2, 3 }, 4ul, 0, 7, ExpectedResult = -1)]
        public int GetIndexOfChar_NonEmptyArray_ReturnsPosition2(ulong[] arrayToSearch, ulong value, int startIndex, int count)
        {
            // Act
            return arrayToSearch.GetIndexOf(value, startIndex, count);
        }

        [Test]
        public void GetLastIndexOfChar_NullArray_ThrowsException()
        {
            // Act
            Assert.Throws<ArgumentNullException>(() => (null as ulong[]).GetLastIndexOf(0));
        }

        [TestCase(new ulong[0], 0ul, ExpectedResult = -1)]
        [TestCase(new ulong[] { 0, 1, 2, 3, 1, 2, 3 }, 0ul, ExpectedResult = 0)]
        [TestCase(new ulong[] { 0, 1, 2, 3, 1, 2, 3 }, 1ul, ExpectedResult = 4)]
        [TestCase(new ulong[] { 0, 1, 2, 3, 1, 2, 3 }, 2ul, ExpectedResult = 5)]
        [TestCase(new ulong[] { 0, 1, 2, 3, 1, 2, 3 }, 3ul, ExpectedResult = 6)]
        [TestCase(new ulong[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 9ul, ExpectedResult = 9)]
        [TestCase(new ulong[] { 0, 1, 2, 3, 1, 2, 3 }, 4ul, ExpectedResult = -1)]
        public int GetLastIndexOfChar_NonEmptyArray_ReturnsPosition(ulong[] arrayToSearch, ulong value)
        {
            // Act
            return arrayToSearch.GetLastIndexOf(value);
        }

        [Test]
        public void GetLastIndexOfCharStartIndexCount_NullArray_ThrowsException()
        {
            // Act
            Assert.Throws<ArgumentNullException>(() => (null as ulong[]).GetLastIndexOf(0, 0, 0));
        }

        [Test]
        public void GetLastIndexOfCharStartIndexCount_StartIndexLessZero_ThrowsException()
        {
            // Act
            Assert.Throws<ArgumentOutOfRangeException>(() => Array.Empty<ulong>().GetLastIndexOf(0, -1, 0));
        }

        [Test]
        public void GetLastIndexOfCharStartIndexCount_StartIndexGreaterArrayLength_ThrowsException()
        {
            // Act
            Assert.Throws<ArgumentOutOfRangeException>(() => Array.Empty<ulong>().GetLastIndexOf(0, 1, 0));
        }

        [Test]
        public void GetLastIndexOfCharStartIndexCount_CountLessZero_ThrowsException()
        {
            // Act
            Assert.Throws<ArgumentOutOfRangeException>(() => Array.Empty<ulong>().GetLastIndexOf(0, 0, -1));
        }

        [TestCase(new ulong[0], 0ul, 0, 0, ExpectedResult = -1)]
        [TestCase(new ulong[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, 0ul, 0, 9, ExpectedResult = 7)]
        [TestCase(new ulong[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, 0ul, 0, 14, ExpectedResult = 11)]
        [TestCase(new ulong[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, 0ul, 1, 8, ExpectedResult = 7)]
        [TestCase(new ulong[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, 0ul, 1, 4, ExpectedResult = -1)]
        [TestCase(new ulong[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, 0ul, 7, 1, ExpectedResult = 7)]
        [TestCase(new ulong[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, 0ul, 9, 5, ExpectedResult = 11)]
        [TestCase(new ulong[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, 1ul, 0, 9, ExpectedResult = 8)]
        [TestCase(new ulong[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, 1ul, 0, 14, ExpectedResult = 12)]
        [TestCase(new ulong[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, 1ul, 1, 8, ExpectedResult = 8)]
        [TestCase(new ulong[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, 1ul, 1, 4, ExpectedResult = 4)]
        [TestCase(new ulong[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, 1ul, 2, 1, ExpectedResult = -1)]
        [TestCase(new ulong[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, 1ul, 6, 1, ExpectedResult = -1)]
        [TestCase(new ulong[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, 1ul, 4, 1, ExpectedResult = 4)]
        [TestCase(new ulong[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, 1ul, 9, 5, ExpectedResult = 12)]
        [TestCase(new ulong[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, 3ul, 0, 9, ExpectedResult = 6)]
        [TestCase(new ulong[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, 3ul, 0, 14, ExpectedResult = 10)]
        [TestCase(new ulong[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, 3ul, 1, 8, ExpectedResult = 6)]
        [TestCase(new ulong[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, 3ul, 1, 4, ExpectedResult = 3)]
        [TestCase(new ulong[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, 3ul, 2, 1, ExpectedResult = -1)]
        [TestCase(new ulong[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, 3ul, 6, 1, ExpectedResult = 6)]
        [TestCase(new ulong[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, 3ul, 4, 1, ExpectedResult = -1)]
        [TestCase(new ulong[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, 3ul, 9, 5, ExpectedResult = 10)]
        [TestCase(new ulong[] { 0, 1, 2, 3, 1, 2, 3 }, 4ul, 0, 7, ExpectedResult = -1)]
        public int GetLastIndexOfCharStartIndexCount_NonEmptyArray_ReturnsPosition(ulong[] arrayToSearch, ulong value, int startIndex, int count)
        {
            // Act
            return arrayToSearch.GetLastIndexOf(value, startIndex, count);
        }
    }
}
