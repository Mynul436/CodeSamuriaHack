using System.Drawing;
using System.Globalization;
using api.Helper;
using core.Entities.Model;
using core.Interfaces;
using CsvHelper;
using CsvHelper.Configuration;

namespace api.Data
{
    public class Seed
    {
        // public static async Task ClearConnections(DataContext context)
        // {

        // }
        public static async Task SeedProposal(IUnitOfWork _unitOfWork)
        {
            if(await _unitOfWork.ProposalRepository.isExitAsync(x => true)) return ;

              var csvConfig = new CsvConfiguration(CultureInfo.CurrentCulture)
            {
                HasHeaderRecord = false
            };

            using var streamReader = File.OpenText("Data/SampleCSV/proposals.csv");

            using var csvReader = new CsvReader(streamReader, csvConfig);

            string value;

            while(csvReader.Read())
            {
                var proposal = new Proposals();
                for(int i= 0; csvReader.TryGetField<string>(i, out value); i++)
                {
                    Console.WriteLine(i + " "  + value);
                    if (value =="name" || 
                     value ==  "location" || 
                    value == "latitude" || 
                    value ==    "longitude" || 
                    value ==   "exec" || 
                   value ==  "cost" || 
                   value ==  "timespan" || 
                   value ==  "project_id" || 
                   value ==  "goal" || 
                   value ==  "proposal_date"
                    ) continue;
                    if(i == 0) proposal.name = value;
                    if(i == 1) proposal.location = value;
                    if(i == 2) proposal.latitude = Double.Parse(value);
                    if(i == 3) proposal.longitude = Double.Parse(value);
                    if(i == 4) proposal.exec = value;
                    if(i == 5) proposal.cost = Double.Parse(value);
                    if(i == 6) proposal.timespan = Double.Parse(value);
                    if(i == 7) proposal.project_id = value;
                    if(i == 8) proposal.goal = value;
                    if(i == 9) proposal.proposal_date = DateTime.Parse(value);
                }

                _unitOfWork.ProposalRepository.AddAsync(proposal);
            }

            await _unitOfWork.CommitAsync();
        }


        public static async Task SeedAgencies(IUnitOfWork _unitOfWork)        {
            if(await _unitOfWork.AgencyRepository.isExitAsync(x => true)) return ;
            var csvConfig = new CsvConfiguration(CultureInfo.CurrentCulture)
            {
                HasHeaderRecord = false
            };

            using var streamReader = File.OpenText("Data/SampleCSV/agencies.csv");
            using var csvReader = new CsvReader(streamReader, csvConfig);
            string value;

            while(csvReader.Read())
            {
                var agency = new Agency();
                for(int i= 0; csvReader.TryGetField<string>(i, out value); i++)
                {
                    if(value == "code" || 
                        value == "name" || 
                        value == "type" || 
                        value == "description"
                        ) continue;

                    if(i == 0) agency.code = value;
                    if(i == 1) agency.name = value;
                    if(i == 2) agency.type = value;
                    if(i == 3) agency.description = value;

                }

                agency.email = RadomString.RandomString(6) + "@gmail.com";
                agency.password = "Pa$$word";

                _unitOfWork.AgencyRepository.AddAsync(agency);
            }

            await _unitOfWork.CommitAsync();
        }

         public static async Task SeedComponents(IUnitOfWork _unitOfWork)
        {
            if(await _unitOfWork.ProposalRepository.isExitAsync(x => true)) return ;

              var csvConfig = new CsvConfiguration(CultureInfo.CurrentCulture)
            {
                HasHeaderRecord = false
            };

            using var streamReader = File.OpenText("Data/SampleCSV/proposals.csv");
  
            using var csvReader = new CsvReader(streamReader, csvConfig);

            string value;

            while(csvReader.Read())
            {
                var proposal = new Proposals();
                for(int i= 0; csvReader.TryGetField<string>(i, out value); i++)
                {
                   
                }

              //  _unitOfWork.ProposalRepository.AddAsync(proposal);
            }

           // await _unitOfWork.CommitAsync();
        }


