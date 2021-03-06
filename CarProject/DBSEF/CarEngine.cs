//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CarProject.DBSEF
{
    using System;
    using System.Collections.Generic;
    
    public partial class CarEngine
    {
        public int CarEngineId { get; set; }
        public string EngineType { get; set; }
        public Nullable<int> EngineCylinderNumber { get; set; }
        public Nullable<int> EnginePowerHpRpm { get; set; }
        public Nullable<int> EngineTorque { get; set; }
        public Nullable<int> EnginePowerHpTon { get; set; }
        public Nullable<int> EnginePowerHpLitr { get; set; }
        public Nullable<int> EngineMaxSpeed { get; set; }
        public Nullable<double> EngineZeroToH { get; set; }
        public string EngineDescription { get; set; }
        public Nullable<int> CarsId { get; set; }
        public Nullable<int> EngineSize { get; set; }
        public string EngineFuel { get; set; }
    
        public virtual Car Car { get; set; }
    }
}
