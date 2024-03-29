﻿using System;
using NUnit.Framework;

// ReSharper disable StringLiteralTypo
#pragma warning disable CA1707

namespace GettingArrayElementIndex.Tests
{
    [TestFixture]
    public sealed class WhileMethodsTests
    {
        [Test]
        public void GetIndexOf_NullArray_ThrowsException()
        {
            // Act
            Assert.Throws<ArgumentNullException>(() => (null as ushort[]).GetIndexOf(0));
        }

        [TestCase(new ushort[0], (ushort)0, ExpectedResult = -1)]
        [TestCase(new ushort[] { 0, 1, 2, 3, 1, 2, 3 }, (ushort)0, ExpectedResult = 0)]
        [TestCase(new ushort[] { 0, 1, 2, 3, 1, 2, 3 }, (ushort)1, ExpectedResult = 1)]
        [TestCase(new ushort[] { 0, 1, 2, 3, 1, 2, 3 }, (ushort)2, ExpectedResult = 2)]
        [TestCase(new ushort[] { 0, 1, 2, 3, 1, 2, 3 }, (ushort)3, ExpectedResult = 3)]
        [TestCase(new ushort[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, (ushort)9, ExpectedResult = 9)]
        [TestCase(new ushort[] { 0, 1, 2, 3, 1, 2, 3 }, (ushort)4, ExpectedResult = -1)]
        public int GetIndexOf_NonEmptyArray_ReturnsPosition(ushort[] arrayToSearch, ushort value)
        {
            // Act
            return arrayToSearch.GetIndexOf(value);
        }

        [Test]
        public void GetIndexOfStartIndexCount_NullArray_ThrowsException()
        {
            // Act
            Assert.Throws<ArgumentNullException>(() => (null as ushort[]).GetIndexOf(0, 0, 0));
        }

        [Test]
        public void GetIndexOfStartIndexCount_StartIndexLessZero_ThrowsException()
        {
            // Act
            Assert.Throws<ArgumentOutOfRangeException>(() => Array.Empty<ushort>().GetIndexOf(0, -1, 0));
        }

        [Test]
        public void GetIndexOfStartIndexCount_StartIndexGreaterArrayLength_ThrowsException()
        {
            // Act
            Assert.Throws<ArgumentOutOfRangeException>(() => Array.Empty<ushort>().GetIndexOf(0, 1, 0));
        }

        [Test]
        public void GetIndexOfStartIndexCount_CountLessZero_ThrowsException()
        {
            // Act
            Assert.Throws<ArgumentOutOfRangeException>(() => Array.Empty<ushort>().GetIndexOf(0, 0, -1));
        }

        [TestCase(new ushort[0], (ushort)0, 0, 0, ExpectedResult = -1)]
        [TestCase(new ushort[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, (ushort)0, 0, 9, ExpectedResult = 0)]
        [TestCase(new ushort[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, (ushort)0, 0, 14, ExpectedResult = 0)]
        [TestCase(new ushort[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, (ushort)0, 1, 8, ExpectedResult = 7)]
        [TestCase(new ushort[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, (ushort)0, 1, 4, ExpectedResult = -1)]
        [TestCase(new ushort[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, (ushort)0, 7, 1, ExpectedResult = 7)]
        [TestCase(new ushort[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, (ushort)0, 9, 5, ExpectedResult = 11)]
        [TestCase(new ushort[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, (ushort)1, 0, 9, ExpectedResult = 1)]
        [TestCase(new ushort[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, (ushort)1, 0, 14, ExpectedResult = 1)]
        [TestCase(new ushort[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, (ushort)1, 1, 8, ExpectedResult = 1)]
        [TestCase(new ushort[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, (ushort)1, 1, 4, ExpectedResult = 1)]
        [TestCase(new ushort[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, (ushort)1, 2, 1, ExpectedResult = -1)]
        [TestCase(new ushort[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, (ushort)1, 6, 1, ExpectedResult = -1)]
        [TestCase(new ushort[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, (ushort)1, 4, 1, ExpectedResult = 4)]
        [TestCase(new ushort[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, (ushort)1, 9, 5, ExpectedResult = 12)]
        [TestCase(new ushort[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, (ushort)3, 0, 9, ExpectedResult = 3)]
        [TestCase(new ushort[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, (ushort)3, 0, 14, ExpectedResult = 3)]
        [TestCase(new ushort[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, (ushort)3, 1, 8, ExpectedResult = 3)]
        [TestCase(new ushort[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, (ushort)3, 1, 4, ExpectedResult = 3)]
        [TestCase(new ushort[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, (ushort)3, 2, 1, ExpectedResult = -1)]
        [TestCase(new ushort[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, (ushort)3, 6, 1, ExpectedResult = 6)]
        [TestCase(new ushort[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, (ushort)3, 4, 1, ExpectedResult = -1)]
        [TestCase(new ushort[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, (ushort)3, 9, 5, ExpectedResult = 10)]
        [TestCase(new ushort[] { 0, 1, 2, 3, 1, 2, 3 }, (ushort)4, 0, 7, ExpectedResult = -1)]
        public int GetIndexOf_NonEmptyArray_ReturnsPosition2(ushort[] arrayToSearch, ushort value, int startIndex, int count)
        {
            // Act
            return arrayToSearch.GetIndexOf(value, startIndex, count);
        }

        [Test]
        public void GetLastIndexOf_NullArray_ThrowsException()
        {
            // Act
            Assert.Throws<ArgumentNullException>(() => (null as ushort[]).GetLastIndexOf(0));
        }

        [TestCase(new ushort[0], (ushort)0, ExpectedResult = -1)]
        [TestCase(new ushort[] { 0, 1, 2, 3, 1, 2, 3 }, (ushort)0, ExpectedResult = 0)]
        [TestCase(new ushort[] { 0, 1, 2, 3, 1, 2, 3 }, (ushort)1, ExpectedResult = 4)]
        [TestCase(new ushort[] { 0, 1, 2, 3, 1, 2, 3 }, (ushort)2, ExpectedResult = 5)]
        [TestCase(new ushort[] { 0, 1, 2, 3, 1, 2, 3 }, (ushort)3, ExpectedResult = 6)]
        [TestCase(new ushort[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, (ushort)9, ExpectedResult = 9)]
        [TestCase(new ushort[] { 0, 1, 2, 3, 1, 2, 3 }, (ushort)4, ExpectedResult = -1)]
        public int GetLastIndexOf_NonEmptyArray_ReturnsPosition(ushort[] arrayToSearch, ushort value)
        {
            // Act
            return arrayToSearch.GetLastIndexOf(value);
        }

        [Test]
        public void GetLastIndexOfStartIndexCount_NullArray_ThrowsException()
        {
            // Act
            Assert.Throws<ArgumentNullException>(() => (null as ushort[]).GetLastIndexOf(0, 0, 0));
        }

        [Test]
        public void GetLastIndexOfStartIndexCount_StartIndexLessZero_ThrowsException()
        {
            // Act
            Assert.Throws<ArgumentOutOfRangeException>(() => Array.Empty<ushort>().GetLastIndexOf(0, -1, 0));
        }

        [Test]
        public void GetLastIndexOfStartIndexCount_StartIndexGreaterArrayLength_ThrowsException()
        {
            // Act
            Assert.Throws<ArgumentOutOfRangeException>(() => Array.Empty<ushort>().GetLastIndexOf(0, 1, 0));
        }

        [Test]
        public void GetLastIndexOfStartIndexCount_CountLessZero_ThrowsException()
        {
            // Act
            Assert.Throws<ArgumentOutOfRangeException>(() => Array.Empty<ushort>().GetLastIndexOf(0, 0, -1));
        }

        [TestCase(new ushort[0], (ushort)0, 0, 0, ExpectedResult = -1)]
        [TestCase(new ushort[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, (ushort)0, 0, 9, ExpectedResult = 7)]
        [TestCase(new ushort[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, (ushort)0, 0, 14, ExpectedResult = 11)]
        [TestCase(new ushort[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, (ushort)0, 1, 8, ExpectedResult = 7)]
        [TestCase(new ushort[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, (ushort)0, 1, 4, ExpectedResult = -1)]
        [TestCase(new ushort[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, (ushort)0, 7, 1, ExpectedResult = 7)]
        [TestCase(new ushort[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, (ushort)0, 9, 5, ExpectedResult = 11)]
        [TestCase(new ushort[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, (ushort)1, 0, 9, ExpectedResult = 8)]
        [TestCase(new ushort[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, (ushort)1, 0, 14, ExpectedResult = 12)]
        [TestCase(new ushort[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, (ushort)1, 1, 8, ExpectedResult = 8)]
        [TestCase(new ushort[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, (ushort)1, 1, 4, ExpectedResult = 4)]
        [TestCase(new ushort[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, (ushort)1, 2, 1, ExpectedResult = -1)]
        [TestCase(new ushort[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, (ushort)1, 6, 1, ExpectedResult = -1)]
        [TestCase(new ushort[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, (ushort)1, 4, 1, ExpectedResult = 4)]
        [TestCase(new ushort[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, (ushort)1, 9, 5, ExpectedResult = 12)]
        [TestCase(new ushort[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, (ushort)3, 0, 9, ExpectedResult = 6)]
        [TestCase(new ushort[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, (ushort)3, 0, 14, ExpectedResult = 10)]
        [TestCase(new ushort[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, (ushort)3, 1, 8, ExpectedResult = 6)]
        [TestCase(new ushort[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, (ushort)3, 1, 4, ExpectedResult = 3)]
        [TestCase(new ushort[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, (ushort)3, 2, 1, ExpectedResult = -1)]
        [TestCase(new ushort[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, (ushort)3, 6, 1, ExpectedResult = 6)]
        [TestCase(new ushort[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, (ushort)3, 4, 1, ExpectedResult = -1)]
        [TestCase(new ushort[] { 0, 1, 2, 3, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 }, (ushort)3, 9, 5, ExpectedResult = 10)]
        [TestCase(new ushort[] { 0, 1, 2, 3, 1, 2, 3 }, (ushort)4, 0, 7, ExpectedResult = -1)]
        public int GetLastIndexOfStartIndexCount_NonEmptyArray_ReturnsPosition(ushort[] arrayToSearch, ushort value, int startIndex, int count)
        {
            // Act
            return arrayToSearch.GetLastIndexOf(value, startIndex, count);
        }
    }
}
