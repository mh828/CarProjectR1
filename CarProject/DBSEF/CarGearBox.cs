
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
    
public partial class CarGearBox
{

    public int CarGearBoxId { get; set; }

    public string GearBoxCode { get; set; }

    public string GearBoxType { get; set; }

    public Nullable<bool> GearBoxCanBeManual { get; set; }

    public Nullable<int> GearBoxShiftNumber { get; set; }

    public string GearBoxAxel { get; set; }

    public Nullable<bool> HasTransferCase { get; set; }

    public Nullable<bool> GearBoxDiffrentionalLock { get; set; }

    public string GearBoxWdType { get; set; }

    public string GearBoxDescription { get; set; }

    public Nullable<int> CarsId { get; set; }



    public virtual Car Car { get; set; }

}

}
