using System.Collections;
using System.Collections.Generic;
using Gframework;
using UnityEngine;

public class DatabaseBaseData : BaseData {

    /// <summary>
    /// Id
    /// </summary>
    public long Id { get; set; }
    /// <summary>
    /// Remark
    /// </summary>
    public string Description { get; set; }
    /// <summary>
    /// Is Valid
    /// </summary>
    public bool IsValid { get; set; }

}
