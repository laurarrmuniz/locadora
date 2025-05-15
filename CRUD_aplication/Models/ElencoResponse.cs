using System;
namespace CRUD_aplication.Models;

public class ElencoResponse
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public DateTime? DataNascimento { get; set; }

}
