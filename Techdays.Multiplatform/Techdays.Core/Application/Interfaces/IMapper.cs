namespace Techdays.Core.Application.Interfaces
{
    public interface IMapper<in TFrom, out TTo>
    {
        TTo Map(TFrom from);
    }
}