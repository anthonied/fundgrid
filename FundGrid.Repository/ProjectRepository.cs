using System;
using System.Collections.Generic;
using System.Linq;
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

                                               InitialValue= g.item_value,
                                               IncrementValue= g.increment_value,
                                           }).FirstOrDefault();

                if (selectedProject.Grid == null) return selectedProject;
                selectedProject.Grid.ExistingGridItems = (from gi in model.grid_item
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
                var newProject = new Fundgrid.Data.project() 
                                { 
                                    name = project.Name,
                                    description = project.Description,
                                };                
                model.projects.Add(newProject);
                model.SaveChanges();
            }
        }


        public bool CreateNewGrid(int projectId, int columns, int rows, decimal itemValue, decimal incrementValue)
        {
            int result;
            using (var model = new fundgridEntities())
            {
                var selectedGrid = new grid
                {
                    
                    project_id = projectId,
                    dimension_rows = rows,
                    dimension_column = columns,
                    item_value = itemValue,
                    increment_value = incrementValue
                };
                model.grids.Add(selectedGrid);
                result = model.SaveChanges();
            }
            return result > 0;
        }

        public void AssignItemToGrid(int gridId, int number, string owner, decimal paidAmount)
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
        }

        public void RemoveProject(int projectId)
        {
            var selectedProject = new project();
            int gridId;
            using (var model = new fundgridEntities())
            {
                selectedProject = (from p in model.projects
                                   where p.id == projectId
                                   select p).FirstOrDefault();

                gridId = selectedProject.grids.Count > 0 ? selectedProject.grids.FirstOrDefault().id : 0;
            }

            if (gridId > 0)
            {
                removeGridItems(gridId);
                removeGrid(gridId);
            }
            removeProject(projectId);
        }

        private void removeProject(int projectId)
        {
            using (var model = new fundgridEntities())
            {
                var selectedProject = (from p in model.projects
                                       where p.id == projectId
                                       select p).FirstOrDefault();

                model.projects.Remove(selectedProject);
                model.SaveChanges();
            }
        }

        private void removeGrid(int gridId)
        { 
            using (var model = new fundgridEntities())
            {
                var removeGrid = (from g in model.grids
                                  where g.id == gridId
                                  select g).FirstOrDefault();
                model.grids.Remove(removeGrid);
                model.SaveChanges();
            }
        }

        public void RemoveGrid(int gridId)
        {
            removeGridItems(gridId);

            using (var model = new fundgridEntities())
            {
                var removeGrid = (from g in model.grids
                                  where g.id == gridId
                                  select g).FirstOrDefault();
                model.grids.Remove(removeGrid);
                model.SaveChanges();
            }

        }

        private void removeGridItems(int gridId)
        {
            using (var model = new fundgridEntities())
            {
                var gridItems = (from gi in model.grid_item
                                 where gi.grid_id == gridId
                                 select gi).ToList();

                foreach (var item in gridItems)
                {
                    model.grid_item.Remove(item);
                    model.SaveChanges();
                }
            }
        }
    }
}
