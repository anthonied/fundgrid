using System;
using System.Collections.Generic;
using System.Linq;
using Fundgrid.Data;
using FunGrid.Domain;
using FunGrid.Domain.Interfaces;
using SolutionServerWebSession;
using ServiceStack.OrmLite;

namespace FundGrid.Repository
{
    public class ProjectRepository: RepositoryBase, IProject
    {
        private static Project GetFullDomainProject(ProjectData projectDb)
        {
            var project = projectDb.ToDomain();
            project.Grid = new GridRepository().GetGridByProjectId(project.Id);
            return project;
        }
        private static List<Project> GetFullDomainProjects(List<ProjectData> projectsDb)
        {
            var projects = new List<Project>();
            foreach (var projectDb in projectsDb)
            {
                Project project = GetFullDomainProject(projectDb);
                projects.Add(project);
            }
            return projects;
        }
        public List<Project> GetAllProjects()
        {
            var projectsDb = _db.Select<ProjectData>().ToList();
            return GetFullDomainProjects(projectsDb);
        }

        public List<Project> GetSpecificProjects()
        {
            using (var transaction = _db.OpenTransaction())
            {
                var loggedInUserId = UserSession.LoggedInUser.BaseId;
                var projectsDb = _db.Select<ProjectData>().Where(x => x.Owner_Id == loggedInUserId).ToList();
                return GetFullDomainProjects(projectsDb);
            }
        }

        public Project GetProjectByGridId(int gridId)
        {
            var projectDb = _db.Select<ProjectData>().Where(x => x.Id == gridId).FirstOrDefault();
            return GetFullDomainProject(projectDb);
        }

        public Project GetProject(int searchId, Status status)
        {
            var projectDb = _db.Select<ProjectData>().Where(x => x.Id == searchId).FirstOrDefault();
            var project = projectDb.ToDomain();
            project.Grid = new GridRepository().GetGridByProjectIdAndStatus(project.Id, status);
            return project;
        }

        public void EditProject(int id, string name, string description)
        {
            var newProjectData = new ProjectData() { Id = id, Name = name, Description = description, Owner_Id = UserSession.LoggedInUser.BaseId };
            _db.Update<ProjectData>(newProjectData);
        }

        public void CreateNewProject(Project project)
        {
            using (var transaction = _db.OpenTransaction())
            {
                _db.InsertOnly<ProjectData>(new ProjectData() { Image = project.Image, Description = project.Description, Owner_Id = int.Parse(project.Owner_Id), Name = project.Name }, x => x.Insert(y => new { y.Image, y.Description, y.Owner_Id, y.Name }));
                transaction.Commit();
            }
        }

        public void RemoveProject(int projectId)
        {
            _db.DeleteById<ProjectData>(projectId);
        }
    }
}
