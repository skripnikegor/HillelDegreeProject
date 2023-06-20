

namespace DegreeProject.DB.Models.Projects
{
    internal class WorksSettings
    {
        public int Id { get; set; }
        public int WorkersQuantity { get; set; }
        public string CompoundMember { get; set; }
        public double DurationShiftHour { get; set; }
        public byte ShiftAmount { get; set; }
        public byte MachineAmount { get; set; }
        public string MachineKind { get; set; }
        public Work Work { get; set; }
    }
}
