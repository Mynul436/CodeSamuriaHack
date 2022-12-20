using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace core.Entities.Model
{
    public class Project : BaseEntity
    {
        public string? name {get;set;} 
        public string? location {get; set;}

        public Double latitude {get;set;}
        public Double longitude {get; set;}

        public string? exec {get;set;}
        public Double cost {get;set;}
        public Double timespan {get;set;}
        public  string? project_id {get;set;}
        public string? goal {get;set;}
        public  DateTime start_date {get;set;}
        public Double completion {get;set;}
        public Double actual_cost {get;set;}
    }
}