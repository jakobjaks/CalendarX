namespace Contracts.DAL.Base.Mappers
{
    public interface IBaseDALMapper
    {
        TOutObject Map<TOutObject>(object inObject)
            where TOutObject: class;
    }
}