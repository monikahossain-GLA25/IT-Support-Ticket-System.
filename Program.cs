using System;
using System.Collections.Generic;
using System.Linq;

public class Ticket
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Priority { get; set; }
    public string Status { get; set; }
    public string Department { get; set; }
    public int? AgentId { get; set; }
    public int ResolutionHours { get; set; }

    public List<string> Tags { get; set; } = new();
}

public class Agent
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Team { get; set; }
}
