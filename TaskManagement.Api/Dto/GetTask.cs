namespace TaskManagement.Api.Dto;


public class GetTask
{
    public int Id { get; set; }
    public int Name { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
}

