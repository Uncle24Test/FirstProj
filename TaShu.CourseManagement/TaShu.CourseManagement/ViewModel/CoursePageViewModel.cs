using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaShu.CourseManagement.Common;
using TaShu.CourseManagement.DataAccess;
using TaShu.CourseManagement.Model;

namespace TaShu.CourseManagement.ViewModel
{
    public class CoursePageViewModel
    {
        public ObservableCollection<CategoryItemModel> CategoryCourses { get; set; }
        public ObservableCollection<CategoryItemModel> CategoryTechology { get; set; }
        public ObservableCollection<CategoryItemModel> CategoryTeacher { get; set; }

        public CoursePageViewModel()
        {
            this.CategoryCourses = new ObservableCollection<CategoryItemModel>();
            this.CategoryCourses.Add(new CategoryItemModel
            {
                CategoryName = "全部",
                IsSelected = true
            });
            this.CategoryCourses.Add(new CategoryItemModel
            {
                CategoryName = "公开课"
            });
            this.CategoryCourses.Add(new CategoryItemModel
            {
                CategoryName = "VIP课程"
            });

            this.CategoryTechology = new ObservableCollection<CategoryItemModel>();
            this.CategoryTechology.Add(new CategoryItemModel { CategoryName = "全部", IsSelected = true });
            this.CategoryTechology.Add(new CategoryItemModel { CategoryName = "c#" });
            this.CategoryTechology.Add(new CategoryItemModel { CategoryName = "ASP.net" });
            this.CategoryTechology.Add(new CategoryItemModel { CategoryName = "微服务" });
            this.CategoryTechology.Add(new CategoryItemModel { CategoryName = "JAVA" });

            this.CategoryTeacher = new ObservableCollection<CategoryItemModel>();
            //List<string> teachers = LocalDataAccess.GetInstance().GetTeachers();
            List<string> teachers = LocalDataAccess.GetInstance().GetTeachers();
            this.CategoryTeacher.Add(new CategoryItemModel("全部", true));
            
            teachers.ForEach(t => this.CategoryTeacher.Add(new CategoryItemModel(t)));

        }

    }
}
