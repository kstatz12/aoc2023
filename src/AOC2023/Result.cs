namespace AOC2023;

public class Result<T>
{
    private readonly bool success;
    private readonly string message;
    private readonly T? value;

    private Result(bool success, string message, T? value)
    {
        this.success = success;
        this.value = value;
        this.message = message;
    }

    public static Result<T> Success(T value) => new Result<T>(true, string.Empty, value);

    public static Result<T> Failure(string message) => new Result<T>(false, message, default(T));

    public Result<T> OnSuccess(Action<T> action)
    {
        if (success)
        {
            action(value!);
        }
        return this;
    }

    public Result<T> OnFailure(Action<string> action)
    {
        if (!success)
        {
            action(message);
        }
        return this;
    }

    public Result<T2> Bind<T2>(Func<T, Result<T2>> func)
    {
        if (success)
        {
            try
            {
                return func(value!);
            }
            catch(Exception e)
            {
                return Result<T2>.Failure(e.Message);
            }
        }
        return Result<T2>.Failure(message);
    }

    public bool IsSuccess() => success;

    public bool IsFailure() => !success;

    public T Resolve()
    {
        if (success)
        {
            return value!;
        }
        throw new InvalidOperationException(message);
    }
}
