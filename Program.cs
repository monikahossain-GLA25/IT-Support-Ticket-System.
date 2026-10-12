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
public class Program
{
    public static void Main(string[] args)
    {
                List<Ticket> tickets = new()
        {
            new Ticket
            {
                Id = 1,
                Title = "Email Server Down",
                Priority = "High",
                Status = "Closed",
                Department = "Infrastructure",
                AgentId = 1,
                ResolutionHours = 4,
                Tags = new List<string> { "Email", "Server" }
            },

            new Ticket
            {
                Id = 2,
                Title = "Cannot Login",
                Priority = "Medium",
                Status = "Open",
                Department = "Application",
                AgentId = 2,
                ResolutionHours = 0,
                Tags = new List<string> { "Login", "Authentication" }
            },

            new Ticket
            {
                Id = 3,
                Title = "Database Timeout",
                Priority = "High",
                Status = "Closed",
                Department = "Database",
                AgentId = 3,
                ResolutionHours = 7,
                Tags = new List<string> { "SQL", "Database", "Performance" }
            },

            new Ticket
            {
                Id = 4,
                Title = "Printer Not Working",
                Priority = "Low",
                Status = "Open",
                Department = "Hardware",
                AgentId = null,
                ResolutionHours = 0,
                Tags = new List<string> { "Printer", "Hardware" }
            },

            new Ticket
            {
                Id = 5,
                Title = "Slow Application",
                Priority = "Medium",
                Status = "Closed",
                Department = "Application",
                AgentId = 2,
                ResolutionHours = 10,
                Tags = new List<string> { "Application", "Performance" }
            },

            new Ticket
            {
                Id = 6,
                Title = "Backup Failed",
                Priority = "High",
                Status = "Open",
                Department = "Infrastructure",
                AgentId = 1,
                ResolutionHours = 0,
                Tags = new List<string> { "Backup", "Server" }
            },

            new Ticket
            {
                Id = 7,
                Title = "SQL Report Error",
                Priority = "Medium",
                Status = "Closed",
                Department = "Database",
                AgentId = 3,
                ResolutionHours = 5,
                Tags = new List<string> { "SQL", "Report" }
            },

            new Ticket
            {
                Id = 8,
                Title = "Network Connection Lost",
                Priority = "High",
                Status = "Closed",
                Department = "Infrastructure",
                AgentId = 1,
                ResolutionHours = 3,
                Tags = new List<string> { "Network", "Infrastructure" }
            }
        };

                List<Agent> agents = new()
        {
            new Agent { Id = 1, Name = "Rahim", Team = "Infrastructure" },
            new Agent { Id = 2, Name = "Karim", Team = "Application" },
            new Agent { Id = 3, Name = "Nadia", Team = "Database" },
            new Agent { Id = 4, Name = "Farhan", Team = "Security" }
        };

        //GROUP BY AGENT AND COUNT TICKETS

        var result = from ag in agents
                     join tc in tickets
                     on ag.Id equals tc.AgentId
                    into agentTickets
                     select new
                     {
                         AgentName = ag.Name,
                         Team = ag.Name,
                         TotalTickets = agents.Count(),
                         OpenTickets = agentTickets.Count(t=> t.Status == "Open"),
                         ClosedTickets = agentTickets.Count(t => t.Status == "Closed"),


                     };
        foreach (var item in result)
        {
            Console.WriteLine($"Agent: {item.AgentName}, Team: {item.Team}, Total Tickets: {item.TotalTickets}, Open Tickets: {item.OpenTickets}, Closed Tickets: {item.ClosedTickets}");
        }


        //2.left join Return every ticket with: TicketTitle ,   Priority ,    AgentName
        var leftJoinResult = from tc in tickets
                             join ag in agents
                             on tc.AgentId equals ag.Id
                             into agentTickets
                             from ag in agentTickets.DefaultIfEmpty()
                             select new
                             {
                                 TicketTitle = tc.Title,
                                 priority = tc.Priority,
                                 AgentName = ag != null ? ag.Name : "Unassigned"
                             };
        foreach (var item in leftJoinResult)
        {
            Console.WriteLine($"Ticket: {item.TicketTitle}, Priority: {item.priority}, Agent: {item.AgentName}");
        }






}


