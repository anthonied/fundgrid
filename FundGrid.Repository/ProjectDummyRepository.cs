using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fundgrid.Data;
using FunGrid.Domain;
using FunGrid.Domain.Interfaces;

namespace FundGrid.Repository
{
    public class ProjectDummyRepository: IProject
    {

       

        private List<Project> _dummyProjects =
            new List<Project>
            {
                new Project
                {
                    Id = 1,
                    Name = "Hangman Hunter",
                    Description = "Hang the hunter"
                },
                new Project
                {
                    Id = 2,
                    Name = "Duke Nukem Last Stand",
                    Description = "Again"
                },
                new Project 
                {
                    Id = 3,
                    Name = "Cash Grab",
                    Description = "Grab the cash"
                },
                new Project 
                {
                    Id = 4,
                    Name = "Hitman 47",
                    Description = "Greed"
                },
                new Project 
                {
                    Id = 5,
                    Name = "Lucky Number",
                    Description = "Ar thy lucky"
                }
            };


        public Project GetActiveProjects(int searchId)
        {
            var selectedProject = _dummyProjects.Find(project => project.Id == searchId);
            return selectedProject;
        }

        public void EditProject(int id, string name, string description)
        {
            var selectedProject = _dummyProjects.Find(project => project.Id == id);

            selectedProject.Name = name;
            selectedProject.Description = description;
        }

        public void CreateNewProject(string name, string description)
        {        
            //using (var model = new fundgridEntities()) 
            //{
            //    var project = new FundGrid.Repository.project();
            //    project.name = name;
            //    project.description = description;

            //    model.projects.Add(project);
            //    model.SaveChanges();
            //}
        }

        public List<Project> GetAllProjects()
        {
            return _dummyProjects;
        }


        public void CreateNewProject(Project project)
        {
            throw new NotImplementedException();
        }

        public void RemoveProject(int removeId)
        {
            throw new NotImplementedException();
        }


        public Project GetProjects(int searchId, Status status)
        {
            throw new NotImplementedException();
        }
    }
}