         public static async Task SeedConstraints(IUnitOfWork _unitOfWork)
        {
            if(await _unitOfWork.Constraints.isExitAsync(x => true)) return ;

              var csvConfig = new CsvConfiguration(CultureInfo.CurrentCulture)
            {
                HasHeaderRecord = false
            };

            using var streamReader = File.OpenText("Data/SampleCSV/constraints.csv");

            using var csvReader = new CsvReader(streamReader, csvConfig);

            string value;

            while(csvReader.Read())
            {
                var proposal = new Constraint();
                for(int i= 0; csvReader.TryGetField<string>(i, out value); i++)
                {
                   if(
                        value == "code"   || 
                        value == "max_limit" || 
                        value == "constraint_type"
                    ) continue;

                    if(i == 0) proposal.code = value;
                    if(i == 1) proposal.max_limit = int.Parse(value);
                    if(i == 2) proposal.constraint_type = value;

                }

                _unitOfWork.Constraints.AddAsync(proposal);
            }

           await _unitOfWork.CommitAsync();
        }

         public static async Task SeedExtra(IUnitOfWork _unitOfWork)
        {
            if(await _unitOfWork.ProposalRepository.isExitAsync(x => true)) return ;

              var csvConfig = new CsvConfiguration(CultureInfo.CurrentCulture)
            {
                HasHeaderRecord = false
            };

            using var streamReader = File.OpenText("Data/SampleCSV/proposals.csv");

            using var csvReader = new CsvReader(streamReader, csvConfig);

            string value;

            while(csvReader.Read())
            {
                var proposal = new Proposals();
                for(int i= 0; csvReader.TryGetField<string>(i, out value); i++)
                {
                   
                }

              //  _unitOfWork.ProposalRepository.AddAsync(proposal);
            }

           // await _unitOfWork.CommitAsync();
        }
        public static async Task SeedProjects(IUnitOfWork _unitOfWork)
        {
            if(await _unitOfWork.ProjectRepository.isExitAsync(x => true)) return ;

            

            var csvConfig = new CsvConfiguration(CultureInfo.CurrentCulture)
            {
                HasHeaderRecord = false
            };

            using var streamReader = File.OpenText("Data/SampleCSV/projects.csv");

            using var csvReader = new CsvReader(streamReader, csvConfig);

            string value;
            
            var projectList = new List<Project>();
            while (csvReader.Read())
            {

                var project = new Project();

                for(int i= 0; csvReader.TryGetField<string>(i, out value); i++)
                {
                 //  Console.WriteLine( i + " " + value);
                    if( value == "name" || 
                        value == "location" || 
                        value == "latitude" || 
                        value == "longitude" || 
                        value == "exec" || 
                        value == "cost" || 
                        value == "timespan" ||
                        value == "project_id" || 
                        value == "goal" || 
                        value == "start_date" || 
                        value == "completion" || 
                        value == "actual_cost"
                    ) continue;


                    if(i == 0) project.name = value;
                    if(i == 1) project.location = value;
                    if(i == 2) project.latitude = Double.Parse(value.ToString());
                    if(i == 3) project.longitude = Double.Parse(value);
                    if(i == 4) project.exec = value;
                    if(i == 5) project.cost = Double.Parse(value);
                    if(i == 6) project.timespan = Double.Parse(value);
                    if(i == 7) project.project_id = value;
                    if(i == 8) project.goal = value;
                    if(i == 9) {

                        String date = value[0].ToString()+value[1].ToString();
                        String month = value[3].ToString()+value[4].ToString();
                        String year =  "20" + value[6].ToString()+value[7].ToString();

                        project.start_date = new DateTime(int.Parse(year), int.Parse(month), int.Parse(date));
                    }
                    if(i == 10) project.completion = Double.Parse(value);
                    if(i == 11) project.actual_cost = Double.Parse(value);
                }
                
                projectList.Add(project);
            }

            foreach(var project in projectList){
                _unitOfWork.ProjectRepository.AddAsync(project);
            }

            try{
                await _unitOfWork.CommitAsync();
            }
            catch(Exception ex){

            }
            
        }
          
        }
}
