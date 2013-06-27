using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fundgrid.Data;
using FunGrid.Domain;
using FunGrid.Domain.Interfaces;

namespace FundGrid.Repository
{
    public class ProjectRepository:IProject
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
                var selectedProject = (from p in model.projects
                                      where p.id == searchId
                                      select new Project
                                      {
                                          Id = p.id,
                                          Name = p.name,
                                          Description = p.description
                                      }).FirstOrDefault();

                selectedProject.Grid = (from g in model.grids
                                           where g.project_id == searchId
                                           select new Grid
                                           {
                                               Id = g.id,
                                               DimensionColumns = g.dimension_column,
                                               DimensionRows = g.dimension_rows,

                                           }).FirstOrDefault();

                selectedProject.Grid.GridItems = (from gi in model.grid_item
                                                  where gi.grid_id == selectedProject.Grid.Id
                                                  select new GridItem
                                                  {
                                                      Id = gi.id,
                                                      Owner = gi.owner,
                                                      Amount = gi.amount,
                                                      Number = gi.number,
                                                  }).ToList();
                return selectedProject;
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
        public bool CreateGridForProject(int projectId, int columns, int rows)
        {
            int result;
            using (var model = new fundgridEntities())
            {
                var selectedGrid = new grid
                {
                    project_id = projectId,
                    dimension_rows = rows,
                    dimension_column = columns,
                };
                model.grids.Add(selectedGrid);
                result = model.SaveChanges();
            }
            return result > 0;
        }

        public bool AssignItemToGrid(int gridId, int number, string owner, decimal paidAmount)
        {
            int result;
            using (var model = new fundgridEntities())
            { 
                var selectedGridItem = new grid_item
                {
                    grid_id = gridId,
                    number = number,
                    amount = paidAmount,
                    owner = owner
                };
                model.grid_item.Add(selectedGridItem);
                result = model.SaveChanges();
            }
            return result > 0;
        }

    }
}
