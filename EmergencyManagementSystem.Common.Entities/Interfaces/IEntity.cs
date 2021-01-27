namespace EmergencyManagementSystem.Common.Entities.Interfaces
{
    public interface IEntity<T> where T : struct
    {
        T Id { get; set; }
    }
}
