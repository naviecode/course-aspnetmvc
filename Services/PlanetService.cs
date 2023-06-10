using System;
using System.Collections.Generic;
using ASP.NET_CORE_MVC.Models;
namespace ASP.NET_CORE_MVC.Services
{
    public class PlanetSerivce : List<PlanteModel>
    {
        public PlanetSerivce()
        {
            Add(new PlanteModel(){
                Id = 1,
                Name = "English1",
                VnName = "Sao hỏa",
                Content = "Nội dung"
            });
            Add(new PlanteModel(){
                Id = 2,
                Name = "English2",
                VnName = "Sao Kim",
                Content = "Nội dung"
            });
            Add(new PlanteModel(){
                Id = 3,
                Name = "English3",
                VnName = "Sao Thủy",
                Content = "Nội dung"
            });
            Add(new PlanteModel(){
                Id = 4,
                Name = "English4",
                VnName = "Trái đất",
                Content = "Nội dung"
            });
            Add(new PlanteModel(){
                Id = 5,
                Name = "English5",
                VnName = "Sao hải vương",
                Content = "Nội dung"
            });
            Add(new PlanteModel(){
                Id = 6,
                Name = "English6",
                VnName = "sao thiên vương",
                Content = "Nội dung"
            });
            Add(new PlanteModel(){
                Id = 7,
                Name = "English7",
                VnName = "Sao ABC",
                Content = "Nội dung"
            });
        }
    }
}