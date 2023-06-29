﻿using NUnit.Framework;
using System;
using System.IO;

[TestFixture]
public class RenameSuffixTest
{
    private const string OriginalFileName1 = "testfile1.txt";
    private const string NewFileName1 = "testfile1.jpg";
    private const string OriginalFileName2 = "testfile2.txt";
    private const string NewFileName2 = "testfile2.jpg";

    private const string OriginalFileSuffix = "txt";
    private const string NewFileSuffix = "jpg";

    private string TestDirectoryPath = "";

    [SetUp]
    public void Setup()
    {
        TestDirectoryPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestDirectory");
        Directory.CreateDirectory(TestDirectoryPath);

        string path1 = Path.Combine(TestDirectoryPath, OriginalFileName1);
        string path2 = Path.Combine(TestDirectoryPath, OriginalFileName2);

        Console.WriteLine(path1);

        File.WriteAllText(path1, "Text1");
        File.WriteAllText(path2, "Text2");
    }

    [TearDown]
    public void Cleanup()
    {
        Directory.Delete(TestDirectoryPath, true);
    }

    [Test]
    public void RenameSuffix_ShouldRenameFile()
    {
        // Arrange
        RenameSuffix renamer = new RenameSuffix();
        string originalFilePath1 = Path.Combine(TestDirectoryPath, OriginalFileName1);
        string renamedFilePath1 = Path.Combine(TestDirectoryPath, NewFileName1);
        string originalFilePath2 = Path.Combine(TestDirectoryPath, OriginalFileName2);
        string renamedFilePath2 = Path.Combine(TestDirectoryPath, NewFileName2);

        // Act
        renamer.changeSuffix(TestDirectoryPath, OriginalFileSuffix, NewFileSuffix);

        // Assert
        Assert.IsFalse(File.Exists(originalFilePath1), "Original file 1 should not exist");
        Assert.IsTrue(File.Exists(renamedFilePath1), "Renamed file 1 should exist");

        Assert.IsFalse(File.Exists(originalFilePath2), "Original file 2 should not exist");
        Assert.IsTrue(File.Exists(renamedFilePath2), "Renamed file 2 should exist");
    }
}