namespace Techdays.Core.Application.Interfaces
{
    public interface IMapInPlace<in TFrom, in TTo>
    {
        void Map(TFrom from, TTo to);
    }
}