using ContainerExampleConsoleApp.Interfaces;
using ContainerExampleConsoleApp.Models;
using System.Diagnostics;

namespace ContainerExampleConsoleApp.Classes;

public static class SequenceExtensions
{

    /// <summary>
    /// Find missing elements in an int array
    /// </summary>
    /// <param name="sequence">int array which may have gaps</param>
    /// <returns>gap array or an empty array</returns>
    [DebuggerStepThrough]
    public static int[] Missing(this int[] sequence)
    {
        Array.Sort(sequence);
        return Enumerable
            .Range(1, sequence[^1])
            .Except(sequence)
            .ToArray();
    }

    /// <summary>
    /// Find missing elements in a list of int
    /// </summary>
    /// <param name="sequence">int array which may have gaps</param>
    /// <returns>gap array or an empty array</returns>
    [DebuggerStepThrough]
    public static int[] Missing(this List<int> sequence)
    {
        Array.Sort(sequence.ToArray());
        return Enumerable
            .Range(1, sequence[^1])
            .Except(sequence)
            .ToArray();
    }

    /// <summary>
    /// Find missing elements in IEnumerable&lt;int&gt;
    /// </summary>
    /// <param name="sequence">int array which may have gaps</param>
    /// <returns>gap array or an empty array</returns>
    [DebuggerStepThrough]
    public static int[] Missing(this IEnumerable<int> sequence)
    {
        Array.Sort(sequence.ToArray());
        return Enumerable
            .Range(1, sequence.Last())
            .Except(sequence)
            .ToArray();
    }

    /// <summary>
    /// If the sequence is mixed e.g. 5,1,2,3 rather than 1,2,3,5 this will fail
    /// as we need to properly sort as per <seealso cref="System.Reflection.Missing"/>
    /// </summary>
    [DebuggerStepThrough]
    public static int[] MissingWrong(this int[] sequence) =>
        Enumerable
            .Range(1, sequence[^1])
            .Except(sequence)
            .ToArray();

    /// <summary>
    /// Find gaps
    /// </summary>
    /// <param name="sender"></param>
    /// <returns></returns>
    /// <remarks>
    /// Mocked data is used to replicate data read from a database table so
    /// keys would not be out of sync.
    /// </remarks>
    [DebuggerStepThrough]
    public static int[] MissingIdentifiers(this List<IEmployee> sender)
        => sender.Select(x => x.Id).ToArray().Missing();

    [DebuggerStepThrough]
    public static int[] MissingIdentifiers(this List<Person> sender)
        => sender.Select(x => x.Id).ToArray().Missing();

    /// <summary>
    /// Determine if the sequence has missing elements
    /// </summary>
    /// <param name="sequence">int array</param>
    /// <returns>true if missing elements, false if no missing elements</returns>
    [DebuggerStepThrough]
    public static bool IsSequenceBroken(this int[] sequence)
    {
        return sequence
            .Sort()
            .Zip(sequence.Skip(1), (valueLeft, valueRight)
            => valueRight - valueLeft)
                .Any(item => item != 1);
    }

    [DebuggerStepThrough]
    public static int[] Sort(this int[] sender)
    {
        Array.Sort(sender);
        return sender;
    }
}