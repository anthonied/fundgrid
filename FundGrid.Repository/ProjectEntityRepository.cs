using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fundgrid.Data;
using FunGrid.Domain;
using FunGrid.Domain.Interfaces;

namespace FundGrid.Repository
{
    public class ProjectEntityRepository:IProject
    {
        public List<Project> GetAllProjects()
        {         
            using (var model = new fundgridEntities())
            {
                var projects = (from p in model.projects
                                select new Project
                                {
                                    Id = p.id,
                                    Name = p.name,
                                    Description = p.description,
                                    Image = p.image
                                }).ToList();

                return projects;
            }
        }   

        public Project GetProjectById(int searchId)
        {
            using (var model = new fundgridEntities())
            {
                var getProject = (from p in model.projects
                                  where p.id == searchId
                                  select new Project
                                  {
                                      Id = p.id,
                                      Name = p.name,
                                      Description = p.description
                                  }).FirstOrDefault();
                return getProject;
            }
        }

        public void EditProject(int id, string name, string description)
        {
            using (var model = new fundgridEntities())
            {
                var editProject = (from p in model.projects
                                   where p.id == id
                                   select p).FirstOrDefault();

                editProject.name = name;
                editProject.description = description;

                model.SaveChanges();
            }
        }

        public void CreateNewProject(Project project)
        {
            using(var model = new fundgridEntities())
            {
                var newProject = new Fundgrid.Data.project();                
                newProject.name = project.Name;
                newProject.description = project.Description;

                model.projects.Add(newProject);
                model.SaveChanges();
            }
        }

        //Check of remove werk
        public void RemoveProject(int removeId)
        {
            using (var model = new fundgridEntities())
            {
                var removeProject = (from p in model.projects
                                     where p.id == removeId
                                     select p).FirstOrDefault();

                model.projects.Remove(removeProject);
                model.SaveChanges();
            }
        }

    }
}
