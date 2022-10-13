using FluentValidation.Results;

namespace IceCream.Application.Commons.Bases;

public class BaseResponse<T>
{
    public  bool IsSuccess { get; set; }
    public T? Message { get; set; }
    public IEnumerable<ValidationFailure>?  Errors { get; set; }
}
