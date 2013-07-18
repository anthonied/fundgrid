using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunGrid.Domain.Interfaces
{
    public interface IProject
    {
        List<Project> GetAllProjects();
        Project GetProject(int searchId, Status status);
        void EditProject(int id, string name, string description);
        void CreateNewProject(Project project);
        void RemoveProject(int removeId);


    }
}
