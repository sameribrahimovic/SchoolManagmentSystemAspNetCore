namespace SchoolMS.Data.Base
{
    public interface IEntityBase
    {
        //it is goint to be inferited bay other entities/model clasess
        int Id { get; set; }
    }
}
