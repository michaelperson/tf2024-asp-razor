using System.ComponentModel.DataAnnotations;
using tf2024_asp_razor.entities.Interfaces;

namespace tf2024_asp_razor.Models.Entities.Taxable;

public class MaintenanceEntity : IEntity
{
    [Key] public long Id { get; set; }

    public string Object { get; set; }
    public DateTime Date { get; set; }

    [DataType(DataType.Duration)] public DateTime Duration { get; set; }

    public int PlaneId { get; set; }
    public PlaneEntity Plane { get; set; }

    public int ReparerId { get; set; }
    public MechanicEntity Reparer { get; set; }

    public int CheckerId { get; set; }
    public MechanicEntity Checker { get; set; }
}