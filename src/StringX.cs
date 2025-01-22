namespace Xes;

/// <summary>
/// StringX is a model that check strings for empty or whitespace (something that the Nullable References Types do not handle).
/// Then stores that state.
/// This model cannot be directly instantiated, it can only be created by implicit conversion.
/// Use this model along with Null Reference Types enabled in your project.
/// </summary>
public readonly struct StringX
{
    private string Value { get; }

#pragma warning disable CS8618
    //disable nullable types warning
    private StringX(string value)
#pragma warning restore CS8618 
    {
        if (value is not null && !string.IsNullOrWhiteSpace(value))
            throw new Exception($"string {nameof(value)} cannot be empty or whitespace.");

#pragma warning disable CS8601
        //disable nullable types warning
        Value = value;
#pragma warning restore CS8601
    }

    public static implicit operator StringX(string value)
    {
        return value is null ?
            throw new NullReferenceException($"string {nameof(value)} cannot be null.") :
            new StringX(value);
    }

    public static implicit operator StringX?(string value) => new StringX(value);

    public static implicit operator string(StringX valueX) => valueX.Value is null ?
            throw new NullReferenceException($"string {nameof(valueX)} cannot be null.") :
            valueX.Value;

    public static implicit operator string?(StringX? stringX) => stringX?.Value;

    public bool IsNull() => Value is null;

    /// <summary>
    /// Returns the string value of StringX. 
    /// Maintains the same behavior as if ToString() was called on a string. 
    /// Null value results in a NullReferenceException.
    /// </summary>
    /// <returns></returns>
    public override string ToString() => Value ?? throw new NullReferenceException("Value from StringX is null (ToString not allowed)");
}