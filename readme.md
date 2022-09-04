# Working with broken Sequences (C#)

In this article with code samples learn how to find missing elements in sequences.

There are two example projects

- Find `gaps` identifiers in a SQL-Server table found in the project `DatabaseExampleConsoleApp` which explains how to perform the task of finding `gaps`.
- Find missing elements (gaps) in an `int` array or from reading data from a file with primary keys and one or more are missing.

# With SQL-Server

When working with a SQL-Server database when records are removed with a primary key there become gaps[^1] which can be problematic outside of normal removal of rows. To find out how to query for gaps see the code in `DatabaseExampleConsoleApp` which first executes a select statement to find how many rows are in the table which may have gaps followed by another query to get missing keys.

The following will create a temp table with gaps and use the query used the project `DatabaseExampleConsoleApp` to get gaps. So this means you can try this out without running example code.

```sql
DECLARE @BrokenTable TABLE (ID INT);
INSERT INTO @BrokenTable VALUES (1);
INSERT INTO @BrokenTable VALUES (3);
INSERT INTO @BrokenTable VALUES (5);
INSERT INTO @BrokenTable VALUES (7);
INSERT INTO @BrokenTable VALUES (9);
WITH CTE
AS (SELECT 1 AS Number
    UNION ALL
    SELECT Number + 1
    FROM CTE
    WHERE Number <= 100)
SELECT TOP (5) *
FROM CTE
WHERE Number NOT IN (SELECT ID FROM @BrokenTable)
ORDER BY Number
OPTION (MAXRECURSION 0);
```

# With int array

A basic example were 4, 5, 6, 8, 9, 11, 12, 13 and 14 are missing from the following array

```csharp
int[] sequence1 = new[] { 1, 2, 3, 7, 10, 15 };
```

First step might be to see if there are gaps, in this case using a language exension

```csharp
[DebuggerStepThrough]
public static bool IsSequenceBroken(this int[] sequence)
{
    return sequence
        .Sort()
        .Zip(sequence.Skip(1), (valueLeft, valueRight)
        => valueRight - valueLeft)
            .Any(item => item != 1);
}
```

If there are gaps the following language extension will return them.

```csharp
[DebuggerStepThrough]
public static int[] Missing(this int[] sequence)
{
    Array.Sort(sequence);
    return Enumerable
        .Range(1, sequence[^1])
        .Except(sequence)
        .ToArray();
}
```

We can do the same with a `list` of `int`

```csharp
[DebuggerStepThrough]
public static int[] Missing(this List<int> sequence)
{
    Array.Sort(sequence.ToArray());
    return Enumerable
        .Range(1, sequence[^1])
        .Except(sequence)
        .ToArray();
}
```

Another common type is IEnumerable&lt;int>

```csharp
[DebuggerStepThrough]
public static int[] Missing(this IEnumerable<int> sequence)
{
    Array.Sort(sequence.ToArray());
    return Enumerable
        .Range(1, sequence.Last())
        .Except(sequence)
        .ToArray();
}
```

:sparkle: notice in each of the above we sort the type, if we pass say `{ 11, 2, 3, 7, 10, 1 }` in the method will fail as the sequence is out of order.

Perhaps a practical example, reading a list of a specfic type from a file eg.

```csharp
public partial class Contacts
{

    public int ContactId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int? ContactTypeIdentifier { get; set; }
}
```

- Read in the file as shown in FileOperations.ReadContacts than take the list and use the `Missing` language exension used on a simple `int array` and get missng `ContactId`.

```csharp
public static int[] MissingContactIdentifiers()
{
    var (_, contacts) = ReadContacts("Contacts.csv");
    var existingIdentifiers = contacts.Select(x => x.ContactId).ToList();
    return existingIdentifiers.Missing();
}
```

# Summary

What has been presented, finding gaps in integers is something seldom needed but having this `tucked away` in your tool belt can save a developer time by having this code rather than code it.

## See also

This article provides a way to store `tucked away` code 
[Visual Studio Code stash with VS-Code](https://social.technet.microsoft.com/wiki/contents/articles/54244.visual-studio-code-stash-with-vs-code.aspx)


[^1]: The "gaps and islands" problem is a scenario in which you need to identify groups of continuous data (`islands`) and groups where the data is missing (`gaps`) across a particular sequence.