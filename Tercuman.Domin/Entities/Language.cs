using Tercuman.Domin.Common;

namespace Tercuman.Domin.Entities;

public class Language : BaseEntity
{
   
    public Guid Id { get; set; }   

    public string Name { get; set; } = string.Empty;

    public string Code { get; set; } = string.Empty;
 


}